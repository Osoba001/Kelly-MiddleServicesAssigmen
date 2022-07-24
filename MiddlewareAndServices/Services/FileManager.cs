

using MiddlewareAndServices.Models;
using MiddlewareAndServices.Utilities;

namespace MiddlewareAndServices.Services
{
    public class FileManager : FileManagerAbstract
    {
        public override FileDocument ImageToByteArray(string fileName)
        {
            byte[] fileContent = File.ReadAllBytes(fileName);
            long byteLength = new FileInfo(fileName).Length;

            return new FileDocument
            {
                Name = fileName,
                Content = fileContent,
                Size = byteLength.formarFileSize()

            };
        }
       public override async Task<FileDocument> UploadFileToByteArray(IFormFile file)
        {
            if (file.Length > 0 && file.FileName is not null)
            {
                if (file.Length<=10000000)
                {
                    try
                    {
                        await using var stream = new MemoryStream();
                        await file.CopyToAsync(stream);

                        return new FileDocument
                        {
                            Name = file.FileName,
                            Content = stream.ToArray(),
                            Size = file.Length.formarFileSize()

                        };
                    }
                    catch (Exception)
                    {

                        throw new Exception();
                    }
                   
                }else
                    throw new ArgumentException("File size is too large. A maximum size 0f 10MB is allow.");
            }
            else
                throw new ArgumentException("No file selected");
            // Handle this exception With custom middleware
        }
    }
}
