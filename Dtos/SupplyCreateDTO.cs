//what a client is allowed to send
//this will no Id (our DB picks it anyway) and no storagelocation

using System.ComponentModel.DataAnnotations;

namespace Combine_Day_Sixteen_N_tier_API.Dtos
{
    public class SupplyCreateDTO
    {

        //Attributes are characteristics of our properties
        [Required(ErrorMessage  = "Every supply needs a name.")]
        public string Name {get;set;}
        [Range(1, 1000, ErrorMessage = "Every entry must be from 1 and 1000")]

        public int Quantity {get;set;}
    }
}