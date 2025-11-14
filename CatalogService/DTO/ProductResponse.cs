using Microsoft.Identity.Client;

namespace CatalogService.DTO
{
    public record  ProductResponse
    {

        public int productid { get; init; }
        public string name { get; init; }
        public string description { get; init; }
        public decimal price { get; init; }
        public int stock { get; init; }

    } 
}
