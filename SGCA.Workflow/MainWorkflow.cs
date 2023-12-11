using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    public static class MainWorkflow
    {
        public static List<int> Start(string filePath)
        {
            var readInGCode = ReadGCodeFileWorkflow.Start(filePath);

            return AnalyseGCodeWorkflow.Start(readInGCode);
        }
    }
}
