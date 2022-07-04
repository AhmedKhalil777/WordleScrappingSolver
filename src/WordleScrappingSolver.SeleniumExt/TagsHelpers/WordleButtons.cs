using OpenQA.Selenium;


namespace WordleScrappingSolver.SeleniumExt.TagsHelpers
{
    public class WordleButtons
    {
        private readonly string _className;
        private readonly Dictionary<string, string> _configs;
        private readonly IWebDriver _webDriver;
        private IWebElement _enetrButton;
        private IWebElement _escapeButton;
        private readonly Dictionary<char?, IWebElement> _buttons = new Dictionary<char?, IWebElement>();
        public WordleButtons(Dictionary<string, string> configs, IWebDriver webDriver)
        {
            _className = configs["WordleButtonClass"];
            _configs = configs;
            _webDriver = webDriver;
            PrepareButtons();
        }


        public void EneterWord(string word)
        {
            foreach (var letter in word.ToUpper())
            {
                PressButton(letter);
            }
            Enetr();
        }


        public void EneterWord(Func<List<char>, List<Tuple<int,char>>, string> generator)
        {
            var wordleRows = new WordleRows(_webDriver, _configs);
            var word = generator(wordleRows.GetHints(), wordleRows.GetSuccess());
            foreach (var letter in word.ToUpper())
            {
                PressButton(letter);
            }
            Enetr();
        }

        private void PrepareButtons()
        {
            var by = By.ClassName(_className);

            var buttons = _webDriver.FindElements(by);
            foreach (var button in buttons)
            {
                if (button.Text == "Enter")
                {
                    _enetrButton = button;
                    continue;
                }
                var c = button.Text?.FirstOrDefault();
                if (c == '\0')
                {
                    _escapeButton = button;
                    continue;
                }
                if (c != null)
                    _buttons.Add(c, button);

            }
        }

        public void Enetr()
        {
            try
            {
                _enetrButton.Click();

            }
            catch (Exception)
            {
            }
        }

        public void Escape()
        {
            try
            {
                _escapeButton.Click();

            }
            catch (Exception)
            {
            }
        }

        public void PressButton(char charachter)
        {
            try
            {
                _buttons[charachter].Click();

            }
            catch (Exception)
            {
            }
        }
    }
}
