using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class BandArea
    {
        public int IdBandArea { get; set; }
        public int IdSubgenre { get; set; }
        public int IdBand { get; set; }
        public int IdGenre { get; set; }

        public virtual Band IdBandNavigation { get; set; } = null!;
        public virtual Genre IdGenreNavigation { get; set; } = null!;
        public virtual SubGenre IdSubgenreNavigation { get; set; } = null!;
    }
}
