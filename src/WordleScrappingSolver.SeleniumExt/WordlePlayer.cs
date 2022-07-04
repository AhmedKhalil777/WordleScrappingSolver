using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordleScrappingSolver.SeleniumExt.TagsHelpers;
using WordleScrappingSolver.SeleniumExt.WordEngine;

namespace WordleScrappingSolver.SeleniumExt
{
    public class WordlePlayer
    {
        private readonly IWebDriver _webDriver;
        private readonly Dictionary<string, string> _configs;

        public WordlePlayer(IWebDriver webDriver, Dictionary<string,string> configs)
        {
            _webDriver = webDriver;
            _configs = configs;
        }

        public void StartPlay()
        {
            var buttonsHelper = new WordleButtons(_configs, _webDriver);
            var fiveLetters = new FiveLetters();
            buttonsHelper.EneterWord(fiveLetters.GenerateRandom());
            buttonsHelper.EneterWord(fiveLetters.GenerateRandom());
            buttonsHelper.EneterWord(fiveLetters.GenerateRandom());
            buttonsHelper.EneterWord(fiveLetters.GenerateRandom());
            buttonsHelper.EneterWord(fiveLetters.GenerateRandom());
        }
    }
}
