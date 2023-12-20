using SGCA.Business.Analyse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    /// <summary>
    /// Workflow that analysis the file
    /// </summary>
    internal class AnalyseGCodeWorkflow
    {
        /// <summary>
        /// Starts the workflow and calls the G-Code analyze function
        /// </summary>
        /// <param name="readInGCode"></param>
        /// <returns>List with the line numbers where errors where found </returns>
        internal static List<int> Start(IEnumerable<DataAcces.GCode.GCodeLine> readInGCode)
        {
            return GCodeAnalyzer.Analyze(readInGCode, 50);
        }
    }
}
