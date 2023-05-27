using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class BandSubscriber
    {
        public int IdSub { get; set; }
        public string Mail { get; set; } = null!;
        public int IdBand { get; set; }

        public virtual Band IdBandNavigation { get; set; } = null!;
    }
}
