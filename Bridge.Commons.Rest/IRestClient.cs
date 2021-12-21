using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Bridge.Commons.Rest
{
    /// <summary>
    /// Rest Client
    /// </summary>
    public interface IRestClient
    {
        #region GET
        
        /// <summary>
        /// Buscar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Get<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Buscar (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> GetAsync<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new();
        
        #endregion
        
        #region POST

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Post<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PostAsync<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Post<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PostAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new();

        /// <summary>
        /// Postar informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Post<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Postar informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PostAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new();
        
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
        IRestResponse<TOutput> Delete<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null)
            where TOutput : new();
        
        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Delete<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Deletar assíncrono
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> DeleteAsync<TOutput>(string endpoint, object queryParameters = null,
            IDictionary<string, string> headers = null) where TOutput : new();

        /// <summary>
        /// Deletar assíncrono
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> DeleteAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new();
        
        #endregion
        
        #region PUT

        /// <summary>
        /// Colocar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Put<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Colocar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PutAsync<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Colocar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Put<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Colocar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PutAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null)
            where TOutput : new();
        
        /// <summary>
        /// Colocar
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Put<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Colocar (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PutAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null)
            where TOutput : new();
        
        #endregion
        
        #region PATCH
        
        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Patch<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Patch de informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PatchAsync<TOutput>(string endpoint, IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Patch de Informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Patch<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Patch de Informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="queryParameters"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PatchAsync<TOutput>(string endpoint, object queryParameters,
            IDictionary<string, string> headers = null) where TOutput : new();

        /// <summary>
        /// Patch de informações
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        IRestResponse<TOutput> Patch<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null)
            where TOutput : new();

        /// <summary>
        /// Patch de informações (assíncrono)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        Task<IRestResponse<TOutput>> PatchAsync<TInput, TOutput>(string endpoint, TInput body,
            IDictionary<string, string> headers = null) where TOutput : new();
        
        #endregion
    }
}