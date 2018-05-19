﻿using MagicMirror.DataAccess.Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public abstract class Repository<T> where T : Entity
    {
        protected string _apiId;
        protected string _apiUrl;
        protected string _url;

        protected virtual void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_apiId)) { throw new ArgumentNullException("An apiKey has to be provided"); }
            if (string.IsNullOrWhiteSpace(_apiUrl)) { throw new ArgumentNullException("An apiUrl has to be provided"); }
        }

        protected async Task<HttpResponseMessage> GetHttpResponseMessageAsync()
        {
            var client = new HttpClient();

            HttpResponseMessage message = await client.GetAsync(_url);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot connect to api: {message.StatusCode} {message.ReasonPhrase}");
            }

            return message;
        }

        protected async Task<T> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Cannot convert from entity", e);
            }
        }
    }
}