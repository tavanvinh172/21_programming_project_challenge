using ExpenseTrackerApi.Documents.Command;
using ExpenseTrackerApi.Entities;
using ExpenseTrackerApi.ViewModels.Document;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class FileController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FileController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost(nameof(UploadFiles))]
		public async Task<Payload<List<FileUploadResp>>> UploadFiles([FromForm] List<IFormFile> files)
		{
			return await _mediator.Send(new UploadMultiFileCommand { AppContext = null, FormFiles = files.ToArray() });
		}

		[HttpPost(nameof(UploadNewCategoryIcon))]
		public async Task<Payload<FileUploadResp>> UploadNewCategoryIcon(IFormFile file)
		{
			return await _mediator.Send(new UploadFileCommand { AppContext = null, FormFile = file });
		}
	}
}
	