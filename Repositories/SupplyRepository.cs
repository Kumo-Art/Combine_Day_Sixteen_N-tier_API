using System.Runtime.CompilerServices;
using Combine_Day_Sixteen_N_tier_API.Data;
using Combine_Day_Sixteen_N_tier_API.Models;

namespace Combine_Day_Sixteen_N_tier_API.Repositories
{
    public class SupplyRepository : ISupplyRepository

    {
        //Constructor will always be same name as class Ex. SupplyRepository
        
        
            
            private readonly AppDbContext _db;

            //Constructor runs once when the class is called automatically
            //Asp.Net Core hands us the database connection because we registered it in the program.cs

   public SupplyRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Supply> GetAll()
        {
            return _db.supplies.ToList();
        }


        public Supply? GetById(int id)
        {
            return _db.supplies.FirstOrDefault(s => s.Id == id);
        }


        public Supply Add(Supply newSupply)
        {
            _db.supplies.Add(newSupply);
            _db.SaveChanges();
            return newSupply;
        }

        

        public void Update(Supply newSupply)
        {
            _db.SaveChanges();
        }


         public void Delete(Supply supply)
        {
            _db.supplies.Remove(supply);
            _db.SaveChanges();
        }

  
    }
}