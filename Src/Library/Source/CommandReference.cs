﻿using System;
using System.ComponentModel;
using System.Linq;
using NuPattern.ComponentModel.Design;
using NuPattern.Library.Automation;
using NuPattern.Library.Design;
using NuPattern.Library.Properties;

namespace NuPattern.Library
{
    /// <summary>
    /// Command reference element to be shown int he command reference editor
    /// </summary>
    [DisplayNameResource(@"CommandReference_DisplayName", typeof(Resources))]
    [DescriptionResource(@"CommandReference_Description", typeof(Resources))]
    [TypeDescriptionProvider(typeof(CommandReferenceTypeDescriptionProvider))]
    public class CommandReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReference"/> class.
        /// </summary>
        /// <param name="commandSettings">The command settings.</param>
        public CommandReference(ICommandSettings commandSettings)
        {
            this.CommandSettings = commandSettings;
        }

        internal ICommandSettings CommandSettings { get; private set; }

        /// <summary>
        /// Gets or sets the command id.
        /// </summary>
        /// <value>The command id.</value>
        [DisplayNameResource(@"CommandReference_DisplayName", typeof(Resources))]
        [CategoryResource(@"AutomationCategory_Automation", typeof(Resources))]
        [DescriptionResource(@"CommandReference_Description", typeof(Resources))]
        public Guid CommandId { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (this.CommandId == Guid.Empty)
            {
                return Resources.CommandReference_EmptyReference;
            }
            else
            {
                if (this.CommandSettings != null)
                {
                    var settings = this.CommandSettings.Owner.AutomationSettings;

                    return (from cs in settings
                            let setting = cs.As<ICommandSettings>()
                            where setting != null && setting.Id == this.CommandId
                            select cs.Name)
                            .SingleOrDefault();
                }
            }

            return base.ToString();
        }
    }
}