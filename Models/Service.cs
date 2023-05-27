using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class Service
    {
        public Service()
        {
            BasketItems = new HashSet<BasketItem>();
        }

        public int IdService { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
