using System;
namespace lab3.Model
{
	public abstract record class SentencePart;

	public record class Word(List<Letter> Letters): SentencePart
	{
        public override string ToString()
        {
            return string.Join("", Letters.Select(l => l.ToString()));
        }
    }

	public record class PunctuationMark(string Value): SentencePart
    {
        public override string ToString()
        {
            return Value;
        }
    }
}

