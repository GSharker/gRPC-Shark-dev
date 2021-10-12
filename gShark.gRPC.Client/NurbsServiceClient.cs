using Grpc.Net.Client;
using GShark.gRPC;
using GShark.gRPC.DTOs.Core;
using GShark.gRPC.DTOs.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace gShark.gRPC.Client
{
    public class NurbsServiceClient : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly NurbsService.NurbsServiceClient _service;

        public NurbsServiceClient(string host)
        {
            _ = host ?? throw new ArgumentNullException(nameof(host), "Host can't be null");
            _channel = GrpcChannel.ForAddress(host);
            _service = new NurbsService.NurbsServiceClient(_channel);
        }

        public async Task<PointAtParameterResponseDto> QueryPointAtParameter(PointAtParameterRequestDto request)
        {
            Point3[] points = request
                .Points
                .Select(p => new Point3
                {
                    X = p.X,
                    Y = p.Y,
                    Z = p.Z
                })
                .ToArray();

            var grpcRequest = new PointAtParameterRequest();

            grpcRequest.Degree = request.Degree;
            grpcRequest.Points.AddRange(points);
            grpcRequest.PointWeights.AddRange(request.PointWeights);

            var response = await _service.QueryPointAtParameterAsync(grpcRequest);

            return new PointAtParameterResponseDto()
            {
                Point = new Point3Dto(response.Point.X, response.Point.Y, response.Point.Z)
            };
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}
