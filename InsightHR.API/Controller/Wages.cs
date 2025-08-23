
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insight_HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wages : ControllerBase
    {
        private readonly IwagesServices _iwagesServices;

        public Wages(IwagesServices iwagesServices)
        {
            _iwagesServices = iwagesServices;
        }

        [HttpPost("AddWages")]

        public async Task<IActionResult> Addemployee([FromForm] WagesRequest request)
        {
            await _iwagesServices.AddWages(request);

            return Ok(new { message = "Added SucsessFully" });
        }
        [HttpGet("Get-wages")]

        public async Task<IActionResult> Get()
        {
            var get = await _iwagesServices.Getwages();

            return Ok(get);
        }
        [HttpPatch("Update-wages")]

        public async Task<IActionResult> UpdateWages(UpdateWagesRequest request)
        {
            await _iwagesServices.UpdateWages(request);
            return Ok(new { message = "Updated SucsessFully" });
        }
        [HttpDelete]

        public async Task<IActionResult> Delete(DeleteWagesRequest deleteWagesRequest)
        {
            await _iwagesServices.DeleteWages(deleteWagesRequest
                );
            return Ok(new { message = "Deleted SucsessFully" });
        }

        [HttpGet("GetbyId")]

        public async Task<IActionResult> Getbyid([FromQuery] GetWagesByIdRequest idRequest)
        {
            var wages = await _iwagesServices.GetwagesbyID(idRequest);
            return Ok(wages);
        }
    }
}
