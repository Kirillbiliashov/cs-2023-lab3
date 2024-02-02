using System;
namespace lab3.Model
{
    public record class Sentence(List<SentencePart> Parts)
    {
        private static readonly string[] s_consonantLetters = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
    "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};

        public List<SentencePart> GetMatchingSentenceParts(int wordsLength) =>
            Parts.Where(p => !(p is Word word &&
            word.Letters.Count == wordsLength &&
            s_consonantLetters.Contains(word.Letters.First().Value))).ToList();


        public override string ToString()
        {
            return string.Join("", Parts.Select(p => p.ToString()));
        }
    }
}

