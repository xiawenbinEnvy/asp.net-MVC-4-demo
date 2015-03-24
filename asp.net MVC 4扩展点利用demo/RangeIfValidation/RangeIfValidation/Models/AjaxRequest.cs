using RangeIfValidation.Extension;

namespace RangeIfValidation.Models
{
    public class AjaxRequest
    {
        public int Star { get; set; }

        [If("Star", "5", 1000, 2000)]
        [If("Star", "4", 500, 999)]
        [If("Star", "3", 100, 499)]
        public int Price { get; set; }

        public string Type { get; set; }

        [If("Type", "FG", 1, 5)]
        [If("Type", "PP", 1, 2)]
        public int Rooms { get; set; }
    }
}