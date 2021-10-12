namespace GShark.gRPC.DTOs.Core
{
    public class Point3Dto
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3Dto(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
