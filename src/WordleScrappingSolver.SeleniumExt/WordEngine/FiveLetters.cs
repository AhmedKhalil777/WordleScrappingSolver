using System.Text.Json;
using WordleScrappingSolver.SeleniumExt.TagsHelpers;

namespace WordleScrappingSolver.SeleniumExt.WordEngine
{
    public class FiveLetters : ILettersGenerator
    {
        static readonly List<string> _words;
        static FiveLetters()
        {
            var lettersStr = File.ReadAllText("./fiveLetters.json");
            _words = JsonSerializer.Deserialize<List<string>>(lettersStr)!.Select(x => x.ToUpper()).ToList();
        }


        public string GenerateRandom()
        {
            return _words.Skip(new Random().Next(0, _words.Count - 1)).Take(1).First();
        }

        public string Generate(WordleRows rows = null)
        {
            if (rows == null)
            {
                return GenerateRandom();
            }
            IEnumerable<string> words = _words.AsReadOnly();
            foreach (var letter in rows.GetWords().SelectMany(x => x.Letters).OrderBy(x=> x.State).DistinctBy(x =>  x.Char ))
            {
                if (letter.State == CharState.Correct)
                {
                    words = words.Where(x => x[letter.ColumnIndex] == letter.Char);

                }
                if (letter.State == CharState.ElseWhere)
                {
                    words = words.Where(x => x.Contains(letter.Char));
                }
                if (letter.State == CharState.Absent)
                {
                    words = words.Where(x => !x.Contains(letter.Char));
                }
            }
            return words.First();
        }
    }
}
