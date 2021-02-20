namespace FileUpload.Core
{
  public class FileDTO
  {
    public string FileName { get; set; }
    public string FullName { get; set; }
    public string Extension { get; set; }
    public byte[] Data { get; set; }
    public long Size { get; set; }
  }
}