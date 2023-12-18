using SGCA.Business.Analyse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    internal class AnalyseGCodeWorkflow
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readInGCode"></param>
        /// <returns></returns>
        internal static List<int> Start(IEnumerable<DataAcces.GCode.GCodeLine> readInGCode)
        {
            return GCodeAnalyzer.Analyze(readInGCode, 50);
        }
    }
}
