using ExpenseTrackerApi.Documents.Command;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Document;
using MediatR;

namespace ExpenseTrackerApi.Documents.CommandHandler
{
	public class UploadFileHandler : IRequestHandler<UploadFileCommand, Payload<FileUploadResp>>
	{
		private readonly string _uploadDirectory = "wwwroot/categories";
		private readonly string[] _allowExtensions = [".png", ".svg"];
		private readonly long _fileSizeLimit = 10 * 1024 * 1024;

		public async Task<Payload<FileUploadResp>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
		{
			var file = request.FormFile;
			if (file == null || file.Length == 0)
			{
				return Payload<FileUploadResp>.BadRequest("No File Uploadded");
			}
			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
			if (!_allowExtensions.Contains(fileExtension))
			{
				return Payload<FileUploadResp>.BadRequest("Invalid file type. Only PNG and SVG files are allowed");
			}

			if (file.Length > _fileSizeLimit)
			{
				return Payload<FileUploadResp>.BadRequest("File size exceeds the maximum limit of 10MB.");
			}

			if (!Directory.Exists(_uploadDirectory))
			{
				Directory.CreateDirectory(_uploadDirectory);
			}

			var filePath = Path.Combine(_uploadDirectory, file.FileName);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			var fileUrl = $"categories/{file.FileName}";
			var fileId = DateTime.UtcNow.Ticks; // Example of a unique FileId
			var blobId = Guid.NewGuid().ToString();

			FileUploadResp FileUploadResp = new FileUploadResp()
			{
				FileId = fileId,
				FileName = file.FileName,
				FilePath = fileUrl,
				ContentType = file.ContentType,
				Size = file.Length,
				Date = DateTime.UtcNow,
				BlobId = blobId,
			};

			return Payload<FileUploadResp>.Successfully(FileUploadResp);
		}
	}
}
