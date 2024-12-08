using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictRepository _districtRepository;

        public DistrictController(DistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }


        [HttpGet]
        public IActionResult GetAllDistricts()
        {
            var districtList = _districtRepository.GetAllDistricts();
            return Ok(districtList);
        }
    }
}
