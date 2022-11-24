using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RSMModels.Models.Brewery;
using System.Collections.Generic;
using RSMModels.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RSMModels.Variables;
using System.Text;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using RSMModels.Models.City;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using RSMModels.Models.State;
using RSMModels.Models.Country;

namespace RSMApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreweryController : ControllerBase
    {
        private readonly RSMDbContext _db;
        private readonly ILogger<BreweryController> _logger;
        private readonly OpenBreweryHandler _openBreweryApi;

        public BreweryController(RSMDbContext db, ILogger<BreweryController> logger, OpenBreweryHandler openBreweryApi)
        {
            _db = db;
            _logger = logger;
            _openBreweryApi = openBreweryApi;
        }

        /// <summary>
        /// Create example. Unused in SPA.
        /// </summary>
        /// <param name="brewery"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/StoreBrewery")]
        public async Task StoreBrewery(Brewery brewery)
        {

        }

        /// <summary>
        /// Read example. Unused by SPA.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetBrewery")]
        [Produces("application/json")]
        public async Task GetBrewery(int id)
        {

        }

        /// <summary>
        /// Update Example. Unused in the SPA.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("/Update")]
        public async Task UpdateBrewery(int id)
        {

        }

        /// <summary>
        /// Delete Example. Unused in the SPA.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/DeleteById")]
        public async Task DeleteBreweryById(int id)
        {

        }

        //private int ConvertModel(string? city, string? state, string? country)
        //{
        //    //List<Country> countries = this._db.Countries.Where(x => x.Name == country).ToList();
        //    List<City> cities = this._db.Cities.Where(x => x.Name == city).ToList();

        //    // If there are more than one result for the name of the city, filter request starting with the state.
        //    if (cities.Count > 1) 
        //    {

        //        if (state != null)
        //        {
        //            List<State> states = this._db.States.Where(x => x.Name == state).ToList();
        //            // Found match
        //            if (states.Count == 1)
        //            {
        //                foreach (City dbCities in cities)
        //                {
        //                    if ()
        //                }
        //            }
        //        }

                
        //        if (cities.Count > 1)
        //        {
        //            return cities.FirstOrDefault().Id;
        //        }
        //        return cities.FirstOrDefault().Id;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}