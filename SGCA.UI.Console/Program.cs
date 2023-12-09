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
        public static MainWindow myWindow;
        [STAThread]
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Colin\Documents\Studium\IWA\Flaschenverschluss_0.1_Fehler_Z1346.gcode";

            try
            {
                System.Console.WriteLine("Here I Am Once Again");
                MainWorkflow.Start(filePath);
                myWindow = new MainWindow();
                myWindow.ShowDialog();
                
            }
            catch (Exception ex) { System.Console.WriteLine(ex.ToString()); }
            finally
            {
                System.Console.WriteLine("Dumb Message: Runtrugh Completet");
                System.Console.WriteLine("Press the Any Key to Close");
                System.Console.ReadKey();
            }
        }
    }
}
