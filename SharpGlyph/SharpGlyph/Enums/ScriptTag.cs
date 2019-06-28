﻿using System;
namespace SharpGlyph {
	public class ScriptTag {
		public static string ToName(string id) {
			switch (id) {
				case "adlm": return "Adlam";
				case "ahom": return "Ahom";
				case "hluw": return "Anatolian Hieroglyphs";
				case "arab": return "Arabic";
				case "armn": return "Armenian";
				case "avst": return "Avestan";
				case "bali": return "Balinese";
				case "bamu": return "Bamum";
				case "bass": return "Bassa Vah";
				case "batk": return "Batak";
				case "beng": return "Bengali";
				case "bng2": return "Bengali v.2";
				case "bhks": return "Bhaiksuki";
				case "bopo": return "Bopomofo";
				case "brah": return "Brahmi";
				case "brai": return "Braille";
				case "bugi": return "Buginese";
				case "buhd": return "Buhid";
				case "byzm": return "Byzantine Music";
				case "cans": return "Canadian Syllabics";
				case "cari": return "Carian";
				case "aghb": return "Caucasian Albanian";
				case "cakm": return "Chakma";
				case "cham": return "Cham";
				case "cher": return "Cherokee";
				case "hani": return "CJK Ideographic";
				case "copt": return "Coptic";
				case "cprt": return "Cypriot Syllabary";
				case "cyrl": return "Cyrillic";
				case "DFL ": return "Default";
				case "dsrt": return "Deseret";
				case "deva": return "Devanagari";
				case "dev2": return "Devanagari v.2";
				case "dogr": return "Dogra";
				case "dupl": return "Duployan";
				case "egyp": return "Egyptian Hieroglyphs";
				case "elba": return "Elbasan";
				case "ethi": return "Ethiopic";
				case "geor": return "Georgian";
				case "glag": return "Glagolitic";
				case "goth": return "Gothic";
				case "gran": return "Grantha";
				case "grek": return "Greek";
				case "gujr": return "Gujarati";
				case "gjr2": return "Gujarati v.2";
				case "gong": return "Gunjala Gondi";
				case "guru": return "Gurmukhi";
				case "gur2": return "Gurmukhi v.2";
				case "hang": return "Hangul";
				case "jamo": return "Hangul Jamo";
				case "rohg": return "Hanifi Rohingya";
				case "hano": return "Hanunoo";
				case "hatr": return "Hatran";
				case "hebr": return "Hebrew";
				case "kana": return "Hiragana/Katakana";
				case "armi": return "Imperial Aramaic";
				case "phli": return "Inscriptional Pahlavi";
				case "prti": return "Inscriptional Parthian";
				case "java": return "Javanese";
				case "kthi": return "Kaithi";
				case "knda": return "Kannada";
				case "knd2": return "Kannada v.2";
				case "kali": return "Kayah Li";
				case "khar": return "Kharosthi";
				case "khmr": return "Khmer";
				case "khoj": return "Khojki";
				case "sind": return "Khudawadi";
				case "lao ": return "Lao";
				case "latn": return "Latin";
				case "lepc": return "Lepcha";
				case "limb": return "Limbu";
				case "lina": return "Linear A";
				case "linb": return "Linear B";
				case "lisu": return "Lisu (Fraser)";
				case "lyci": return "Lycian";
				case "lydi": return "Lydian";
				case "mahj": return "Mahajani";
				case "maka": return "Makasar";
				case "mlym": return "Malayalam";
				case "mlm2": return "Malayalam v.2";
				case "mand": return "Mandaic, Mandaean";
				case "mani": return "Manichaean";
				case "marc": return "Marchen";
				case "gonm": return "Masaram Gondi";
				case "math": return "Mathematical Alphanumeric Symbols";
				case "medf": return "Medefaidrin (Oberi Okaime, Oberi Ɔkaimɛ)";
				case "mtei": return "Meitei Mayek (Meithei, Meetei)";
				case "mend": return "Mende Kikakui";
				case "merc": return "Meroitic Cursive";
				case "mero": return "Meroitic Hieroglyphs";
				case "plrd": return "Miao";
				case "modi": return "Modi";
				case "mong": return "Mongolian";
				case "mroo": return "Mro";
				case "mult": return "Multani";
				case "musc": return "Musical Symbols";
				case "mymr": return "Myanmar";
				case "mym2": return "Myanmar v.2";
				case "nbat": return "Nabataean";
				case "newa": return "Newa";
				case "talu": return "New Tai Lue";
				case "nko ": return "N'Ko";
				case "nshu": return "Nüshu";
				case "orya": return "Odia (formerly Oriya)";
				case "ory2": return "Odia v.2 (formerly Oriya v.2)";
				case "ogam": return "Ogham";
				case "olck": return "Ol Chiki";
				case "ital": return "Old Italic";
				case "hung": return "Old Hungarian";
				case "narb": return "Old North Arabian";
				case "perm": return "Old Permic";
				case "xpeo": return "Old Persian Cuneiform";
				case "sogo": return "Old Sogdian";
				case "sarb": return "Old South Arabian";
				case "orkh": return "Old Turkic, Orkhon Runic";
				case "osge": return "Osage";
				case "osma": return "Osmanya";
				case "hmng": return "Pahawh Hmong";
				case "palm": return "Palmyrene";
				case "pauc": return "Pau Cin Hau";
				case "phag": return "Phags-pa";
				case "phnx": return "Phoenician";
				case "phlp": return "Psalter Pahlavi";
				case "rjng": return "Rejang";
				case "runr": return "Runic";
				case "samr": return "Samaritan";
				case "saur": return "Saurashtra";
				case "shrd": return "Sharada";
				case "shaw": return "Shavian";
				case "sidd": return "Siddham";
				case "sgnw": return "Sign Writing";
				case "sinh": return "Sinhala";
				case "sogd": return "Sogdian";
				case "sora": return "Sora Sompeng";
				case "soyo": return "Soyombo";
				case "xsux": return "Sumero-Akkadian Cuneiform";
				case "sund": return "Sundanese";
				case "sylo": return "Syloti Nagri";
				case "syrc": return "Syriac";
				case "tglg": return "Tagalog";
				case "tagb": return "Tagbanwa";
				case "tale": return "Tai Le";
				case "lana": return "Tai Tham (Lanna)";
				case "tavt": return "Tai Viet";
				case "takr": return "Takri";
				case "taml": return "Tamil";
				case "tml2": return "Tamil v.2";
				case "tang": return "Tangut";
				case "telu": return "Telugu";
				case "tel2": return "Telugu v.2";
				case "thaa": return "Thaana";
				case "thai": return "Thai";
				case "tibt": return "Tibetan";
				case "tfng": return "Tifinagh";
				case "tirh": return "Tirhuta";
				case "ugar": return "Ugaritic Cuneiform";
				case "vai ": return "Vai";
				case "wara": return "Warang Citi";
				case "yi  ": return "Yi";
				case "zanb": return "Zanabazar Square (Zanabazarin Dörböljin Useg, Xewtee Dörböljin Bicig, Horizontal Square Script)";
			}
			return id;
		}
	}
}