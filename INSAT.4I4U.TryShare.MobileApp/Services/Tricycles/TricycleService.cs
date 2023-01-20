using INSAT._4I4U.TryShare.MobileApp.Helpers;
using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Dto;
using INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.RequestProvider;

namespace INSAT._4I4U.TryShare.MobileApp.Services.Tricycles
{
    /// <summary>
    /// Service to access the data on Tricycles
    /// </summary>
    public class TricycleService : ITricycleService
    {
        private readonly IRequestProvider _requestProvider;
        private const string apiUrlTricycle = "api/Tricycles";
        private static bool IsConnectedInternet => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public TricycleService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        /// <summary>
        /// Gets the tricycles asynchronously.
        /// </summary>
        /// <returns>A List of Tricycles if the client is connected to the Internet</returns>
        /// <exception cref="NotImplementedException">Offline functionality not implemented</exception>
        public async Task<List<Tricycle>> GetTricyclesAsync()
        {
            if (IsConnectedInternet)
            {
                var uri = UriHelper.CombineUri(GlobalSettings.DefaultEndpoint, $"{apiUrlTricycle}");

                var dtos =  await _requestProvider.GetAsync<List<TricycleDto>>(uri);
                if (dtos is null)
                    throw new InvalidOperationException("Tricycles DTOs should not be null");

                foreach (TricycleDto tricycle in dtos)
                {
                    if (tricycle.IsAvailable is false)
                    {
                        dtos.Remove(tricycle);
                    }
                }
                return dtos.Select(dto => dto.ToModel()).ToList();
            }
            else
            {
                throw new NotImplementedException("Offline functionality not implemented");
            }
        }
    }
}
