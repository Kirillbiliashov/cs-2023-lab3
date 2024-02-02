using lab3.Model;
using System.Text.RegularExpressions;
using lab3;

Console.Write("Enter word length: ");

int removeLength;

while (!int.TryParse(Console.ReadLine(), out removeLength))
{
    Console.Write("Enter valid word length: ");
}

Console.Write("Enter text: ");

var text = Console.ReadLine();

var textClass = Regex.Replace(text.ToLower(), @"\s+", " ").ParseToText();

Console.WriteLine($"Result: {textClass.RemoveConsonantWords(removeLength)}");



