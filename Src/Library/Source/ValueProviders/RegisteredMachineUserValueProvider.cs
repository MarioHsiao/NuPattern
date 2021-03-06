﻿using System;
using Microsoft.Win32;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;
using NuPattern.Win32;

namespace NuPattern.Library.ValueProviders
{
    /// <summary>
    /// A <see cref=" ValueProvider"/> that returns the registered user of the current machine.
    /// </summary>
    [DisplayNameResource(@"RegisteredMachineUserValueProvider_DisplayName", typeof(Resources))]
    [DescriptionResource(@"RegisteredMachineUserValueProvider_Description", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_General", typeof(Resources))]
    [CLSCompliant(false)]
    public class RegisteredMachineUserValueProvider : ValueProvider
    {
        internal const string UnknownOrganization = "Unknown";
        private const string RegKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private const string RegKeyValue = @"RegisteredOrganization";

        private static readonly ITracer tracer = Tracer.Get<RegisteredMachineUserValueProvider>();
        private IRegistryReader reader;

        /// <summary>
        /// Creates a new instance of the <see cref="RegisteredMachineUserValueProvider"/> class.
        /// </summary>
        public RegisteredMachineUserValueProvider()
            : this(null)
        {
            if (this.reader == null)
            {
                this.reader = new RegistryReader(Registry.LocalMachine, RegKey, RegKeyValue);
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RegisteredMachineUserValueProvider"/> class.
        /// </summary>
        internal RegisteredMachineUserValueProvider(IRegistryReader reader)
            : base()
        {
            this.reader = reader;
        }


        /// <summary>
        /// Evaluates this provider.
        /// </summary>
        public override object Evaluate()
        {
            this.ValidateObject();

            tracer.Info(
                Resources.RegisteredMachineUserValueProvider_TraceInitial, RegKey, RegKeyValue);

            var value = this.reader.ReadValue();
            if (value == null)
            {
                tracer.Warn(
                    Resources.RegisteredMachineUserValueProvider_TraceNoValue, RegKey, RegKeyValue);
                return string.Empty;
            }
            else
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    value = UnknownOrganization;
                }
                else
                {
                    value = value.ToString();
                }

                tracer.Info(
                    Resources.RegisteredMachineUserValueProvider_TraceEvaluation, RegKey, RegKeyValue, value);
                return value.ToString();
            }
        }
    }
}
