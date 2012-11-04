﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.Patterning.Runtime.UnitTests.Events
{
	[TestClass]
	public class StaticWeakReferenceSpec
	{
		internal static readonly IAssertion Assert = new Assertion();

		[TestMethod, TestCategory("Unit")]
		public void WhenConstructed_ThenIsAliveIsTrue()
		{
			Assert.True(new StaticWeakReference().IsAlive);
		}

		[TestMethod, TestCategory("Unit")]
		public void WhenConstructed_ThenTargetIsNull()
		{
			Assert.Null(new StaticWeakReference().Target);
		}
	}
}
