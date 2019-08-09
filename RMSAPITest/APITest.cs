using Microsoft.AspNetCore.Mvc;
using RMSAPI.Controllers;
using RMSAPI.Interfaces;
using RMSAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RMSAPITest
{
    public class APITest
    {
        [Fact]
        public async Task TestPostTrainingItemValidAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTrainingDbContext(nameof(TestPostTrainingItemValidAsync));
            var controller = new TrainingsController(null, dbContext);
            var request = new Training { Training_Name = "TestPostTrainingItem", Training_Startdate = DateTime.Now, Training_Endate = DateTime.Now.AddDays(24) };

            // Act
            var response = await controller.PostTraining(request) as ObjectResult;
            var value = response.Value as ISingleResponse<Training>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.IsError);
        }

        [Fact]
        public async Task TestPostTrainingItemInValidAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTrainingDbContext(nameof(TestPostTrainingItemInValidAsync));
            var controller = new TrainingsController(null, dbContext);
            var request = new Training { Training_Name = "TestPostTrainingItem", Training_Startdate = DateTime.Now, Training_Endate = DateTime.Now.AddDays(-3) };

            // Act
            var response = await controller.PostTraining(request) as ObjectResult;
            var value = response.Value as ISingleResponse<Training>;

            dbContext.Dispose();

            // Assert
            Assert.True(value.IsError);

            // Assert
            Assert.Equal("The End Date is before the start Date",value.ErrorMessage);
        }
    }
}
