using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HomeWork5.String
{
    public class TextFileStreams
    {
        public void SearchWords(string filePath)
        {
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                var allText = sr.ReadToEnd();

                var regex = new Regex(@"\b[a-zA-Z]\w*\b");

                var matches = regex.Matches(allText);
                var word = new List<string>();
                var result = 0;

                foreach (Match item in matches)
                {
                    result++;
                    word.Add(item.Value);
                }

                word.Sort();

                using (var sw = new StreamWriter(@"D:\program\words.txt", false, Encoding.UTF8))
                {
                    sw.WriteLine($"Count words in the text = {result}");
                    var result1 = word.GroupBy(x => x)
                                .Where(x => x.Count() > 1)
                                 .Select(x => new { Word = x.Key, Frequency = x.Count() });

                    foreach (var item in result1)
                    {
                        sw.WriteLine($"{item.Word} - {item.Frequency}");
                    }
                }

                regex = new Regex(@"[.!?][\n\s]");
                matches = regex.Matches(allText);
                result = 0;

                foreach (Match item in matches)
                {
                    result++;
                }
              
                regex = new Regex(@"[.!?\n](\w*)");
                var lines = regex.Split(allText);
                var line1 = lines[0];
                foreach (var item in lines)
                {
                    if (item.Length > line1.Length)
                    {
                        line1 = item;
                    }
                }

                using (var sw = new StreamWriter(@"D:\program\sentences.txt", false, Encoding.UTF8))
                {
                    sw.WriteLine($"Count sentences in the text = {result}");
                    sw.WriteLine($"The lagest suggestion is: \n{line1}");
                }

                string[] sentences = Regex.Split(allText, @"(?<=[\.!\?])\s+");
                var s = sentences[0];
                var matches2 = Regex.Matches(s, @"((\b[^\s]+))");
                var List1 = new List<string>();

                foreach (Match item in matches2)
                {
                    List1.Add(item.Value);
                }

                foreach (string sentence in sentences)
                {
                    var matches3 = Regex.Matches(sentence, @"((\b[^\s]+))");
                    var List2 = new List<string>();

                    foreach (Match item in matches3)
                    {
                        List2.Add(item.Value);
                    }

                    if (List2.Count != 0 && List2.Count < List1.Count)
                    {
                        List1 = List2;
                    }
                }

                using (var sw = new StreamWriter(@"D:\program\sentences.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine("The sentence, which have the less words:");
                    foreach (var item in List1)
                    {
                        sw.WriteLine(item);
                    }
                }

                var regexOfPunctuationMark = new Regex(@"[!.?;:,-](\w*)");
                matches = regexOfPunctuationMark.Matches(allText);
                result = 0;
                foreach (Match item in matches)
                {
                    result++;
                }

                using (var sw = new StreamWriter(@"D:\program\sentences.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine($"Count punctuation marks in the text = {result}");
                }

                var letters = allText.Where(symbol => char.IsLetter(symbol));

                if (letters.Any())
                {
                    var resultByLetter = letters
                        .GroupBy(letter => letter)
                        .MaxBy(group => group, new Letters())!;

                    var letter = resultByLetter.Key;
                    var count = resultByLetter.Count();

                    using (var sw = new StreamWriter(@"D:\program\sentences.txt", true, Encoding.UTF8))
                    {
                        sw.WriteLine($"The most repeated letter - {letter} (Count - {count})");
                    }
                }
            }
        }
    }
}