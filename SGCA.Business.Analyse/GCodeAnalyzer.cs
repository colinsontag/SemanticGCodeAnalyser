using MathNet.Spatial.Euclidean;
using SGCA.DataAcces.GCode;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SGCA.Business.Analyse
{
    public class GCodeAnalyzer
    {
        /// <summary>
        /// Analyses the eneumerable with the given tolerance
        /// </summary>
        /// <param name="gCodeLines">List of the parsed GCodeLines</param>
        /// <param name="tolerance">The tolerance tha points are checked with</param>
        /// <returns></returns>
        public static List<int> Analyze(IEnumerable<GCodeLine> gCodeLines, double tolerance)
        {
            List<int> linesWithErrors = new List<int>();
            for (int i = 1; i < gCodeLines.Count() - 1; i++)
            {
                GCodeLine currentPoint = gCodeLines.ElementAt(i);
                GCodeLine pointBefore = gCodeLines.ElementAt(i - 1);
                GCodeLine pointAfter = gCodeLines.ElementAt(i + 1);

                if (!IsInLine(currentPoint, pointBefore, tolerance) || !IsInLine(currentPoint, pointAfter, tolerance))
                {
                    Console.WriteLine($"Point {currentPoint.LineNumber} is out of line with its neighbors.");
                    linesWithErrors.Add(currentPoint.LineNumber);
                }
            }
            return linesWithErrors;
        }
        /// <summary>
        /// Checks wether or not two points are out of tolerance
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        private static bool IsInLine(GCodeLine point1, GCodeLine point2, double tolerance)
        {            
            Point3D p1 = new Point3D(point1.X, point1.Y, point1.Z);
            Point3D p2 = new Point3D(point2.X, point2.Y, point2.Z);
             
            if (p1 == new Point3D() || p2 == new Point3D())
            {
                return true;
            }
            else
            {               
                double distance = p1.DistanceTo(p2);
                return distance <= tolerance;
            }            
        }
    }
}
