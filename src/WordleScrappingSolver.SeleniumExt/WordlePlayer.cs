using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordleScrappingSolver.SeleniumExt.TagsHelpers;

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
            buttonsHelper.EneterWord("Ahmed");
        }
    }
}
