using Combine_Day_Sixteen_N_tier_API.Dtos;
using Combine_Day_Sixteen_N_tier_API.Models;

namespace Combine_Day_Sixteen_N_tier_API.Services
{
    public interface ISupplyServices
    {
         List<SupplyReadDTO> GetAll();

         SupplyReadDTO? GetById(int id);

         SupplyReadDTO Create(SupplyCreateDTO supply);

         bool Withdraw(int id, int amount); // false if there isnt enough


         void Delete(int id);
    }
}