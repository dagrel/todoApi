using System;
using System.Net.Http;
using System.Threading.Tasks;
using dipsApi;
using Newtonsoft.Json;
using DipsApi.Models;
using Xunit;

namespace DipsApiTesting
{
    public class BloodpressureTests : IClassFixture<TestApi<Startup>>
    {
        private HttpClient Client;

        public BloodpressureTests(TestApi<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetMeasurements()
        {
            // Arrange
            var request = "/api/measurements";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetStockItemAsync()
        {
            // Arrange
            var request = "/api/measurements/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/measurements",
                Body = new
                {
                    // new id
                    // underPressure
                    // overPressure
                    // date
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
