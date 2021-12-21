using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Bridge.Commons.Rest
{
    /// <summary>
    /// 
    /// </summary>
    public class RestClient : IRestClient
    {
        #region ATTRIBUTES

        private readonly JsonSerializerSettings _jsonSettings;
        private readonly RestSharp.RestClient _restClient;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="dateFormatHandling"></param>
        public RestClient(string baseUrl = null,
            DateFormatHandling dateFormatHandling = DateFormatHandling.IsoDateFormat)
        {
            _restClient = string.IsNullOrWhiteSpace(baseUrl) == false
                ? new RestSharp.RestClient(baseUrl)
                : new RestSharp.RestClient();

            _jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = dateFormatHandling
            };
        }

        #endregion

        #region GET

        /// <summary>
        /// Buscar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Get<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = new RestRequest(endpoint);
            SetHeadersAndQueryParameters(ref request, queryParameters, headers);
            var response = _restClient.Get<TOutput>(request);
            return response;
        }

        /// <summary>
        /// Buscar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> GetAsync<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = new RestRequest(endpoint);
            var cancellationTokenSource = new CancellationTokenSource();
            SetHeadersAndQueryParameters(ref request, queryParameters, headers);
            var response = await _restClient.ExecuteGetAsync<TOutput>(request, cancellationTokenSource.Token);
            return response;
        }

        #endregion

        #region POST

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Post<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.POST, headers);
            return _restClient.Post<TOutput>(request);
        }

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PostAsync<TOutput>(string endpoint,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.POST, headers);
            return await _restClient.ExecutePostAsync<TOutput>(request);
        }

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Post<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.POST, headers);
            return _restClient.Post<TOutput>(request);
        }

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PostAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.POST, headers);
            return await _restClient.ExecutePostAsync<TOutput>(request);
        }

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Post<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.POST, headers);
            return _restClient.Post<TOutput>(request);
        }

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PostAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.POST, headers);
            return await _restClient.ExecutePostAsync<TOutput>(request);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Delete<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.DELETE, headers);
            return _restClient.Delete<TOutput>(request);
        }

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Delete<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.DELETE, headers);
            return _restClient.Delete<TOutput>(request);
        }

        /// <summary>
        /// Deletar (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> DeleteAsync<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.DELETE, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        /// <summary>
        /// Deletar (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> DeleteAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.DELETE, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        #endregion

        #region PUT

        /// <summary>
        /// Colocar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Put<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.PUT, headers);
            return _restClient.Post<TOutput>(request);
        }

        /// <summary>
        /// Colocar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PutAsync<TOutput>(string endpoint,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.PUT, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        /// <summary>
        /// Colocar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Put<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.PUT, headers);
            return _restClient.Put<TOutput>(request);
        }

        /// <summary>
        /// Colocar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PutAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.PUT, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        /// <summary>
        /// Colocar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Put<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.PUT, headers);
            return _restClient.Put<TOutput>(request);
        }

        /// <summary>
        /// Colocar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PutAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.PUT, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }
        
        #endregion
        
        #region PATCH

        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Patch<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.PATCH, headers);
            return _restClient.Patch<TOutput>(request);
        }

        /// <summary>
        /// Patch de informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PatchAsync<TOutput>(string endpoint,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, null, Method.PATCH, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Patch<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.PATCH, headers);
            return _restClient.Patch<TOutput>(request);
        }

        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PatchAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, false, queryParameters, Method.PATCH, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public IRestResponse<TOutput> Patch<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.PATCH, headers);
            return _restClient.Patch<TOutput>(request);
        }

        /// <summary>
        /// Patch de informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public async Task<IRestResponse<TOutput>> PatchAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new()
        {
            var request = GetRequest(endpoint, true, body, Method.PATCH, headers);
            return await _restClient.ExecuteAsync<TOutput>(request);
        }

        #endregion

        #region PRIVATE

        private static void SetHeadersAndQueryParameters(ref RestRequest request, object queryParameters = null,
            IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var entry in headers)
                    request.AddHeader(entry.Key, entry.Value);

            if (queryParameters == null) return;
            {
                IList<PropertyInfo> properties = new List<PropertyInfo>(queryParameters.GetType().GetProperties());
                foreach (var property in properties)
                {
                    var parameterName = property.Name;
                    var parameterValue = property.GetValue(queryParameters);
                    switch (parameterValue)
                    {
                        case null:
                            continue;
                        case Array _:
                        {
                            foreach (var entry in (Array) parameterValue)
                                request.AddQueryParameter(parameterName, entry.ToString());
                            break;
                        }
                        default:
                            request.AddQueryParameter(parameterName, parameterValue.ToString());
                            break;
                    }
                }
            }
        }

        private RestRequest GetRequest(string endpoint, bool hasBody, object parameters, Method method,
            IDictionary<string, string> headers = null)
        {
            var request = new RestRequest(endpoint, method);

            if(hasBody)
                SetHeadersAndQueryParameters(ref request, null, headers);
            else
                SetHeadersAndQueryParameters(ref request, parameters, headers);

            if (parameters == null) return request;

            var jsonData = JsonConvert.SerializeObject(parameters, _jsonSettings);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            return request;
        }

        #endregion
    }
}