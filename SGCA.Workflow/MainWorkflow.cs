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
    /// 
    /// </summary>
    public static class MainWorkflow
    {
        private static MainWindow myWindow;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public static void Start(string filePath)
        {
            var readInGCode = ReadGCodeFileWorkflow.Start(filePath);
            var linesToColor = AnalyseGCodeWorkflow.Start(readInGCode);
            myWindow = new MainWindow(linesToColor, filePath);
            myWindow.ResizeMode = ResizeMode.CanMinimize;
            myWindow.ShowDialog();
        }
    }
}
