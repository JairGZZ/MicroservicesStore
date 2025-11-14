namespace CatalogService.Exception
{

    public class ErrorResponse
    {
        public string? Title { get; set; }

        public string? ExceptionMessage { get; set; }
        public string? ExceptionName { get; set; } = string.Empty;
        public int? StatusCode { get; set; }



    }

}
