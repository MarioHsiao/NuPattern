﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuPattern.Library.Automation;
using NuPattern.Runtime;
using NuPattern.Runtime.Bindings;

namespace NuPattern.Library.UnitTests.Automation.Command
{
    public class CommandAutomationSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenNoContext
        {
            [TestMethod, TestCategory("Unit")]
            [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Test Code")]
            public void WhenCreatingNewWithNullOwner_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new CommandAutomation(null, new Mock<ICommandSettings>().Object));
            }

            [TestMethod, TestCategory("Unit")]
            [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Test Code")]
            public void WhenCreatingNewWithNullSettings_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new CommandAutomation(new Mock<IProductElement>().Object, null));
            }
        }

        [TestClass]
        [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test Code")]
        public class GivenACommandAutomation
        {
            private CommandAutomation commandAutomation;
            private ICommand featureCommand;
            private Mock<IDynamicBinding<ICommand>> binding;
            private Mock<IDynamicBindingContext> dynamicContext;

            [TestInitialize]
            public void Initialize()
            {
                this.commandAutomation = new CommandAutomation(
                    new Mock<IProductElement>().Object,
                    Mocks.Of<ICommandSettings>().First(s => s.Owner.Name == "Foo"));

                var factory = new Mock<IBindingFactory>();

                this.featureCommand = new Mock<ICommand>().Object;

                this.binding = new Mock<IDynamicBinding<ICommand>>();
                this.binding.Setup(b => b.Value).Returns(this.featureCommand);

                factory.Setup(f => f.CreateBinding<ICommand>(It.IsAny<IBindingSettings>())).Returns(this.binding.Object);

                this.dynamicContext = new Mock<IDynamicBindingContext> { DefaultValue = DefaultValue.Mock };
                this.binding.Setup(x => x.CreateDynamicContext()).Returns(this.dynamicContext.Object);

                this.commandAutomation.BindingFactory = factory.Object;

                this.commandAutomation.EndInit();
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenInitialized_ThenSetsCommandBinding()
            {
                Assert.NotNull(this.commandAutomation.CommandBinding);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExecutingCommandWithValidBindings_ThenExecutes()
            {
                this.binding.Setup(b => b.Evaluate(this.dynamicContext.Object)).Returns(true);
                this.commandAutomation.Execute();

                Mock.Get(this.featureCommand).Verify(f => f.Execute(), Times.Once());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExecutingCommandWithInvalidBindings_ThenDoesNothing()
            {
                this.binding.Setup(b => b.Evaluate(this.dynamicContext.Object)).Returns(false);
                this.commandAutomation.Execute();

                Mock.Get(this.featureCommand).Verify(f => f.Execute(), Times.Never());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExecutingCommand_ThenAutomationExtensionIsAvailableToBinding()
            {
                this.commandAutomation.Execute();

                this.dynamicContext.Verify(x => x.AddExport(It.IsAny<IAutomationExtension>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExecutingCommand_ThenAutomationExtensionOwnerElementIsAvailableToBinding()
            {
                this.commandAutomation.Execute();

                this.dynamicContext.Verify(x => x.AddExport(It.IsAny<IAutomationExtension>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExecutingCommand_ThenAutomationExtensionOwnerElementIsAvailableToBindingAsAutomationContainer()
            {
                this.commandAutomation.Execute();

                this.dynamicContext.Verify(x => x.AddExport(It.IsAny<IAutomationExtension>()));
            }
        }
    }
}