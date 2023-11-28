using System;
namespace FiorelloBackend.Models
{
	public class Testimonial:BaseEntity
	{
		public string Image { get; set; }
		public string About { get; set; }
		public string Author { get; set; }
		public string Position { get; set; }
	}
}

