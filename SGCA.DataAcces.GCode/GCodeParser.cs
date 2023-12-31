﻿using SGCA.DataAcces.GCode.GCodeCommands;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGCA.DataAcces.GCode
{
   
    public static class GCodeParser
    {
        private static List<GCodeLine> gCodeLines = new List<GCodeLine>();
        /// <summary>
        /// Reads in the file at the given path and parses them
        /// </summary>
        /// <param name="filePath">Path to the file that should be checked</param>
        /// <returns>Returns list of parsed G-Code lines</returns>
        public static List<GCodeLine> ParseGCode(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            double lastFValue = default;
            bool printInitialisingDone = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.StartsWith("M107")) printInitialisingDone = true;

                if (line.StartsWith("G1") && printInitialisingDone)
                {
                    GCodeLine gCodeLine = G1Command.Parse(line, lastFValue);
                    if (gCodeLine != null)
                    {
                        gCodeLine.LineNumber = i + 1; // Line numbers start from 1
                        gCodeLines.Add(gCodeLine);
                        lastFValue = gCodeLine.F;
                    }
                }
            }            
            return gCodeLines;
        }
    }
}
