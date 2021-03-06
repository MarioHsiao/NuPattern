﻿using System;
using System.Collections.Generic;

namespace NuPattern.Runtime
{
    /// <summary>
    /// A provider of types from assemblies in the solution
    /// </summary>
    public interface IProjectTypeProvider
    {
        /// <summary>
        /// Returns all the refereced  types in the solution
        /// </summary>
        IEnumerable<Type> GetTypes<T>();
    }
}