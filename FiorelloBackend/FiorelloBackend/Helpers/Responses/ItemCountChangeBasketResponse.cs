using System;
namespace FiorelloBackend.Helpers.Responses
{
	public class ItemCountChangeBasketResponse
    {
        public int Count { get; set; }
        public decimal GrandTotal { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemTotalPrice { get; set; }
    }
}

