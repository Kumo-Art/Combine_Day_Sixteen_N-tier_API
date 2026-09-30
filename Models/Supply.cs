using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace Combine_Day_Sixteen_N_tier_API.Models
{
    public class Supply
    {
        //When creating an entity we always need a unique identifier
        public int Id  {get;set;}

        public string Name {get;set;}

        public int Quantity {get;set;}

        //StorageLocation is internal only. the client never sees it
        public string StorageLocation {get;set;} = string.Empty;
    }
}