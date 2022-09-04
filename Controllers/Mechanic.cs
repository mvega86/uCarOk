using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uCarOk.Repositories.Interface;
using uCarOk.Data.Entities;
using uCarOk.Domain.DTOs;

namespace uCarOk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Mechanic : Controller
    {
        public IMechanicRepository _mechanicService { get; }
        public Mechanic(IMechanicRepository mechanicService) 
        {
            _mechanicService = mechanicService;
   
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMechanicDTO>>>> GetAll()
        {
            return Ok(await _mechanicService.GetAllMechanic());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMechanicDTO>>> GetMechanicById(Guid id)
        {
            return Ok(await _mechanicService.GetMechanicById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetMechanicDTO>>>> DeleteMechanic(Guid id)
        {
            var response = await _mechanicService.DeleteMechanic(id);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMechanicDTO>>>> AddMechanic(AddMechanicDTO newMechanic)
        {
            return Ok(await _mechanicService.AddMechanic(newMechanic));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMechanicDTO>>> UpdateMechanic(UpdateMechanicDTO updatedMechanic)
        {
            var response = await _mechanicService.UpdateMechanic(updatedMechanic);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}