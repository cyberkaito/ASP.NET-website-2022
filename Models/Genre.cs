using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BandAreas = new HashSet<BandArea>();
        }

        public int IdGenre { get; set; }
        public string NameGenre { get; set; } = null!;

        public virtual ICollection<BandArea> BandAreas { get; set; }
    }
}
