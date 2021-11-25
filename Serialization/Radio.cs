using System;

namespace Serialization
{
    [Serializable]
    public class Radio
    {
        [NonSerialized] public string RadioId = "XF-552RF6";

        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        public double[] StationPresets { get; set; }
    }
}