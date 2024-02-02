using System;
using lab3.Model;

namespace lab3
{
	public static class StringExtensions
	{

		private static readonly char[] s_punctuationMarks = { '.', '!', '?' };

        private static readonly char[] s_punctuationMarksInSentence = { ',', ';', ':', ' ', '-' };

		private static readonly char[] s_allPunctuationMarks = s_punctuationMarks.Concat(s_punctuationMarksInSentence).ToArray();

        public static Text ParseToText(this string str)
        {
            var sentences = str
                .SplitInclusive(s_punctuationMarks)
                .Select(s => s.ParseToSentence())
                .ToList();
			if (sentences.Count > 0)
			{
				return new Text(sentences);
			}
			return new Text(new List<Sentence> { str.ParseToSentence() });
        }


        public static List<string> SplitInclusive(this string str, char[] splitSymbols)
		{
			var result = new List<string>();
			var splitStrIdx = -1;
			var strOffset = 0;

			for (int i = 0; i < str.Length; i++)
			{
				var symbol = str[i];
                if (splitSymbols.Any(s => s == symbol))
                {
					splitStrIdx = i;
					result.Add(str.Substring(strOffset, splitStrIdx + 1 - strOffset));
					strOffset = splitStrIdx + 1;
                }
            }
			return result;
        }

        public static Sentence ParseToSentence(this string str)
        {
            var splitSentence = str.SplitSeparately(s_allPunctuationMarks.ToArray());
            if (splitSentence.Count > 0)
            {
                return new Sentence(splitSentence.Select(s => s.ParseToSentencePart()).ToList());
            }
            return new Sentence(new List<SentencePart>() { str.ParseToSentencePart() });
        }


        public static List<string> SplitSeparately(this string str, char[] splitSymbols)
		{
			var result = new List<string>();
			var strOffset = 0;
			for (int i = 0; i < str.Length; i++)
			{
                var symbol = str[i];
                if (splitSymbols.Any(s => s == symbol))
				{
					var prevSubstr = str.Substring(strOffset, i - strOffset);
					if (prevSubstr != symbol.ToString())
					{
						result.Add(prevSubstr);
					}
					result.Add(symbol.ToString());
					strOffset = i + 1;
				}
			}
			if (strOffset < str.Length)
			{
				var substr = str.Substring(strOffset);
				result.Add(substr);
			}
			return result;
		}

		public static SentencePart ParseToSentencePart(this string str)
		{
			if (s_allPunctuationMarks.Any(m => m.ToString() == str))
			{
				return new PunctuationMark(str);
			}
			return str.ParseToWord();
		}

		public static Word ParseToWord(this string str)
		{
			var letters = str.ToList().Select(c => new Letter(c.ToString()));
			return new Word(letters.ToList());
		}
	}
}

