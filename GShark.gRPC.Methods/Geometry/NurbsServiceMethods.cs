using GShark.Geometry;
using GShark.gRPC.DTOs.Core;
using GShark.gRPC.DTOs.Services;
using System;
using System.Linq;

namespace GShark.gRPC.Methods
{
    public class NurbsServiceMethods
    {
        public static Func<PointAtParameterRequestDto, PointAtParameterResponseDto> QueryPointAtParameter = (request) =>
        {
            var nurbs = new NurbsCurve(
                points: request.Points.Select(p => new Point3(p.X, p.Y, p.Z)).ToList(),
                weights: request.PointWeights.ToList(),
                degree: request.Degree
            );
            var pointAtParameter = nurbs.PointAt(request.Parameter);
            return new PointAtParameterResponseDto
            {
                Point = new Point3Dto(pointAtParameter.X, pointAtParameter.Y, pointAtParameter.Z)
            };
        };
    }
}
