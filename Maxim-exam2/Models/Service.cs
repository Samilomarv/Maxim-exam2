using Maxim_exam2.Models.Base;

namespace Maxim_exam2.Models
{
	public class Service:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
