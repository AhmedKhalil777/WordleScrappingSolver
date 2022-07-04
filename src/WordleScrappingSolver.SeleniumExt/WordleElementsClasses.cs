using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleScrappingSolver.SeleniumExt
{
    public static class WordleElementsClasses
    {
        private const string Base = @"Class";
        public const string RowLocked = @$"{nameof(RowLocked)}{Base}";
        public const string RowLetter = @$"{nameof(RowLetter)}{Base}";
        public const string Row = @$"{nameof(Row)}{Base}";

    }
}
