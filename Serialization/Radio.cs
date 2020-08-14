using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        public double[] StationPresets { get; set; }
        [NonSerialized]
        public string radioID = "XF-552RF6";
    }
}
