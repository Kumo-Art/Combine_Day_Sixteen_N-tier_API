

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

        public ActionResult<List<Supply>> GetAll()
        {
            return Ok(_supplies.GetAll());
        }


        [HttpGet("GetById/{id}")]

        public ActionResult<Supply> GetById(int id)
        {
            Supply? supply = _supplies.GetById(id);


            if(supply == null)
            {
                return NotFound($"No supply with id {id}");
            }

            return Ok(supply);
        }

        [HttpPost("Create")]

        public ActionResult<Supply> Create([FromBody] Supply supply)
        {
            Supply? created = _supplies.Create(supply);

            if(created is null)
            {
                return BadRequest("A supply needs a name, and its Quantity must be greater than 0");
            }


            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
        }
        

        [HttpPut("{id}/Withdraw/{amount}")]

        public ActionResult<Supply> Withdraw(int id, int amount)
        {
            Supply? supply = _supplies.GetById(id);

            if(supply == null)
            {
                return NotFound($"No supply with id {id}");
            }

            bool ok = _supplies.Withdraw(supply, amount);

            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf");
            }


            return Ok(supply);
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            Supply? supply = _supplies.GetById(id);

            if(supply is null)
            {
                return NotFound($"No supply with id {id}.");
            }

            _supplies.Delete(supply);
            return NoContent();
        }
          
        
    }
}