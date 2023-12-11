namespace SGCA.DataAcces.GCode
{

    public class GCodeLine
    {
        public string CommandType { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double F { get; set; }
        public double E { get; set; }
        public int LineNumber { get; set; }

        public override string ToString()
        {
            return $"{CommandType} X{X} Y{Y} Z{Z} F{F} E{E} LineNumber {LineNumber}";
        }

    }

}
