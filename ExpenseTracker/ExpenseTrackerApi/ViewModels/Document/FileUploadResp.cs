namespace ExpenseTrackerApi.ViewModels.Document
{
	public class FileUploadResp
	{
		public long FileId { get; set; }
		public string? ContentType { get; set; }
		public string? FilePath { get; set; }
		public string? FileName { get; set; }
		public long Size { get; set; }
		public DateTime? Date { get; set; }
		public string? BlobId { get; set; }
	}
	public class FileInfoResp
	{
		public long FileId { get; set; }
		public string? BlobId { get; set; }
		public string? Base64 { get; set; }
	}

	public class FileDelete
	{
		public long FileId { get; set; }
	}
	public class FileContentById
	{
		public List<long> FileIds { get; set; }
		public bool IsByte { get; set; }
	}
}
