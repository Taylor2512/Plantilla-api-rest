using DOMAIN.Helper.Enums.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Helper.Tools.Interfaces
{
    /// <summary>
    /// Adaptador de tienda de contifico 
    /// utilizado para registrar las tienda de metodos que se utiliza en la applicacion
    /// </summary>
    public interface ITools
    {

        /// <summary>
        /// metodo de sobrescritura  que permite realizar peticiones http de forma generica
        /// en la cual se indican el tipo de peticion url y configuracion de tipo de autentica
        /// metodo generico para multiples solicitudes convalores de resultado varios se obtiene un valor
        /// del tipo que se especifique
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methttp"></param>
        /// <param name="url"></param>
        /// <param name="acces_token"></param>
        /// <returns></returns>

        public static async Task<T?> PostJsonAllAscyn<T>(Methttp methttp, string url, string? acces_token)
        {
            return await PostJsonAllAscyn<T>(methttp, url, acces_token, string.Empty);
        }
        public static async Task<T?> PostJsonAllAscyn<T>(Methttp methttp, string url, string? acces_token, string? Schema)
        {
            return await PostJsonAllAscyn<T>(methttp, url, acces_token, Schema, new object());
        }
        public static async Task<T?> PostJsonAllAscyn<T>(Methttp methttp, string url, string? acces_token, string? Schema, object obj)
        {
            try
            {
                T? resultObj = default;

                var jsonObj = await obj.SerializarObjectjson();
                if (jsonObj == null) throw new Exception($"ingresado objeto es null {url}").InnerException;
                Tools.client = new System.Net.Http.HttpClient();
                Tools.client.Timeout = TimeSpan.FromMinutes(10);
                if (!(string.IsNullOrEmpty(acces_token) && string.IsNullOrEmpty(Schema)))
                {
                    Tools.client.DefaultRequestHeaders.Authorization = !string.IsNullOrEmpty(Schema) ?
                                      new AuthenticationHeaderValue(Schema, acces_token) : new AuthenticationHeaderValue(acces_token);
                }

                Tools.httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpResponseMessage();
                response = await methttp.EvalueMethtpp(url, Tools.httpContent, Tools.client);

                if (response != null)
                {
                    Tools.content = response.Content;
                    var a = await Tools.content.ReadAsStringAsync();

                    await Tools.SetValoresNull();
                    if (string.IsNullOrEmpty(a))
                    {
                        Tools.mensajeError += "respuesta vacia";
                        return default;

                    }

                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                    {
                        resultObj = await Tools.DeserializarJsonAobjeto<T>(a);
                        a = a.Replace("/", string.Empty);
                        var h = typeof(T);

                        a = null;
                        return resultObj;

                    }
                    else
                    {

                        //ErrorResponse.messageReponse = await Tools.DeserializarJsonAobjeto<MessageReponse>(a);
                        return default;

                    }


                }
                Tools.mensajeError = Tools.mensajeError + " respuesta null";

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return default;
        }
        public static async Task<HttpResponseMessage> PostJsonAllAscyn(object obj, string acces_token, string url, string Schema, Methttp methttp)
        {
            try
            {

                var jsonObj = await obj.SerializarObjectjson();
                if (jsonObj == null) throw new Exception($"ingresado objeto es null {url}").InnerException;
                Tools.client = new System.Net.Http.HttpClient();
                Tools.client.Timeout = TimeSpan.FromMinutes(2);
                Tools.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Schema, acces_token);
                Tools.httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                response = await methttp.EvalueMethtpp(url, Tools.httpContent, Tools.client);

                return response;
            }
            catch (Exception e)
            {
                return default;
            }
        }





    }
}
