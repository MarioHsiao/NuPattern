﻿
namespace NuPattern.Runtime
{
    /// <summary>
    /// Scope active when a pattern is being instantiated indirectly by 
    /// running a tool (such as unfolding a template).
    /// </summary>
    internal class TemplateInstantiationScope : SingletonScope<TemplateInstantiationScope>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateInstantiationScope"/> class.
        /// </summary>
        public TemplateInstantiationScope()
        {
        }
    }
}
