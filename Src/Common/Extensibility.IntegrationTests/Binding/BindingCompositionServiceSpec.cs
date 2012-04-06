﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using Microsoft.VisualStudio.Patterning.Runtime;
using Microsoft.VisualStudio.TeamArchitect.PowerTools;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Language.Intellisense;
using System.ComponentModel.Composition;
using Moq;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Patterning.Extensibility.Binding;
using Microsoft.VisualStudio.Patterning.Library.Events;
using System.ComponentModel.Composition.Hosting;

namespace Microsoft.VisualStudio.Patterning.Extensibility.UnitTests.Binding
{
	[TestClass]
	public class BindingCompositionServiceSpec : VsHostedSpec
	{
		internal static readonly IAssertion Assert = new Assertion();

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingISolution_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var solution = composition.GetExportedValue<ISolution>();

			Assert.NotNull(solution);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingIBindingFactory_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var result = composition.GetExportedValue<IBindingFactory>();

			Assert.NotNull(result);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingEvents_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var result = composition.GetExportedValues<IObservableEvent>();

			Assert.NotNull(result);
			Assert.True(result.Count() > 0);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingOtherVSExports_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var result = composition.GetExportedValues<ISmartTagSourceProvider>();

			Assert.NotNull(result);
			Assert.True(result.Count() > 0);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingSVsServiceProvider_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var result = (IServiceProvider)composition.GetExportedValue<SVsServiceProvider>();

			Assert.NotNull(result);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingCompositionService_ThenReturnsSelf()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var service = composition.GetExportedValue<IFeatureCompositionService>();

			Assert.Same(composition, service);
		}

		[TestMethod]
		public void WhenResolvingSVsServiceProviderImport_ThenSucceeds()
		{
			var components = new Mock<IComponentModel> { DefaultValue = DefaultValue.Mock };
			components.As<SComponentModel>();
			var services = new Mock<IServiceProvider> { DefaultValue = DefaultValue.Mock };
			services.As<SVsServiceProvider>();

			services.Setup(x => x.GetService(typeof(SComponentModel))).Returns(components.Object);

			var composition = new BindingCompositionService(services.Object);

			var result = new ServicedClass();

			composition.SatisfyImportsOnce(result);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingSVsServiceProviderImportInVS_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();

			var result = new ServicedClass();

			composition.SatisfyImportsOnce(result);
		}

		[HostType("VS IDE")]
		[TestMethod]
		public void WhenResolvingDynamicBindingContxtImport_ThenSucceeds()
		{
			var composition = ServiceProvider.GetService<IBindingCompositionService>();
			var context = composition.CreateDynamicContext();

			var result = new ServicedClass();

			context.CompositionService.SatisfyImportsOnce(result);

			Assert.NotNull(result.Context);
		}

		public class ServicedClass
		{
			[Import(typeof(SVsServiceProvider))]
			public IServiceProvider Services { get; set; }

			[Import(AllowDefault = true)]
			public IDynamicBindingContext Context { get; set; }
		}
	}
}
