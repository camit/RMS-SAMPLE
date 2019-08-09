using Newtonsoft.Json;
using RMSAPI;
using RMSAPI.Extensions;
using RMSAPI.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RMSIntegrationTest
{
   public class RMSAPITest : IClassFixture<RMSTestFixture<Startup>>
    {
        private HttpClient Client;

        public RMSAPITest(RMSTestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }
               

        [Fact]
        public async Task TestGetTrainingItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Trainings/1"
            };

            // Act
            var response = await Client.GetAsync(request.Url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostTrainingItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Trainings",
                Body = new
                {
                    Training_Name = "Test Post Training Item",
                    Training_Startdate = DateTime.Now,
                    Training_Endate = DateTime.Now.AddDays(24)
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
