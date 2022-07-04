using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleScrappingSolver.SeleniumExt.TagsHelpers
{
    public class WordleRows
    {
        private readonly List<WordleWord> _words = new List<WordleWord>();
        private readonly IWebDriver _webDriver;
        private readonly Dictionary<string, string> _configs;
        private IWebElement _rows;
        private List<char> _hints;
        private List<Tuple<int, char>> _success;
        public WordleRows(IWebDriver webDriver, Dictionary<string, string> configs)
        {
            _webDriver = webDriver;
            _configs = configs;
            _rows = _webDriver.FindElement(By.ClassName(configs["WordleRowsClass"]));
            int i = 1;
            _words = _rows.FindElements(By.ClassName("RowClass"))
                .Select(x => new WordleWord(x, configs["RowLetterClass"], i++))
                .ToList();
        }

        public List<char> GetHints()
        {
            throw new NotImplementedException();
        }

        public List<Tuple<int,char>> GetSuccess()
        {
            throw new NotImplementedException();
        }
    }
}
