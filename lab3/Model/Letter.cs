using System;
namespace lab3.Model
{
	public record class Letter(string Value)
	{
        public override string ToString()
        {
            return Value;
        }
    }
}

