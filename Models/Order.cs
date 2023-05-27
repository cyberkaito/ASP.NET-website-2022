using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public DateTime FormationDate { get; set; }
        public DateTime DateExpired { get; set; }
        public int IdBasketItem { get; set; }

        public virtual BasketItem IdBasketItemNavigation { get; set; } = null!;
    }
}
