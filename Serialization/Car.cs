using System;

namespace Serialization
{
    [Serializable]
    public class Car
    {
        public Radio TheRadio { get; set; }
        public bool IsHatchBack { get; set; }
    }
}