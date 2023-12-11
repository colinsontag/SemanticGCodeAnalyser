using SGCA.DataAcces.GCode;
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
    internal static class ReadGCodeFileWorkflow
    {
        /// <summary>
        /// 
        /// </summary>        
        internal static IEnumerable<GCodeLine> Start(string filePath) 
        {
            return SGCA.DataAcces.GCode.GCodeParser.ParseGCode(filePath);            
        }
    }
}
