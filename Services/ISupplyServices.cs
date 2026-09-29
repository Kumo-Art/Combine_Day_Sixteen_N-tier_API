using Combine_Day_Sixteen_N_tier_API.Models;

namespace Combine_Day_Sixteen_N_tier_API.Services
{
    public interface ISupplyServices
    {
         List<Supply> GetAll();

         Supply? GetById(int id);

         Supply Create(Supply supply);

         bool Withdraw(Supply supply, int amount); // false if there isnt enough


         void Delete(Supply supply);
    }
}