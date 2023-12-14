﻿using SGCA.UI.Main;
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
            try
            {
               
                System.Console.WriteLine("Here I Am Once Again");
                var filepath = System.Console.ReadLine();
                var linesToColor = MainWorkflow.Start(filepath);
                
                myWindow = new MainWindow(linesToColor,filepath);
                myWindow.ResizeMode = ResizeMode.CanMinimize;
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
