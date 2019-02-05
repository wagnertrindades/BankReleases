using BankRelease.Domain.Entity;
using BankRelease.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankRelease.Infrastructure.Client
{
    public class AccountHttpClient : IAccountClient
    {
        public HttpClient Client { get; }

        public AccountHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }

        public async Task<Uri> CheckingAccountDebit(TransferRelease transferRelease)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                $"api/checking-account/{transferRelease.OriginAccount}/debit", transferRelease);

            if(response.IsSuccessStatusCode)
            {
                return response.Headers.Location;
            }

            var contents = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(contents);
        }

        public async Task<Uri> CheckingAccountCredit(TransferRelease transferRelease)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                $"api/checking-account/{transferRelease.DestinationAccount}/credit", transferRelease);

            if (response.IsSuccessStatusCode)
            {
                return response.Headers.Location;
            }

            var contents = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(contents);
        }
    }
}
