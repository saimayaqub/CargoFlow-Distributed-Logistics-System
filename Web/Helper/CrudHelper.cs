using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.APIMessages;

namespace Web.Helper
{
    public class CrudHelper
    {
        public static async void ProcessCrud(int id, Operator op, string CrudType, string entityType)
        {
            try
            {
                var client = new HttpClient();
                string requestUri = "https://localhost:44333/api/" + entityType + "/";
                switch (CrudType)
                {
                    case "create":
                        op.RevLogUser.MemberSince = DateTime.Now;
                        var response = await client.PostAsJsonAsync(requestUri, op);
                        response.EnsureSuccessStatusCode();
                        break;
                    case "update":
                        op.OperatorId = id;
                        requestUri = string.Format(requestUri + "{0}/", id);
                        response = await client.PutAsJsonAsync(string.Format(requestUri, id), op);
                        response.EnsureSuccessStatusCode();
                        break;
                    case "delete":
                        requestUri = string.Format(requestUri + "{0}/", id);
                        response = await client.DeleteAsync(string.Format(requestUri, id));
                        response.EnsureSuccessStatusCode();
                        break;
                    default:
                        response = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RevLog Error: " + ex.Message);
                throw ex;
            }
        }
    }
}
