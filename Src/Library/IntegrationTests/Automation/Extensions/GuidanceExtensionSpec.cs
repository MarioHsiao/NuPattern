﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using NuPattern.Library.Automation;
using NuPattern.Library.Commands;
using NuPattern.Library.Conditions;
using NuPattern.Library.Events;
using NuPattern.Modeling;
using NuPattern.Reflection;
using NuPattern.Runtime;
using NuPattern.Runtime.Bindings;
using NuPattern.Runtime.Bindings.Design;
using NuPattern.Runtime.References;
using NuPattern.Runtime.Schema;

namespace NuPattern.Library.IntegrationTests.Automation.Guidance
{
    [TestClass]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test code")]
    public class GuidanceExtensionChangeRuleSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test code")]
        public class GivenAnElement
        {
            private Store store;

            private IGuidanceExtension guidanceExtension;
            private IPatternElementSchema container;

            [TestInitialize]
            public void Initialize()
            {
                ElementSchema element = null;

                this.store = new Store(VsIdeTestHostContext.ServiceProvider,
                    new[] { typeof(CoreDesignSurfaceDomainModel), typeof(PatternModelDomainModel), typeof(LibraryDomainModel) });

                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    this.store.ElementFactory.CreateElement<PatternModelSchema>();
                    element = this.store.ElementFactory.CreateElement<ElementSchema>();
                });

                this.guidanceExtension = element.GetExtensions<IGuidanceExtension>().FirstOrDefault();
                this.container = element as IPatternElementSchema;
            }

            [HostType("VS IDE")]
            [TestMethod, TestCategory("Integration")]
            public void WhenSettingGuidanceExtensionIdProperty_ThenCreatesAutomationSettings()
            {
                this.guidanceExtension.ExtensionId = "Foo";
                Assert.Equal(4, this.container.AutomationSettings.Count());

                AssertInstantiateCommand(true);
                AssertInstantiateEvent(true, AssertInstantiateCommand(false));
                AssertActivateCommand(true);
                AssertActivateContextMenu(true);
            }

            [HostType("VS IDE")]
            [TestMethod, TestCategory("Integration")]
            public void WhenChangingGuidanceGuidanceExtensionIdProperty_ThenUpdatedCommandSettings()
            {
                this.guidanceExtension.ExtensionId = "Foo";
                this.guidanceExtension.ExtensionId = "Foo1";

                Assert.Equal(4, this.container.AutomationSettings.Count());

                AssertInstantiateCommand(true);
                AssertInstantiateEvent(true, AssertInstantiateCommand(false));
                AssertActivateCommand(true);
                AssertActivateContextMenu(true);
            }

            [HostType("VS IDE")]
            [TestMethod, TestCategory("Integration")]
            public void WhenChangingDefaultInstanceNameProperty_ThenUpdatedCommandSettings()
            {
                this.guidanceExtension.ExtensionId = "Foo";
                this.guidanceExtension.ExtensionId = "Foo1";

                Assert.Equal(4, this.container.AutomationSettings.Count());

                this.guidanceExtension.GuidanceInstanceName = "DefaultInstanceName1";

                AssertInstantiateCommand(true);
                AssertInstantiateEvent(true, AssertInstantiateCommand(false));
                AssertActivateCommand(true);
                AssertActivateContextMenu(true);
            }

            [HostType("VS IDE")]
            [TestMethod, TestCategory("Integration")]
            public void WhenChangingActivateOnCreationProperty_ThenUpdatedCommandSettings()
            {
                this.guidanceExtension.ExtensionId = "Foo";
                this.guidanceExtension.ExtensionId = "Foo1";

                Assert.Equal(4, this.container.AutomationSettings.Count());

                this.guidanceExtension.GuidanceActivateOnCreation = !this.guidanceExtension.GuidanceActivateOnCreation;

                AssertInstantiateCommand(true);
                AssertInstantiateEvent(true, AssertInstantiateCommand(false));
                AssertActivateCommand(true);
                AssertActivateContextMenu(true);
            }

            [HostType("VS IDE")]
            [TestMethod, TestCategory("Integration")]
            public void WhenResettingGuidanceGuidanceExtensionId_ThenDeletesCommandSettingAndEventSettings()
            {
                this.guidanceExtension.ExtensionId = "Foo";
                this.guidanceExtension.ExtensionId = string.Empty;

                Assert.Equal(0, this.container.AutomationSettings.Count());
                Assert.Equal(0, this.container.Properties.Count());
            }

            private IAutomationSettingsSchema AssertInstantiateCommand(bool verifySettings)
            {
                var command = this.container.AutomationSettings.FirstOrDefault(set => set.Name.Equals(Properties.Resources.GuidanceExtension_InstantiateCommandName));
                Assert.NotNull(command);

                var commandSettings = command.GetExtensions<ICommandSettings>().FirstOrDefault();
                Assert.NotNull(commandSettings);

                if (verifySettings)
                {
                    Assert.Equal(CustomizationState.False, command.IsCustomizable);
                    Assert.True(command.IsSystem);

                    Assert.Equal(commandSettings.TypeId, typeof(InstantiateGuidanceWorkflowCommand).FullName);

                    var extensionProperty = TypeDescriptor.GetProperties(commandSettings)[Reflector<InstantiateGuidanceWorkflowCommand>.GetProperty(c => c.ExtensionId).Name]
                        .GetValue(commandSettings) as DesignProperty;
                    Assert.Equal(this.guidanceExtension.ExtensionId, extensionProperty.GetValue());

                    var defaultInstanceProperty = TypeDescriptor.GetProperties(commandSettings)[Reflector<InstantiateGuidanceWorkflowCommand>.GetProperty(c => c.DefaultInstanceName).Name]
                        .GetValue(commandSettings) as DesignProperty;
                    Assert.Equal(this.guidanceExtension.GuidanceInstanceName, defaultInstanceProperty.GetValue());

                    var focusOnInstantiationProperty = TypeDescriptor.GetProperties(commandSettings)[Reflector<InstantiateGuidanceWorkflowCommand>.GetProperty(c => c.ActivateOnInstantiation).Name]
                        .GetValue(commandSettings) as DesignProperty;
                    Assert.Equal(this.guidanceExtension.GuidanceActivateOnCreation, focusOnInstantiationProperty.GetValue());

                    var sharedInstanceProperty = TypeDescriptor.GetProperties(commandSettings)[Reflector<InstantiateGuidanceWorkflowCommand>.GetProperty(c => c.SharedInstance).Name]
                        .GetValue(commandSettings) as DesignProperty;
                    Assert.Equal(this.guidanceExtension.GuidanceSharedInstance, sharedInstanceProperty.GetValue());
                }

                return command;
            }

            private IAutomationSettingsSchema AssertActivateCommand(bool verifySettings)
            {
                var command = this.container.AutomationSettings.FirstOrDefault(set => set.Name.Equals(Properties.Resources.GuidanceExtension_ActivateCommandName));
                Assert.NotNull(command);

                var commandSettings = command.GetExtensions<ICommandSettings>().FirstOrDefault();
                Assert.NotNull(commandSettings);

                if (verifySettings)
                {
                    Assert.Equal(CustomizationState.False, command.IsCustomizable);
                    Assert.True(command.IsSystem);

                    Assert.Equal(commandSettings.TypeId, typeof(ActivateGuidanceWorkflowCommand).FullName);
                }

                return command;
            }

            private IAutomationSettingsSchema AssertActivateContextMenu(bool verifySettings)
            {
                var menu = this.container.AutomationSettings.FirstOrDefault(set => set.Name.Equals(Properties.Resources.GuidanceExtension_ActivateContextMenuName));
                Assert.NotNull(menu);

                var menuSettings = menu.GetExtensions<MenuSettings>().FirstOrDefault();
                Assert.NotNull(menuSettings);

                if (verifySettings)
                {
                    Assert.Equal(CustomizationState.False, menu.IsCustomizable);
                    Assert.True(menu.IsSystem);

                    var command = AssertActivateCommand(false);
                    var commandSettings = command.GetExtensions<ICommandSettings>().FirstOrDefault();

                    Assert.Equal(menuSettings.Text, Properties.Resources.GuidanceExtension_ActivateMenuItemText);
                    Assert.Equal(menuSettings.CommandId, commandSettings.Id);
                    Assert.Equal(menuSettings.WizardId, Guid.Empty);

                    var conditions = BindingSerializer.Serialize(
                        new[]
                        {
                            new ConditionBindingSettings
                            {
                                TypeId = typeof(ElementReferenceExistsCondition).FullName,
                                Properties = 
                                {
                                    new PropertyBindingSettings
                                    {
                                        Name = Reflector<ElementReferenceExistsCondition>.GetPropertyName(cond => cond.Kind),
                                        Value = ReferenceKindConstants.GuidanceTopic
                                    },
                                }
                            }
                        });

                    Assert.Equal(menuSettings.Conditions, conditions);
                }

                return menu;
            }

            private IAutomationSettingsSchema AssertInstantiateEvent(bool verifySettings, IAutomationSettingsSchema command)
            {
                var event1 = this.container.AutomationSettings.FirstOrDefault(set => set.Name.Equals(Properties.Resources.GuidanceExtension_InstantiateEventName));
                Assert.NotNull(event1);

                var eventSettings = event1.GetExtensions<IEventSettings>().FirstOrDefault();
                Assert.NotNull(eventSettings);

                if (verifySettings)
                {
                    Assert.Equal(CustomizationState.False, event1.IsCustomizable);
                    Assert.True(event1.IsSystem);

                    Assert.Equal(eventSettings.EventId, typeof(IOnElementInstantiatedEvent).FullName);

                    var commandSettings = command.GetExtensions<ICommandSettings>().FirstOrDefault();
                    Assert.NotNull(commandSettings);

                    Assert.Equal(eventSettings.CommandId, commandSettings.Id);
                }

                return event1;
            }
        }
    }
}
