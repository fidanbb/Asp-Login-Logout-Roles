using System;
namespace FiorelloBackend.Models
{
	public class ValentineOpportunity:BaseEntity
	{
		public string VideoImage { get; set; }
		public string VideoIcon { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public List<ValentineOpportunityInfo> OpportunityInfos { get; set; }
	}
}

