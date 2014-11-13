using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        #region Fields

        private static readonly Regex _valueParseExpresion = new Regex("^(?<width>[0-9]+) (?<height>[0-9]+)$");

        #endregion

        #region Constructors

        public Arena(string value)
        {
            if (value == null)
            {
                ErrorMessage = "The value is null";
                return;
            }

            Match valueParseMatch = _valueParseExpresion.Match(value);
            if (!valueParseMatch.Success)
            {
                ErrorMessage = "The value is invalid";
                return;
            }

            ushort widthParseResult;
            if (!ushort.TryParse(valueParseMatch.Groups["width"].Value, out widthParseResult) || widthParseResult < 1)
            {
                ErrorMessage = "Width need to be a number between 1 and 65535";
                return;
            }

            ushort heightParseResult;
            if (!ushort.TryParse(valueParseMatch.Groups["height"].Value, out heightParseResult) || heightParseResult < 1)
            {
                ErrorMessage = "Height need to be a number between 1 and 65535";
                return;
            }

            Width = widthParseResult;
            Height = heightParseResult;
        }

        #endregion

        #region Properties

        public bool IsValid
        {
            get
            {
                return ErrorMessage == null;
            }
        }

        public ushort Width { get; private set; }

        public ushort Height { get; private set; }

        public string ErrorMessage { get; private set; }

        #endregion

        #region Method

        public bool InsidePlayingArea(ushort x, ushort y)
        {
            return x >= 0 && x <= Width && y >= 0 && y <= Height;
        }

        #endregion
    }
}
