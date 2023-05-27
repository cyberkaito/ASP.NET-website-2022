using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class Band
    {
        public Band()
        {
            BandAreas = new HashSet<BandArea>();
            BandSubscribers = new HashSet<BandSubscriber>();
            BasketItems = new HashSet<BasketItem>();
        }

        public int IdBand { get; set; }
        public string NameBand { get; set; } = null!;
        public string MembersBand { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime FormedIn { get; set; }
        public string Country { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string PasswordBand { get; set; } = null!;
        public string NumberPhone { get; set; } = null!;

        public virtual ICollection<BandArea> BandAreas { get; set; }
        public virtual ICollection<BandSubscriber> BandSubscribers { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
