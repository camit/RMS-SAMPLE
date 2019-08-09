using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RMSAPI.Context;
using RMSAPI.Extensions;
using RMSAPI.Model;
using RMSAPI.Utils;

namespace RMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly TrainingDBContext _context;
        protected readonly ILogger Logger;

        public TrainingsController(ILogger<TrainingsController> logger, TrainingDBContext context)
        {
            Logger = logger;
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTraining()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetTraining));

            return await _context.Training.ToListAsync();
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraining(int id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetTraining));

            var response = new SingleResponse<Training>();

           

            try
            {
                // Get the item by id
                response.Model = await _context.Training.FirstOrDefaultAsync(item => item.Training_Id == id);
                if (response.Model==null) response.ErrorMessage = "Record Not found";
               
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetTraining), ex);
            }

            return response.ToHttpResponse();
        }

       
        // POST: api/Trainings
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Produces("application/json")]
        public async Task<IActionResult> PostTraining([FromBody]Training training)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostTraining));

            var response = new SingleResponse<Training>();

            try
            {
                //Save to database  if Training End date is greater than start date
                if (training.Training_Endate > training.Training_Startdate)
                {
                    _context.Training.Add(training);
                    await _context.SaveChangesAsync();
                    response.NumofDays = (int?)(training.Training_Endate - training.Training_Startdate)?.TotalDays; // Return the number of days
                    response.Model = training;
                }
                else
                {
                    response.IsError = true;
                    response.ErrorMessage = Constants.EndDateBeforeStartDateError;
                }
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(PostTraining), ex);
            }

            return response.ToHttpCreatedResponse();
        }

       
    }
}
