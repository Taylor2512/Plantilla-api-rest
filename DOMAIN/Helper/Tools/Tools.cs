using AutoMapper;
using DOMAIN.Helper.Enums.HttpClients;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DOMAIN.Helper.Tools
{
    public static class Tools
    {
        public static StringContent httpContent;
        public static HttpClient client { set; get; }
        public static HttpContent content { set; get; }
        public static HttpResponseMessage response { set; get; }


        public static string mensajeError { set; get; }

        public static async Task SetValoresNull()
        {
            Tools.httpContent = null;
            Tools.client = null;
            Tools.content = null;
            Tools.content = null;


        }

        // se crea archivos por Fttp//

        public static string nameIndex(this string s)
        {
            return $"IX_{s}";
        }
        public static string ToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }
        public static async Task<double> RoundDoubleEnd(this double encontrado)
        {
            var h = Math.Truncate(Math.Abs(encontrado)).ToString(CultureInfo.InvariantCulture).Length;
            int ente = encontrado.ToString().Replace(".", "").Replace(",", "").Replace("-", "").Length;
            ente = ente - h;
            encontrado = Convert.ToDouble(decimal.Round((decimal)encontrado, ente - 1));
            return encontrado;
        }
        public static async Task<double> RoundDoubleEnd(this double encontrado, int cantidad)
        {
            return encontrado = Convert.ToDouble(decimal.Round((decimal)encontrado, cantidad));
        }
        public static async Task<string> SerializarObjectjson(this object obj)
        {
            try
            {

                return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async static Task<string> FirstCharToUpper(this Object objeto)
        {
            try
            {
                string input = objeto.ToString().ToLower() ?? throw new Exception();
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            catch { return string.Empty; }
        }
        public static async Task<T> DeserializarJsonAobjeto<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return default(T);
        }

        public static async Task<string> CodificaBase64(this string path)
        {
            var status = await path.ValidadrRutaHttps();


            if (status == HttpStatusCode.OK)
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(path);

                    using (MemoryStream mem = new MemoryStream(data))
                    {


                        return Convert.ToBase64String(mem.ToArray());

                    }
                }
            }
            else
            {

                return ((int)status).ToString();
            }



        }
        public async static Task<HttpStatusCode> ValidadrRutaHttps(this string @path)
        {
            try
            {
                WebRequest request = WebRequest.Create(path);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode;
            }
            catch (WebException ex)
            {

                return ((HttpWebResponse)ex.Response).StatusCode;
            }
        }
        public async static Task<string[]> SepararDosNombres(this string id)
        {


            string[] separado = id.Split(' ');

            string nombre = string.Empty;

            string apellido1 = separado[0];
            string apellido2 = separado[1];


            await separado.ForEachAsync(async e =>
            {
                if (!string.IsNullOrEmpty(e))
                {
                    nombre += e + " ";
                }

            });
            nombre = nombre.Trim();
            string[] separado2 = nombre.Split(' ');
            if ((separado2.Count() % 2) == 0)
            {
                apellido1 = separado2[0];
                apellido2 = separado2[1];
            }

            return separado2;

        }

        public static ArrayList NumbreRamdom(int RIni, int Rfin)
        {
            ArrayList numerosOrdenados = new ArrayList();
            ArrayList numerosDesordenados = new ArrayList();


            //Se llenan los numeros de forma ordenada
            for (int i = RIni; i < Rfin; i++)
            {
                numerosOrdenados.Add(i);
            }

            Random ran = new Random();

            //Se desorganizan
            while (numerosOrdenados.Count > 0)
            {
                int index = ran.Next(numerosOrdenados.Count);
                numerosDesordenados.Add(numerosOrdenados[index]);
                numerosOrdenados.RemoveAt(index);
            }
            return numerosDesordenados;
        }



        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            await ForEachAsync<T>(enumerable, action, true);
        }
        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action, bool boll = true)
        {
            foreach (var item in enumerable)
            {
                if (boll == true)
                {
                    await action(item);
                }
                else
                {
                    break;
                }

            }
        }

        public async static Task<DateTime> CalcularTiempoHoras(this int id)
        {
            return (DateTime.Now + (DateTime.Now - DateTime.Now.AddHours(id)));

        }
        public async static Task<DateTime> CalcularTiempoHorasUtcNow(this int id)
        {
            return (DateTime.UtcNow + (DateTime.UtcNow - DateTime.UtcNow.AddHours(id)));

        }



        public async static Task<bool> PruebasVarias(this byte[] imageBytes, string Fttp, string username, string password
         , string carpeta, string nombre_archivo, string extenxion)
        {
            try
            {
                //Crear Carpeta//

                FtpWebRequest FttpCrearDirectory = (FtpWebRequest)WebRequest.Create($"{Fttp}{carpeta}");
                FtpWebRequest FttpCrearArchivo = (FtpWebRequest)
                  WebRequest.Create($"{Fttp}{carpeta}{nombre_archivo}.{extenxion}");
                // reemplazar dirección ftp
                FttpCrearDirectory.Method = WebRequestMethods.Ftp.MakeDirectory;
                FttpCrearDirectory.Credentials =
                // reemplazar user y password
                new NetworkCredential(username, password);
                // se crea Directorio
                FtpWebResponse ftpResp = FttpCrearDirectory.GetResponse() as FtpWebResponse;
                //crear archivos//
                FttpCrearArchivo.Method = WebRequestMethods.Ftp.UploadFile;
                FttpCrearArchivo.Credentials =
                // reemplazar user y password
                new NetworkCredential(username, password);

                Stream ftpStream = FttpCrearArchivo.GetRequestStream();
                // se crea archivo
                ftpStream.Write(imageBytes, 0, imageBytes.Length);
                ftpStream.Close();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public async static Task<string> IsvalidBase64s(this string base64String)
        {
            if (base64String.Replace(" ", "").Length % 4 != 0)
            {
                return (" no es valido 1");
            }
            else
            {
                try
                {

                    Convert.FromBase64String(base64String);
                    return null;
                }
                catch (Exception exception)
                {
                    return ($"{exception}");
                }
            }

        }
        public async static Task<string> ObTenerExtenxionB64(this string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpeg";
                case "UklGR":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                case "PCFET":
                    return "mp3";
                default:
                    return string.Empty;
            }
        }
        public async static Task<string> obtenerCodigoError(this HttpStatusCode code)
        {
            object respuesta = null;
            switch (code)
            {
                case HttpStatusCode.NotFound:
                    respuesta = new
                    {
                        code = code,
                        message = "Pagina no encontrada"
                    };

                    return await respuesta.SerializarObjectjson();
                case HttpStatusCode.InternalServerError:
                    respuesta = new
                    {
                        code = code,
                        message = "Pagina no encontrada"
                    };

                    return await respuesta.SerializarObjectjson();

                default:
                    return string.Empty;
            }


        }


        public async static Task<string> Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public async static Task<string> Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public async static Task<bool> EscribirImagen(this string? base64, string? Ruta)
        {
            return await base64.EscribirImagen(null, Ruta);
        }


        public async static Task<bool> EscribirImagen(this string? base64, byte[]? arrayByte, string? Ruta)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64))
                {
                    arrayByte = Convert.FromBase64String(base64);
                    FileInfo fil = new FileInfo($"{Ruta}");

                    using (Stream sw = fil.OpenWrite())
                    {
                        sw.Write(arrayByte, 0, arrayByte.Length);
                        sw.Close();
                    }
                    return true;
                }
                else
                {
                    if (arrayByte != null)
                    {
                        arrayByte = Convert.FromBase64String(base64);
                        /* MemoryStream ms = new MemoryStream(arrayByte, 0, arrayByte.Length);
                         ms.Write(arrayByte, 0, arrayByte.Length);
                         Image image = Image.FromStream(ms, true);*/
                        FileInfo fil = new FileInfo($"{Ruta}");

                        using (Stream sw = fil.OpenWrite())
                        {
                            sw.Write(arrayByte, 0, arrayByte.Length);
                            sw.Close();
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void ValidarCrearRuta(this string Ruta)
        {
            if (!Directory.Exists(Ruta))
            {
                Directory.CreateDirectory(Ruta);
            }
        }
        public static void ValidarEliminarRuta(this string Ruta)
        {
            if (Directory.Exists(Ruta))
            {
                Directory.Delete(Ruta);
            }
        }





        public async static Task<HttpResponseMessage> EvalueMethtpp(this Methttp methttp, string url, HttpContent httpContent, HttpClient client)
        {
            return methttp switch
            {
                Methttp.POST => response = await client.PostAsync(url, httpContent),
                Methttp.GET => response = await client.GetAsync(url),
                Methttp.PUT => response = await client.PutAsync(url, httpContent),
                Methttp.DELETTE => response = await client.DeleteAsync(url),
                Methttp.PATCH => response = await client.PatchAsync(url, httpContent),
                Methttp.UNDEFINED => null,
            };

        }

        public async static Task<Methttp> GetevalueTypeScyn(this string meth)
        {
            return meth.ToUpper() switch
            {
                "POST" => Methttp.POST,
                "GET" => Methttp.GET,
                "DELETTE" => Methttp.DELETTE,
                "PUT" => Methttp.PUT,
                _ => Methttp.UNDEFINED

            };
        }
        public static Methttp GetevalueType(this string meth)
        {
            return meth.ToUpper() switch
            {
                "POST" => Methttp.POST,
                "GET" => Methttp.GET,
                "DELETTE" => Methttp.DELETTE,
                _ => Methttp.UNDEFINED

            };
        }

        public async static Task<decimal> SubtotalIva(this decimal precio, int iva)
        {
            return ((precio * iva) / 100);
        }
        public async static Task<decimal> CalcularPrecioFinal(this decimal precio, decimal descuento, int iva)
        {
            return await precio.CalcularPrecioFinal(descuento, iva, 0);
        }
        public async static Task<decimal> CalcularPrecioFinal(this decimal precio, decimal descuento, int iva, decimal adicion)
        {

            return ((precio + ((precio * iva) / 100)) - descuento) + adicion;
        }

        public static async void ConvertToVideo(this string base64data, byte[] arrayByte, string Ruta, string nombre_archivo, string extension)
        {
            try
            {
                // base64data = base64data.Replace("data:video/mp4;base64,", "");
                //   if (base64data.IsvalidBase64s()==null)
                // {
                arrayByte = Convert.FromBase64String(base64data);
                Ruta.ValidarCrearRuta();
                FileInfo fil = new FileInfo($"{Ruta}{nombre_archivo}.{extension}");
                using (Stream sw = fil.OpenWrite())
                {
                    sw.Write(arrayByte, 0, arrayByte.Length);
                    sw.Close();
                }
                //}
                // else
                //{
                //  Constants.mensa = "Base 64 no valido";

                //                }

            }
            catch (Exception e)
            {

            }


        }
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);
            foreach (var property in destinationProperties)
            { if (sourceType.GetProperty(property.Name, flags) == null) { expression.ForMember(property.Name, opt => opt.Ignore()); } }
            return expression;
        }



    }
}