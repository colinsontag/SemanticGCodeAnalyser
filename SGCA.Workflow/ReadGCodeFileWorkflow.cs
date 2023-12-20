using SGCA.DataAcces.GCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCA.Workflow
{
    /// <summary>
    /// Workflow that handles the the reading and parsing of the G-Code into are specfic code structure
    /// </summary>
    internal static class ReadGCodeFileWorkflow
    {
        /// <summary>
        /// Starts the ReadGCodeFileWorkflow
        /// </summary>
        /// <param name="filePath">Path to the file that should be checked</param>
        /// <returns>Returns an IEnumerable<GCodeLine> with all parsed G-Code lines </returns>

        internal static IEnumerable<GCodeLine> Start(string filePath) 
        {
            return GCodeParser.ParseGCode(filePath);            
        }
    }
}
