using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SGCA.DataAcces.GCode.GCodeCommands
{
    internal static class G1Command
    {
        internal static GCodeLine Parse(string line, double lastFValue)
        {
            GCodeLine gCodeLine = new GCodeLine { CommandType = "G1" };

            string[] parts = line.Split(' ');

            foreach (string part in parts)
            {
                char parameter = part[0];
                string value = part.Substring(1);

                switch (parameter)
                {
                    case 'X':
                        gCodeLine.X = TryParseDouble(value);
                        break;

                    case 'Y':
                        gCodeLine.Y = TryParseDouble(value);
                        break;

                    case 'Z':
                        gCodeLine.Z = TryParseDouble(value);
                        break;

                    case 'F':
                        gCodeLine.F = TryParseDouble(value);
                        break;

                    case 'E':
                        gCodeLine.E = TryParseDouble(value);
                        break;
                }
            }

            return gCodeLine;
        }
        private static double TryParseDouble(string value)
        {
            value = value.Replace('.', ',');
            double result;
            
            if (double.TryParse(value, out result))
            {
                return result;
            }
            return 0.0;
        }

            
        
    }
}
