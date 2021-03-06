﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.ExtensibilityHosting;
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using NuPattern.Runtime.Validation;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Runtime.IntegrationTests
{
    [TestClass]
    public class PatternManagerSpec : IntegrationTest
    {
        internal static readonly IAssertion Assert = new Assertion();
        private ISolution solution;
        private IPatternManager patternManager;
        private IProduct product;
        private ValidationTest testClass;

        [TestInitialize]
        public void InitializeContext()
        {
            this.testClass = new ValidationTest();

            // Exports test class to MEF
            VsCompositionContainer.Create(new TypeCatalog(typeof(ValidationTest)), new VsExportProviderSettings(
                VsExportProvidingPreference.BeforeExportsFromOtherContainers));

            this.solution = VsIdeTestHostContext.ServiceProvider.GetService<ISolution>();
            this.solution.CreateInstance(this.DeploymentDirectory, "Blank");

            this.patternManager = VsIdeTestHostContext.ServiceProvider.GetService<IPatternManager>();
            var toolkit = this.patternManager.InstalledToolkits.Single(f => f.Id == "NuPattern.Runtime.IntegrationTests.TestToolkit");
            UIThreadInvoker.Invoke(new Action(() => this.product = this.patternManager.CreateProduct(toolkit, "Foo")));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (this.solution != null
                && this.solution.IsOpen)
            {
                this.solution.Close(false);
            }
        }

        [HostType("VS IDE")]
        [TestMethod, TestCategory("Integration")]
        public void WhenValidatingStore_ThenValidationTestInvoked()
        {
            this.patternManager.ValidateProductState();

            Assert.True(ValidationTest.IsCalled);
        }

        [HostType("VS IDE")]
        [TestMethod, TestCategory("Integration")]
        public void WhenItemIsDeleted_ThenPatternManagerIsNotClosed()
        {
            this.patternManager.Save();

            var folder = this.solution.SolutionFolders.First();
            var item = folder.AddContent("Hello", "Hello.txt");

            Assert.True(this.patternManager.IsOpen);

            item.As<ProjectItem>().Delete();

            Assert.True(this.patternManager.IsOpen);
        }
    }

    public class ValidationTest
    {
        public static bool IsCalled { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "For testing")]
        [RuntimeValidationExtension]
        [ValidationMethod(CustomCategory = ValidationConstants.RuntimeValidationCategory)]
        internal void ValidateSomething(ValidationContext context, IProduct element)
        {
            IsCalled = true;
        }
    }
}
