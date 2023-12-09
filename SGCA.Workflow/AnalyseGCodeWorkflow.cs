using SGCA.Business.Analyse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    internal class AnalyseGCodeWorkflow
    {
        internal static void Start(IEnumerable<DataAcces.GCode.GCodeLine> readInGCode)
        {
            var test = GCodeAnalyzer.Analyze(readInGCode, 50);
            int i = 0;
        }
    }
}
