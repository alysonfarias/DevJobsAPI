namespace DevJobs.API.Controllers
{
  using DevJobs.API.Entities;
  using DevJobs.API.Models;
  using DevJobs.API.Persistence;
  using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;
        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(
                jv => jv.Id == id
            );

            if (jobVacancy == null) return NotFound();

            var application = new JobApplication(
                model.ApplicantName,
                model.ApplicantEmail,
                id
            );

            jobVacancy.Applications.Add(application);
            
            return Ok();
        }
    }
}