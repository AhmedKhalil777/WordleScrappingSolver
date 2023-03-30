using OpenQA.Selenium;

namespace WordleScrappingSolver.SeleniumExt.TagsHelpers
{
    public class WordleWord
    {
        public bool Locked { get; set; }
        private bool _isEmpty;
        private bool _haveHints;
        private bool _haveSuccess;
        private List<Tuple<char,LetterState,int>> _hints;
        public IEnumerable<WordleLetter> Letters { get => _letters;  }
        private readonly List<WordleLetter> _letters = new List<WordleLetter>();
        private readonly int order;
        private readonly Dictionary<string, string> _configs;
        public WordleWord(IWebElement row, Dictionary<string,string> configs, int order)
        {
            _configs=configs;
            this.order = order;
            var elements = row.FindElements(By.ClassName(configs["RowLetterClass"]));
            for (int i = 0; i < elements.Count; i++)
            {
                var element = elements[i];
                var letter = new WordleLetter {ColumnIndex = i};
                var d = element.Text;
                var classValue = element.GetDomAttribute("Class");
                if (classValue is null)
                {
                    continue;
                }
                if (classValue.Contains(configs["AbsentLetter"]))
                {
                    letter.Char = element.Text[0];
                    letter.State = CharState.Absent;
                    _letters.Add(letter);

                }
                else if (classValue.Contains(configs["LetterElseWhere"]))
                {
                    letter.Char = element.Text[0];
                    letter.State = CharState.ElseWhere;
                    _letters.Add(letter);

                }
                else if(classValue.Contains(configs["LetterCorrect"]))
                {
                    letter.Char = element.Text[0];
                    letter.State = CharState.Correct;
                    _letters.Add(letter);

                }
            }
           
             
        }

        public bool IsEmpty => _isEmpty;
    }

    public enum LetterState
    {
        Success, 
        Failed,
        Exist
    } 
}
