using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileUpload.Core
{
	public class FileUploadService
	{
		const string filePath = @"Files";
		public bool SaveFile(FileDTO file)
		{
			try
			{
				if (file != null)
				{
					File.WriteAllBytes($"{filePath}/{file.FullName}", file.Data);//Files will be saved to folder called 'Files'
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public List<FileDTO> GetAllFileNames(string fileName)
		{
			string startupPath = Environment.CurrentDirectory;
			string projectPath = Directory.GetParent(startupPath).Parent.Parent.Parent.FullName + "\\FileUpload.API\\";
			List<FileDTO> fileDTOs = new List<FileDTO>();
			DirectoryInfo d = new DirectoryInfo(projectPath + filePath);//Files will be taken from folder called 'Files'
			FileInfo[] fileInfos = d.GetFiles();

			foreach (var item in fileInfos)
			{
				FileDTO fileDTO = new FileDTO();
				fileDTO.FileName = item.Name;
				fileDTO.FullName = item.FullName;
				fileDTO.Extension = item.Extension;

				fileDTOs.Add(fileDTO);
			}
			return fileDTOs;
		}

		public bool HasFileExtension(string fullName)
		{
			FileDTO fileDTO = new FileDTO();
			string[] file = fullName.Split('.');
			fileDTO.Extension = file.Last();
			if (fileDTO.Extension == null)
				return false;
			else
				return true;
		}
	}
}