namespace Maxim_exam2.ViewModels
{
	public class UpdateServiceVM
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public IFormFile? Image { get; set; }
	}
}
