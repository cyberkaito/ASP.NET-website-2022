using System.Numerics;

namespace BlueBlotRecords.Models
{
    public class BandCard
    {
        public List<Band> band { get; set; }
        public List<BandArea> bandArea { get; set; }
        public List<Genre> genre { get; set; }
        public List<SubGenre> subGenre { get; set; }
    }
}
