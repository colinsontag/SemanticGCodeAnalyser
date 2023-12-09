using MathNet.Spatial.Euclidean;
using SGCA.DataAcces.GCode;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SGCA.Business.Analyse
{
    public class GCodeAnalyzer
    {
        public static List<int> Analyze(IEnumerable<DataAcces.GCode.GCodeLine> gCodeLines, double tolerance)
        {
            List<int> linesWithErrors = new List<int>();
            for (int i = 1; i < gCodeLines.Count() - 1; i++)
            {
                DataAcces.GCode.GCodeLine currentPoint = gCodeLines.ElementAt(i);
                DataAcces.GCode.GCodeLine pointBefore = gCodeLines.ElementAt(i - 1);
                DataAcces.GCode.GCodeLine pointAfter = gCodeLines.ElementAt(i + 1);

                if (!IsInLine(currentPoint, pointBefore, tolerance) || !IsInLine(currentPoint, pointAfter, tolerance))
                {
                    Console.WriteLine($"Point {currentPoint.LineNumber} is out of line with its neighbors.");
                    linesWithErrors.Add(currentPoint.LineNumber);
                }
            }
            return linesWithErrors;
        }

        private static bool IsInLine(DataAcces.GCode.GCodeLine point1, DataAcces.GCode.GCodeLine point2, double tolerance)
        {
            
            // Convert GCodeLine to MathNet.Spatial.Euclidean.Point3D
            Point3D p1 = new Point3D(point1.X, point1.Y, point1.Z);
            Point3D p2 = new Point3D(point2.X, point2.Y, point2.Z);
            //Check if either of the Points is a (0,0,0). This is a G-Code behaiviour that is normal to for example Layerchanges and is not a wrong Point. 
            if (p1 == new Point3D() || p2 == new Point3D())
            {
                return true;
            }
            else
            {
                // Check if the distance between the points is within the tolerance
                double distance = p1.DistanceTo(p2);
                return distance <= tolerance;
            }
            
        }
    }
}
