using System;
namespace FiorelloBackend.Models
{
	public class ValentineOpportunityInfo:BaseEntity
	{
		public string Icon { get; set; }
		public string Name { get; set; }
		public int ValentineOpportunityId { get; set; }
		public ValentineOpportunity ValentineOpportunity { get; set; }
	}
}

