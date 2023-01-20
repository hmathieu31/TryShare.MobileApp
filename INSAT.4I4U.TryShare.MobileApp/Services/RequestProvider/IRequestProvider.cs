using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult?> GetAsync<TResult>(Uri uri, string token = "");
        
        Task<TResult?> PostAsync<TResult>(Uri uri, TResult data, string token = "", string header = "", bool shouldReturnContent = false);
        
        Task<TResult?> PostAsync<TResult>(Uri uri, string data, string clientId, string clientSecret);

        Task<TResult?> PutAsync<TResult>(Uri uri, TResult data, string token = "", string header = "");

        Task DeleteAsync(Uri uri, string token = "");
    }
}
