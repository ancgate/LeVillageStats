using System.Web.Http;
using LeVillageStats.Models;
using System.Web.Mvc;

namespace LeVillageStats.Views.Stats
{

    public class StatsController : ApiController
    {
        private IPersonRepository iPersonRepository;

        public StatsController(IPersonRepository _iPersonRepository)
        {
            iPersonRepository = _iPersonRepository;
        }

        [HttpGet("api/stats")]
        public ActionResult Get()
        {
            return Ok(iPersonRepository.GetAllPerson());
        }


    }
}
