﻿using MaratonaXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MaratonaXamarin.Services
{
    public class VargolaService : IVargolaService
    {
        //private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";
        private const string BaseUrl = "https://vargola-mobile-app.azurewebsites.net/api/";

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tag>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }

        public async Task<List<Content>> GetContentsByTagIdAsync(string tagId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync($"{BaseUrl}Content/tag?tag={tagId}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Content>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }

        public async Task<List<Content>> GetContentsByFilterAsync(string filter)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync($"{BaseUrl}Content/search?filter={Uri.EscapeUriString(filter)}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Content>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }
    }
}
