﻿using System;

namespace Serialization
{
    [Serializable]
    public class JamesBondClass : Car
    {
        public bool CanFly { get; set; }
        public bool CanSubmerge { get; set; }
    }
}