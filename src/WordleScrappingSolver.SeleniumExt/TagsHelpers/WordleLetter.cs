using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleScrappingSolver.SeleniumExt.TagsHelpers
{
    public class WordleLetter
    {

        public WordleLetter()
        {

        }

        public char Char { get; set; }
        public int ColumnIndex { get; set; }
        public CharState State { get; set; }

    }

    public enum CharState
    {
        Correct,
        ElseWhere,
        Absent,
        UnSet,
    }
}
