//This is what our client will get back
//The model minus storagelocation
namespace Combine_Day_Sixteen_N_tier_API.Dtos
{
    public class SupplyReadDTO
    {
        
        public int Id {get;set;}

        public string Name {get;set;} = string.Empty;

        public int Quantity {get;set;}
    }
}