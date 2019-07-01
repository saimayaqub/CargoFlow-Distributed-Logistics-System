using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.APIMessages;

namespace Web.Helper
{
    public class GetEntityHelper
    {
        public static List<Operator> GetEntityList(string entityType)
        {
            var resultList = new List<Operator>();
            var client = new HttpClient();
            try
            {
                string requestUri = string.Format("https://localhost:44333/api/{0}s", entityType);
                var getDataTask = client.GetAsync(requestUri)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (response.IsCompletedSuccessfully)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Operator>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error: " + ex.Message);
            }
            return resultList;
        }

        //Get Operator details (w.r.t. id) by calling API
        public static Operator GetEntityDetailsById(int id, string entityType)
        {
            var objOperator = new Operator();
            var client = new HttpClient();
            string requestUri = string.Format("https://localhost:44333/api/{0}s/{1}", entityType, id);
            try
            {
                var getDataTask = client.GetAsync(requestUri)
                    .ContinueWith(response =>
                    {

                        var result = response.Result;
                        if (response.IsCompletedSuccessfully)
                        {
                            var readResult = result.Content.ReadAsAsync<Operator>();
                            readResult.Wait();
                            objOperator = readResult.Result;
                        }
                    });
                getDataTask.Wait();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error: " + ex.Message);
                throw ex;
            }
            return objOperator;
        }
    }
}


