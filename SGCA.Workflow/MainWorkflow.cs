using MathNet.Numerics;
using SGCA.UI.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGCA.Workflow
{
    /// <summary>
    /// Main Worklfow that handles the basic logic
    /// </summary>
    public static class MainWorkflow
    {
        private static MainWindow myWindow;
        /// <summary>
        /// Starts the MainWorklfow
        /// </summary>
        /// <param name="filePath">Path to the file that should be checked</param>
        public static void Start(string filePath)
        {
            //Starts workflow that read the G-Code from the File
            var readInGCode = ReadGCodeFileWorkflow.Start(filePath);

            //Workflow that Analyses the readin GCode
            var linesToColor = AnalyseGCodeWorkflow.Start(readInGCode);

            //Opens the the GUI
            myWindow = new MainWindow(linesToColor, filePath);
            myWindow.ResizeMode = ResizeMode.CanMinimize;
            myWindow.ShowDialog();
        }
    }
}
