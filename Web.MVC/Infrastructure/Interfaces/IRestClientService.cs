using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.MVC.Infrastructure.Interfaces
{
    public interface IRestClientService
    {
        Task<string> GetAsync(string requestUri, Dictionary<string, string> additionalHeaders = null);
        Task<string> PostAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class;
        Task<string> DeleteAsync(string requestUri, Dictionary<string, string> additionalHeaders = null);
        Task<string> PutAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class;
        Task<string> PatchAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class;
    }
}
