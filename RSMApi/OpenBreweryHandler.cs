using Newtonsoft.Json.Linq;
using RSMModels.Variables;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace RSMApi
{
    public class OpenBreweryHandler
    {
        public async Task<JToken?> QueryRandomBrewery()
        {
            try
            {
                string response = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetStringAsync(Urls.RandomBrewery);
                }
                return string.IsNullOrEmpty(response) ? null : JToken.Parse(response);
            }
            catch (HttpRequestException e)
            {
                // Add logging?
                return null;
            }
        }

        public async Task<JToken?> QuerySingleBrewery(string? obdbid)
        {
            if (obdbid == null)
            {
                await QueryRandomBrewery();
            }
            try
            {
                string response = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetStringAsync($"{Urls.OpenBreweryApi}/{obdbid}");
                }
                return string.IsNullOrEmpty(response) ? null : JToken.Parse(response);
            }
            catch (HttpRequestException e)
            {
                // Add logging?
                return null;
            }
        }

        public async Task<JToken?> QueryBreweryByCity(string city, int perPage)
        {
            // Max per page is 50 results.
            if (perPage > 50)
            {
                perPage = 50;
            }
            // Zero per page would return nothing of value so lets ensure we get something useful back.
            if (perPage <= 0)
            {
                perPage = 1;
            }

            city = city.ToLower().Replace(' ','_');

            try
            {
                string response = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetStringAsync($"{Urls.OpenBreweryApi}/?by_city={city}&per_page={perPage}");
                }
                return string.IsNullOrEmpty(response) ? null : JToken.Parse(response);
            }
            catch (HttpRequestException e)
            {
                // Add logging?
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="single">If null, method will assume multiple. If not null, method will only search for specific brewery using the ObDbid. https://api.openbrewerydb.org/breweries/{obdb-id}, otherwise https://api.openbrewerydb.org/breweries</param>
        /// <param name="perPage">Number of breweries to return each call. If null, method will default to 50.</param>
        /// <param name="byCity">Filter breweries by city.</param>
        /// <param name="byDist">Sort the results by distance from an origin point, denoted by latitude,longitude. Ex: https://api.openbrewerydb.org/breweries?by_dist=38.8977,77.0365</param>
        /// <param name="byName"></param>
        /// <param name="byState"></param>
        /// <param name="byPostal">May be filtered by basic (5 digit) postal code or more precisely filtered by postal+4 (9 digit) code.</param>
        /// <returns></returns>
        //private async Task<JToken?> QueryOpenBreweryApi(string? single, bool? random, int? perPage, string? byCity, string? byDist, string? byName, string? byState, string? byPostal)
        //{
        //    // https://api.openbrewerydb.org/breweries
        //    StringBuilder urlBuilder = new StringBuilder(Urls.OpenBreweryApi);

        //    if (single != null)
        //    {
        //        urlBuilder.Append($"/{single}");
        //    }
        //    if (random != null && random == true)
        //    {
        //        urlBuilder.Append($"/random");
        //    }
        //    if (byCity != null)
        //    {
        //        urlBuilder.Append($"?by_city={byCity}");
        //    }
        //    if (perPage != null)
        //    {
        //        urlBuilder.Append($"&per_page={perPage}");
        //    }
        //    else
        //    {
        //        urlBuilder.Append($"&per_page=50");
        //    }
        //    if (byDist != null)
        //    {
        //        urlBuilder.Append($"&per_page=50");
        //    }
        //    if (byName != null)
        //    {
        //        urlBuilder.Append($"&per_page=50");
        //    }
        //    if (byState != null)
        //    {
        //        urlBuilder.Append($"&per_page=50");
        //    }
        //    if (byPostal != null)
        //    {
        //        urlBuilder.Append($"&per_page=50");
        //    }

        //    try
        //    {
        //        string response = string.Empty;
        //        using (HttpClient client = new HttpClient())
        //        {
        //            response = await client.GetStringAsync(new Uri(urlBuilder.ToString()));
        //        }
        //        return string.IsNullOrEmpty(response) ? null : JToken.Parse(response);
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        // Add logging?
        //        return null;
        //    }
        //}
    }
}
