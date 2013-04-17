﻿using System;

namespace NuPattern.Runtime.Guidance
{
    /// <summary>
    /// Represents the persisted information about features 
    /// instantiated in a solution.
    /// </summary>
    internal class SolutionFeatureState : ISolutionFeatureState
    {
        public string FeatureId { get; set; }
        public string InstanceName { get; set; }
        public Version Version { get; set; }
    }
}
