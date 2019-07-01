using System;
using System.Collections.Generic;

namespace Web.APIMessages
{
    public partial class CartonSpecs
    {
        public int CartonSpecsId { get; set; }
        public int? CartonCount { get; set; }
        public double? DimensionsLength { get; set; }
        public double? DimensionsWidth { get; set; }
        public double? DimensionsHeight { get; set; }
        public double? Weight { get; set; }
        public int? CargoDetailId { get; set; }

        public virtual CargoDetail CargoDetail { get; set; }
    }
}
