using System;
using System.Windows;

namespace NuPattern.Runtime.Events
{
    /// <summary>
    /// Exposes the event raised when any runtime component in the pattern state 
    /// is instantiated.
    /// </summary>
    public interface IOnSolutionBuilderDragLeave : IObservable<IEvent<DragEventArgs>>, IObservableEvent
    {
    }
}