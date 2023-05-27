using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class SubGenre
    {
        public SubGenre()
        {
            BandAreas = new HashSet<BandArea>();
        }

        public int IdSubgenre { get; set; }
        public string NameSubgenre { get; set; } = null!;

        public virtual ICollection<BandArea> BandAreas { get; set; }
    }
}
