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
        
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                System.Console.WriteLine("---Semantic GCode Analyser---");
                System.Console.WriteLine("Enter Filepath to Analyse:");
                var filepath = System.Console.ReadLine().Replace("\"","");

                MainWorkflow.Start(filepath);                
            }
            catch (Exception ex) { System.Console.WriteLine(ex.ToString()); }
            finally
            {
                System.Console.WriteLine("Runtrugh Completet");
                System.Console.WriteLine("Press the Any Key to Close");
                System.Console.ReadKey();
            }
        }
    }
}
