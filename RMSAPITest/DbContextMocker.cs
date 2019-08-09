using Microsoft.EntityFrameworkCore;
using RMSAPI.Context;
using RMSAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMSAPITest
{
   public static class DbContextMocker
    {
        public static TrainingDBContext GetTrainingDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<TrainingDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new TrainingDBContext(options);
            return dbContext;
        }
    }
}
