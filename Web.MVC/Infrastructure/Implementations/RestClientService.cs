using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.MVC.Infrastructure.Interfaces;

namespace Web.MVC.Infrastructure.Implementations
{
    public sealed class RestClientService : IRestClientService
    {
        private readonly HttpClient httpClient;
        private string result = "Error";

        public RestClientService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string requestUri, Dictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient, additionalHeaders);
                        result = await httpClient.GetStringAsync(requestUri);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Post Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        public async Task<string> PostAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            try
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient, additionalHeaders);
                        result = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(request))
                        {
                            Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                        }).Result.Content.ReadAsStringAsync();
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Delete Async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(string requestUri, Dictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient, additionalHeaders);
                        var httpResponseMessage = await httpClient.DeleteAsync(requestUri);
                        result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Pust Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        public async Task<string> PutAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            try
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient, additionalHeaders);

                        var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            NullValueHandling = NullValueHandling.Ignore
                        });

                        var httpContent = new StringContent(json);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var httpResponseMessage = await httpClient.PutAsync(requestUri, httpContent);
                        result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Patch Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        public async Task<string> PatchAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            try
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient, additionalHeaders);

                        var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            NullValueHandling = NullValueHandling.Ignore
                        });

                        var httpContent = new StringContent(json);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var httpResponseMessage = await httpClient.PatchAsync(requestUri, httpContent);
                        result = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Add headers
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="additionalHeaders"></param>
        private void AddHeaders(HttpClient httpClient, Dictionary<string, string> additionalHeaders)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            if (additionalHeaders == null)
                return;

            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }
    }
}
