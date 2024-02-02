using System;
using System.Linq;

namespace lab3.Model
{
	public record class Text(List<Sentence> Sentences)
	{

		public Text RemoveConsonantWords(int wordsLength) =>
			this with
			{
				Sentences = Sentences.Select(s => new Sentence(s.GetMatchingSentenceParts(wordsLength))).ToList()
			};

        public override string ToString()
        {
			return string.Join("", Sentences.Select(s => s.ToString()));
        }
    }
}

