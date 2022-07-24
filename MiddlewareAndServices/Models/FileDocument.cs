namespace MiddlewareAndServices.Models
{
    public class FileDocument
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; }
        public byte[]? Content { get; set; }
       
    }
}
