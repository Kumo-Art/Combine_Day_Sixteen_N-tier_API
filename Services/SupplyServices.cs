using Combine_Day_Sixteen_N_tier_API.Dtos;
using Combine_Day_Sixteen_N_tier_API.Models;
using Combine_Day_Sixteen_N_tier_API.Repositories;

//The services is where the rules live and its where our DTO's and models meet
//Controllers <-DTO-> Services <-Maodels-> Repo
namespace Combine_Day_Sixteen_N_tier_API.Services
{
    public class SupplyServices : ISupplyServices
    {
        private readonly ISupplyRepository _repository;


        public SupplyServices(ISupplyRepository repository)
        {
            _repository = repository;
        }

        public List<SupplyReadDTO> GetAll()
        {
            //The list always comes back in alphabetical order
            //LINQ Select for every record in our Db we will do x to
            return _repository.GetAll()
            .OrderBy(s => s.Name)
            .Select(s => ToReadDTO(s)) // turn every model into a DTO
            .ToList();
        }


        public SupplyReadDTO? GetById(int id)
        {
            Supply? supply = _repository.GetById(id);

            if (supply is null)
            {
                return null;
            }

            return ToReadDTO(supply);
        }


       //Rules: We must have a name and you cant stock fewer than 0
       //Rules 2 no 2 supplies can have the same name
        public SupplyReadDTO? Create(SupplyCreateDTO dto)
        {
            //we do not need this anymore this is being handled in the DTO itself
            // if(supply.Quantity <= 0 || string.IsNullOrWhiteSpace(supply.Name))
            // {
            //     return null;
            // }


            bool exists = _repository.GetAll().Any(s => s.Name.ToLower() == dto.Name.ToLower());

            //If a name already exists in our DB we return null
            if (exists)
            {
                return null;
            }

            Supply supply = new Supply();

            supply.Name = dto.Name;
            supply.Quantity = dto.Quantity;
            supply.StorageLocation = "Recieving Bay"; // everything new starts here

         // we are creating a new Supply variable and storing our added supply
            Supply created = _repository.Add(supply);

            return ToReadDTO(created);
        }

        //Rules: You must take at least 1, and never more than what we have.
        public bool Withdraw(int id, int amount)
        {

            Supply existing = _repository.GetById(id);
            
            if(existing == null || amount > existing.Quantity || amount <= 0)
            {
                return false;
            }

            existing.Quantity -= amount;
            _repository.Update(existing);
            return true;
        }

        public void Delete(int id)
        {

            Supply? supply = _repository.GetById(id);

          // if it is not null we delete it
            if (supply != null)
            {
                 _repository.Delete(supply);
            }
           
        }

        private static SupplyReadDTO ToReadDTO(Supply supply)
        {
            SupplyReadDTO outputDTO = new SupplyReadDTO();
            outputDTO.Id = supply.Id;
            outputDTO.Name = supply.Name;
            outputDTO.Quantity = supply.Quantity;

           return outputDTO;
        }
    }
}