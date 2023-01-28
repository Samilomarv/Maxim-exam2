using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography.X509Certificates;

namespace Maxim_exam2.Utilities
{
	public static class FileExtension
	{
		public static bool CheckSize(this IFormFile file, int kb) => 1024 * kb > file.Length;
		public static bool CheckType(this IFormFile file, string type)=>file.ContentType.Contains(type);
		public static string ChangeName(string oldName)
		{
			string extension = oldName.Substring(oldName.LastIndexOf("."));
			if (oldName.Length < 32)
			{
				oldName = oldName.Substring(0, oldName.LastIndexOf("."));
			}
			else
			{
				oldName=oldName.Substring(0,32);
			}
			return Guid.NewGuid + oldName + extension;

		}
		public static string CheckValidate(this IFormFile file,string type, int kb)
		{
			string result = "";
			if (!CheckSize(file,kb))
			{
				result += $"{file} olcusu {kb} dan coxdur";
			}
			if(!CheckType(file,type))
			{
				result += $"{file} filen tipi {type} ile uyusmur";
			}
			return result;
		}
		public static string SaveFile(this IFormFile file,string path)
		{
			string fileName = ChangeName(file.FileName);
			using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
			{
				file.CopyTo(fs);
			}
			return fileName;
		}
		public static void DeleteFile(this string fileName, string root,string folder)
		{
			string path=Path.Combine(root,folder,fileName);
		    if(!File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}
}
