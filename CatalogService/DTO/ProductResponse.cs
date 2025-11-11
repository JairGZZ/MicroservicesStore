using Microsoft.Identity.Client;

namespace CatalogService.DTO
{
    public record ProductResponse(
        
        int productid,
        string name,
        string description,
        decimal price,
        int stock

        );
}
