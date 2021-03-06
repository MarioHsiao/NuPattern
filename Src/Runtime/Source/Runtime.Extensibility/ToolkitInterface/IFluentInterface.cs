using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NuPattern.Runtime.ToolkitInterface
{
	/// <summary>
	/// Helper interface used to hide the base <see cref="object"/> 
	/// members from the fluent API to make it much cleaner 
	/// in Visual Studio intellisense.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IFluentInterface
	{
		/// <summary/>
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "We're hiding Object.GetType")]
		[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "GetType", Justification = "We're hiding Object.GetType")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		Type GetType();

		/// <summary/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		int GetHashCode();

		/// <summary/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		string ToString();

		/// <summary/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		bool Equals(object other);
	}
}
