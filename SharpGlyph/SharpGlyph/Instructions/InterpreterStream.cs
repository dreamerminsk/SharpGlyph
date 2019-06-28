﻿using System;
using System.Collections.Generic;

namespace SharpGlyph {
	public class InterpreterStream {
		Stack<byte[]> streams;
		Stack<int> pcs;
		byte[] stream;
		int pc;

		public int Length {
			get {
				if (stream == null) {
					return 0;
				}
				return stream.Length;
			}
		}

		public int Position {
			get { return pc; }
		}

		public int Depth {
			get { return streams.Count; }
		}

		public InterpreterStream() {
			streams = new Stack<byte[]>();
			pcs = new Stack<int>();
			stream = null;
			pc = 0;
		}

		public void Push(byte[] bytes) {
			streams.Push(stream);
			pcs.Push(pc);
			stream = bytes;
			pc = 0;
		}

		public void Push(byte[] bytes, int count) {
			for (int i = 0; i < count; i++) {
				streams.Push(stream);
				pcs.Push(pc);
				stream = bytes;
				pc = 0;
			}
		}

		public void Pop() {
			stream = streams.Pop();
			pc = pcs.Pop();
		}

		public bool HasNext() {
			return pc + 1 < stream.Length;
		}

		public byte Next() {
			if (pc >= stream.Length) {
				return 0;
			}
			return stream[pc++];
		}

		public int NextWord() {
			byte high = Next();
			byte low = Next();
			return (high << 8) | low;
		}

		public void JMPR(int offset) {
			pc += offset;
		}

		public void JROT(int condition, int offset) {
			if (condition == 1) {
				pc += offset;
			}
		}

		public void JROF(int condition, int offset) {
			if (condition == 0) {
				pc += offset;
			}
		}

		public void IF(int condition) {
			if (condition != 0) {
				return;
			}
			int depth = 0;
			int skip = 0;
			while (pc < stream.Length) {
				int opcode = stream[pc++];
				if (skip > 0) {
					skip--;
					continue;
				}
				switch (opcode) {
					case 0x58: // IF[ ] (IF test)
						depth++;
						break;
					// NPUSHB[ ] (PUSH N Bytes)
					case 0x40:
						skip = stream[pc] + 1;
						break;
					// NPUSHW[ ] (PUSH N Words)
					case 0x41:
						skip = stream[pc] * 2 + 1;
						break;
					// PUSHB[abc] (PUSH Bytes)
					case 0xB0: case 0xB1: case 0xB2: case 0xB3:
					case 0xB4: case 0xB5: case 0xB6: case 0xB7:
						skip = opcode - 0xAF;
						break;
					// PUSHW[abc] (PUSH Words)
					case 0xB8: case 0xB9: case 0xBA: case 0xBB:
					case 0xBC: case 0xBD: case 0xBE: case 0xBF:
						skip = (opcode - 0xB7) * 2;
						break;
				}
				if (skip > 0) {
					continue;
				}
				if (depth > 0) {
					// EIF
					if (opcode == 0x59) {
						depth--;
					}
					continue;
				}
				// ELSE, EIF
				if (opcode == 0x1B || opcode == 0x59) {
					break;
				}
			}
		}

		public void ELSE() {
			int skip = 0;
			while (pc < stream.Length) {
				int opcode = stream[pc++];
				if (skip > 0) {
					skip--;
					continue;
				}
				switch (opcode) {
					// NPUSHB[ ] (PUSH N Bytes)
					case 0x40:
						skip = stream[pc] + 1;
						break;
					// NPUSHW[ ] (PUSH N Words)
					case 0x41:
						skip = stream[pc] * 2 + 1;
						break;
					// PUSHB[abc] (PUSH Bytes)
					case 0xB0: case 0xB1: case 0xB2: case 0xB3:
					case 0xB4: case 0xB5: case 0xB6: case 0xB7:
						skip = opcode - 0xAF;
						break;
					// PUSHW[abc] (PUSH Words)
					case 0xB8: case 0xB9: case 0xBA: case 0xBB:
					case 0xBC: case 0xBD: case 0xBE: case 0xBF:
						skip = (opcode - 0xB7) * 2;
						break;
				}
				if (skip > 0) {
					continue;
				}
				// EIF
				if (opcode == 0x59) {
					break;
				}
			}
		}

		public byte[] GetFunc() {
			List<byte> bytes = new List<byte>();
			int skip = 0;
			while (pc < stream.Length) {
				byte opcode = stream[pc++];
				if (skip > 0) {
					skip--;
					bytes.Add(opcode);
					continue;
				}
				switch (opcode) {
					// NPUSHB[ ] (PUSH N Bytes)
					case 0x40:
						skip = stream[pc] + 1;
						break;
					// NPUSHW[ ] (PUSH N Words)
					case 0x41:
						skip = stream[pc] * 2 + 1;
						break;
					// PUSHB[abc] (PUSH Bytes)
					case 0xB0: case 0xB1: case 0xB2: case 0xB3:
					case 0xB4: case 0xB5: case 0xB6: case 0xB7:
						skip = opcode - 0xAF;
						break;
					// PUSHW[abc] (PUSH Words)
					case 0xB8: case 0xB9: case 0xBA: case 0xBB:
					case 0xBC: case 0xBD: case 0xBE: case 0xBF:
						skip = (opcode - 0xB7) * 2;
						break;
				}
				if (skip > 0) {
					bytes.Add(opcode);
					continue;
				}
				// ENDF
				if (opcode == 0x2D) {
					break;
				}
				bytes.Add(opcode);
			}
			return bytes.ToArray();
		}
	}
}