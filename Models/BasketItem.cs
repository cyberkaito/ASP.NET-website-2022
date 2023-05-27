using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class BasketItem
    {
        public BasketItem()
        {
            Orders = new HashSet<Order>();
        }

        public int IdBasketItem { get; set; }
        public int IdService { get; set; }
        public int IdBand { get; set; }

        public virtual Band IdBandNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
