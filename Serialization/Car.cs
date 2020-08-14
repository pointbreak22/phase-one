using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    [Serializable]
    public class Car
    {
        public Radio TheRadio { get; set; }
        public bool IsHatchBack { get; set; }
    }
}
