using System;

namespace NuPattern.Runtime.ToolkitInterface
{
    /// <summary>
    /// Proxy interface for abstract elements.
    /// </summary>
    /// <typeparam name="TInterface">The type of the strong-typed interface for the abstract element.</typeparam>
    [CLSCompliant(false)]
    public interface IAbstractElementProxy<TInterface> : IContainerProxy<TInterface>, IPropertyProxy<TInterface>, IFluentInterface
    {
    }
}
