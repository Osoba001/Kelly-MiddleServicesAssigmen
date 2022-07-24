using MiddlewareAndServices.Models;

namespace MiddlewareAndServices.Services
{
    public abstract class FileManagerAbstract
    {
        public abstract FileDocument ImageToByteArray(string fileName);

        public abstract Task<FileDocument> UploadFileToByteArray(IFormFile file);


    }
}