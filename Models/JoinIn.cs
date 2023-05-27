using System;
using System.Collections.Generic;

namespace BlueBlotRecords.Models
{
    public partial class JoinIn
    {
        public int IdJoinIn { get; set; }
        public string Mail { get; set; } = null!;
        public string NameBand { get; set; } = null!;
        public int IdGenre { get; set; }

        public virtual Genre IdGenreNavigation { get; set; } = null!;
    }
}
