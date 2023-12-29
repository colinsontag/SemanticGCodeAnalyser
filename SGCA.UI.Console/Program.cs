using SGCA.UI.Main;
using SGCA.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGCA.UI.Console
{
    
    internal class Program
    {
        /// <summary>
        /// Programm Startup:
        /// Handels errors and starts the main worklfow
        /// </summary>        
        [STAThread]
        static void Main()
        {
            try
            {
                System.Console.WriteLine("---Semantic GCode Analyser---");
                System.Console.WriteLine("Enter Filepath to Analyse:");

                //Gets the console input as filepath.
                var filepath = System.Console.ReadLine().Replace("\"","");

                //Main workflow call 
                MainWorkflow.Start(filepath);                
            }
            //Writes the exception text into the console
            catch (Exception ex) { System.Console.WriteLine(ex.ToString()); }

            //Final console output
            finally
            {
                System.Console.WriteLine("Runthrough completed");
                System.Console.WriteLine("Press the any key to close");
                System.Console.ReadKey();
            }
        }
    }
}
