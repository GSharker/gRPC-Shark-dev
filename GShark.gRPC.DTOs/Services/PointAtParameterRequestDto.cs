using GShark.gRPC.DTOs.Core;
using System.Collections.Generic;

namespace GShark.gRPC.DTOs.Services
{
    public class PointAtParameterRequestDto
    {
        public IEnumerable<Point3Dto> Points { get; set; }
        public IEnumerable<double> PointWeights { get; set; }
        public int Degree { get; set; }
        public double Parameter { get; set; }
    }
}
