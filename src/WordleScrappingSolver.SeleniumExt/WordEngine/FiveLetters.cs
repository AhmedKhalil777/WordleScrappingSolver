using System.Text.Json;

namespace WordleScrappingSolver.SeleniumExt.WordEngine
{
    public class FiveLetters : ILettersGenerator
    {
        static readonly List<string> _words;
        static FiveLetters()
        {
            var lettersStr = File.ReadAllText("./fiveLetters.json");
            _words = JsonSerializer.Deserialize<List<string>>(lettersStr)!;
        }


        public string GenerateRandom()
        {
            return _words.Skip(new Random().Next(0, _words.Count - 1)).Take(1).First();
        }

        public string Generate(HashSet<char> hints, HashSet<Tuple<int,char>> success)
        {
            return _words.Where(x => hints.Any(y => x.Any(z => y.ToString().ToUpper() == z.ToString().ToUpper())))
                .Where(x=>  success.All(y => x[y.Item1].ToString().ToUpper() == y.Item2.ToString().ToUpper()))
                .First();
        }
    }
}
