using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Document;
using MediatR;

namespace ExpenseTrackerApi.Documents.Command
{
	public class UploadFileCommand : IRequest<Payload<FileUploadResp>>
	{
		public long ObjectId { get; set; }
		public IFormFile? FormFile { get; set; }
		public AppDbContext? AppContext { get; set; }
		public string? AreaName { get; set; }
	}
}
