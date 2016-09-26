using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace IneqWebApp.Data
{
        public abstract class DataBase<T>
        {
            public string BaseAddress
            {
                get { return ConfigurationManager.AppSettings["baseAddress"]; }
            }

            public abstract string BaseCatalog
            {
                get;
            }

            public virtual async Task<bool> Insert(T model)
            {
                return await Save(model, false);
            }

            public virtual async Task<bool> Update(T model)
            {
                return await Save(model, true);
            }

            public virtual async Task<bool> Save(T model, bool isUpdate)
            {
                try
                {
                    string bodyString = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(bodyString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (var client = new HttpClient())
                    {
                        InitializeHttpClient(client);
                        //GetToken(client);
                        HttpRequestMessage request = new HttpRequestMessage(isUpdate ? HttpMethod.Put : HttpMethod.Post, BaseAddress + BaseCatalog);
                        request.Content = content;
                        HttpResponseMessage response;
                        if (isUpdate)
                        {
                            response = await client.PutAsync(BaseAddress + BaseCatalog + "Put", content).ConfigureAwait(continueOnCapturedContext: false);
                        }
                        else
                        {
                            response = await client.PostAsync(BaseAddress + BaseCatalog + "Post", content).ConfigureAwait(continueOnCapturedContext: false);
                        }
                        return response.IsSuccessStatusCode;
                    }
                }
                catch { return false; }
            }

            public virtual async Task<List<T>> Get()
            {
                try
                {
                    List<T> result = new List<T>();

                    using (var client = new HttpClient())
                    {
                        InitializeHttpClient(client);
                        //GetToken(client);
                        HttpResponseMessage response = await client.GetAsync(BaseCatalog + "GetAll").ConfigureAwait(continueOnCapturedContext: false);
                        if (response.IsSuccessStatusCode)
                        {
                            result = await response.Content.ReadAsAsync<List<T>>();
                        }
                    }

                    return result;
                }
                catch
                {
                    throw new ApplicationException(Util.Constant.THROW_EX_BO_UNAUTHORIZED);
                }
            }

            public virtual async Task<List<T>> Get(string action, string parameters)
            {
                try
                {

                    var client = new HttpClient();
                    InitializeHttpClient(client);
                    //GetToken(client);
                    List<T> result = new List<T>();

                    HttpResponseMessage response = await client.GetAsync(BaseCatalog + action + parameters).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<List<T>>();
                    }

                    return result;
                }
                catch
                {
                    throw new ApplicationException(Util.Constant.THROW_EX_BO_UNAUTHORIZED_ERROR);
                }
            }

            private void InitializeHttpClient(HttpClient client)
            {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
