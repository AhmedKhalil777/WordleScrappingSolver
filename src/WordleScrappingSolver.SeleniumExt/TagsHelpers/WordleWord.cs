using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleScrappingSolver.SeleniumExt.TagsHelpers
{
    public class WordleWord
    {
        public bool Locked { get; set; }
        private bool _isEmpty;
        private bool _haveHints;
        private bool _haveSuccess;
        private List<Tuple<char,LetterState,int>> _hints;
        private readonly List<WordleLetter> _letters = new List<WordleLetter>();
        private readonly int order;

        public WordleWord(IWebElement row, string rowLetterClassName, int order)
        {
             this.order = order;
            Locked = _
            _hints = row.FindElements(By.ClassName(rowLetterClassName)).Select(x=> x.)
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
