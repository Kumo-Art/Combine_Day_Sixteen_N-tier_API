

using Combine_Day_Sixteen_N_tier_API.Dtos;
using Combine_Day_Sixteen_N_tier_API.Models;
using Combine_Day_Sixteen_N_tier_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Sixteen_N_tier_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyServices _supplies;


        public SuppliesController(ISupplyServices supplies)
        {
            _supplies = supplies;
        }


        [HttpGet("GetAll")]

        public ActionResult<SupplyReadDTO> GetAll()
        {
            return Ok(_supplies.GetAll());
        }


        [HttpGet("GetById/{id}")]

        public ActionResult<SupplyReadDTO> GetById(int id)
        {
            //we are returning our DTO not our model because we dont want our location leaking
            SupplyReadDTO? supply = _supplies.GetById(id);


            if(supply == null)
            {
                return NotFound($"No supply with id {id}");
            }

            return Ok(supply);
        }

         //[APIController] checks the DTOs attributes [Required] and [Range] before the methods
        [HttpPost("Create")]

        public ActionResult<SupplyReadDTO> Create([FromBody] SupplyReadDTO supply)
        {
            SupplyReadDTO? created = _supplies.Create(supply);

            if(created is null)
            {
                return Conflict($"There is already a supply called {supply.Name}");
            }


            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
        }
        

         [HttpPut("{id}/Withdraw/{amount}")]

         public ActionResult<Supply> Withdraw(int id, int amount)
         {
             SupplyReadDTO? supply = _supplies.GetById(id);

             if(supply == null)
             {
                 return NotFound($"No supply with id {id}");
             }

            bool ok = _supplies.Withdraw(id, amount);

            if(ok == false)
             {
                 return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf");
             }


            return Ok(supply);
         }

         [HttpDelete("Delete/{id}")]

         public IActionResult Delete(int id)
         {
              _supplies.GetById(id);

             if(_supplies.GetById(id) is null)
             {
                 return NotFound($"No supply with id {id}.");
             }

             _supplies.Delete(id);
             return NoContent();
         }
          
        
    }
}