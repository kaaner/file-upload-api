using FileUpload.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.API.Builder
{
	public class FileUploadBuilder
	{
		readonly FileUploadService _fileUploadService;
		public FileUploadBuilder()
		{
			_fileUploadService = new FileUploadService();
		}
		/// <summary>
		/// Map file object to DTO and send it to service.
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		internal bool Upload(IFormFile file)
		{
			FileDTO fileDTO = null;
			if (file.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					file.CopyTo(ms);
					var fileBytes = ms.ToArray();

					fileDTO = new FileDTO();
					fileDTO.Data = fileBytes;
					fileDTO.FileName = file.FileName.Split('.').FirstOrDefault();
					fileDTO.FullName = file.FileName;
					fileDTO.Size = file.Length;
					fileDTO.Extension = file.ContentType;
				}
			}

			return _fileUploadService.SaveFile(fileDTO);
		}
	}
}
