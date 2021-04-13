using DEPT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DEPT.Services
{
    public class DefaultService
    {
        
        [HttpGet]
        public async Task<string> ShakeHands()
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                // add url into appsettings
               
                client.BaseAddress = new Uri("https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("ping");
                if (response.IsSuccessStatusCode)
                {
                    
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;

        }

    }
}

