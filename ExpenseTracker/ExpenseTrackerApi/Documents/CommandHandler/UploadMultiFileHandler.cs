using ExpenseTrackerApi.Documents.Command;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Document;
using MediatR;

namespace ExpenseTrackerApi.Documents.CommandHandler
{
	public class UploadMultiFileHandler : IRequestHandler<UploadMultiFileCommand, Payload<List<FileUploadResp>>>
	{
		private readonly string _uploadDirectory = "wwwroot/uploads";
		public async Task<Payload<List<FileUploadResp>>> Handle(UploadMultiFileCommand request, CancellationToken cancellationToken)
		{
			var responses = new List<FileUploadResp>();

            foreach (var file in request.FormFiles ?? Array.Empty<IFormFile>())
            {
				try
				{
					if(file.Length <= 0)
					{
						responses.Add(new FileUploadResp
						{
							FileName = file.FileName,
							ContentType = file.ContentType,
							Size = file.Length,
							Date = DateTime.UtcNow,
							BlobId = Guid.NewGuid().ToString(),
							FilePath = null,
							FileId = 0 // Indicate invalid ID for 
						});
						continue;
					}

					// Ensure upload directory exists
					if (!Directory.Exists(_uploadDirectory))
					{
						Directory.CreateDirectory(_uploadDirectory);
					}
					
					var filePath = Path.Combine(_uploadDirectory, file.FileName);
					using(var stream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(stream, cancellationToken);
					}

					// Generate unique identifiers
					var fileId = DateTime.UtcNow.Ticks; // Example of a unique FileId
					var blobId = Guid.NewGuid().ToString();
					var fileUrl = $"uploads/{file.FileName}";
					responses.Add(new FileUploadResp
					{
						FileId = fileId,
						FileName = file.FileName,
						FilePath = fileUrl,
						ContentType = file.ContentType,
						Size = file.Length,
						Date = DateTime.UtcNow,
						BlobId = blobId,
					});
				}
				catch (Exception ex) {
					responses.Add(new FileUploadResp
					{
						FileName= file.FileName,
						ContentType= file.ContentType,
						Size = file.Length,
						Date = DateTime.UtcNow,
						BlobId = Guid.NewGuid().ToString(),
						FilePath = null,
						FileId = 0
					});
				}
            }

			return Payload<List<FileUploadResp>>.Successfully(responses, "Successfully Uploaded");
        }
	}
}
