using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.APIMessages;

namespace Web.Controllers
{
    public class AspNetUsersController : Controller
    {
        public IActionResult Index()
        {
            var aspUsers = GetUsersFromAPI();
            return View(aspUsers);
        }

        private List<AspNetUsers> GetUsersFromAPI()
        {
            var resultList = new List<AspNetUsers>();
            var client = new HttpClient();
            try
            {
                var getDataTask = client.GetAsync("https://localhost:44333/api/AspNetUsers")
                    .ContinueWith( response =>
                    {
                        var result = response.Result;
                        if (response.IsCompletedSuccessfully)
                        {
                            var readResult = result.Content.ReadAsAsync<List<AspNetUsers>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                        
                    });
                getDataTask.Wait();
                //return resultList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                //throw ex;
            }
            return resultList;
        }
    }
}