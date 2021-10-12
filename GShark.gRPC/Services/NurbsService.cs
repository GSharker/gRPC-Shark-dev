using Grpc.Core;
using GShark.gRPC.DTOs.Core;
using GShark.gRPC.DTOs.Services;
using GShark.gRPC.Methods;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace GShark.gRPC.Services
{
    public class NurbsGeometryService : NurbsService.NurbsServiceBase
    {
        public override Task<PointAtParameterResponse> QueryPointAtParameter(PointAtParameterRequest request, ServerCallContext context)
        {
            var requestDto = new PointAtParameterRequestDto
            {
                Degree = request.Degree,
                Points = request.Points.Select(p => new Point3Dto(p.X, p.Y, p.Z)),
                PointWeights = request.PointWeights,
                Parameter = request.Parameter
            };
            PointAtParameterResponseDto responseDto = NurbsServiceMethods.QueryPointAtParameter(requestDto);
            return Task.FromResult(ToMessage(responseDto));

        }

        private static PointAtParameterResponse ToMessage(PointAtParameterResponseDto responseDto)
        {
            var response = new PointAtParameterResponse
            {
                Point = new Point3
                {
                    X = responseDto.Point.X,
                    Y = responseDto.Point.Y,
                    Z = responseDto.Point.Z
                }
            };

            return response;
        }
    }
}
