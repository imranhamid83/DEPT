using DEPT.DAL.Interfaces;
using DEPT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DEPT.Services
{
    public class CountryService
    {

        public async Task<List<Country>> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            using (var client = new HttpClient())
            {
                // add url into appsettings
                client.BaseAddress = new Uri("https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("v2/countries");
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic apiResponse = JsonConvert.DeserializeObject(jsonString);
                    var results = apiResponse.results;

                    foreach(var country in results)
                    {
                        countries.Add(new Country()
                        {
                            Code = country.GetValue("code"),
                            Name = country.GetValue("name")

                        });
                    }
                }
                return countries;
            }

        }

        public async Task<Country> GetCountryByCode(string Code)
        {
            Country country = new Country();
            using (var client = new HttpClient())
            {
                // add url into appsettings
                client.BaseAddress = new Uri("https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("v2/countries/"+ Code);
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic apiResponse = JsonConvert.DeserializeObject(jsonString);
                    var results = apiResponse.results;

                    foreach (var result in results)
                    {
                        country.Code = result.GetValue("code");
                        country.Name = result.GetValue("name");
                        country.Count = result.GetValue("count");
                        country.Cities = result.GetValue("cities");
                    }
                }
                return country;
            }

        }

    }
}
