﻿using System;
using System.Collections.Generic;
using System.Xml;
using ExtMan = Microsoft.VisualStudio.ExtensionManager;

namespace NuPattern.VisualStudio.Extensions
{
    /// <summary>
    /// A wrapper for a VS VSIX registration header
    /// </summary>
    internal class VsExtensionHeader : IExtensionHeader
    {
        private ExtMan.IExtensionHeader vsHeader;

        /// <summary>
        /// Creates a new instance of the <see cref="VsExtensionHeader"/> class.
        /// </summary>
        public VsExtensionHeader(ExtMan.IExtensionHeader vsHeader)
        {
            this.vsHeader = vsHeader;
        }

        public IList<XmlElement> AdditionalElements
        {
            get { return this.vsHeader.AdditionalElements; }
        }

        public bool AllUsers
        {
            get { return this.vsHeader.AllUsers; }
        }

        public string Author
        {
            get { return this.vsHeader.Author; }
        }

        public string Description
        {
            get { return this.vsHeader.Description; }
        }

        public Uri GettingStartedGuide
        {
            get { return this.vsHeader.GettingStartedGuide; }
        }

        public bool GlobalScope
        {
            get { return this.vsHeader.GlobalScope; }
        }

        public string Icon
        {
            get { return this.vsHeader.Icon; }
        }

        public string Identifier
        {
            get { return this.vsHeader.Identifier; }
        }

        public bool InstalledByMsi
        {
            get { return this.vsHeader.InstalledByMsi; }
        }

        public string License
        {
            get { return this.vsHeader.License; }
        }

        public bool LicenseClickThrough
        {
            get { return this.vsHeader.LicenseClickThrough; }
        }

        public string LicenseFormat
        {
            get { return this.vsHeader.LicenseFormat; }
        }

        public System.Globalization.CultureInfo Locale
        {
            get { return this.vsHeader.Locale; }
        }

        public IList<System.Xml.XmlElement> LocalizedAdditionalElements
        {
            get { return this.vsHeader.LocalizedAdditionalElements; }
        }

        public string LocalizedDescription
        {
            get { return this.vsHeader.LocalizedDescription; }
        }

        public string LocalizedName
        {
            get { return this.vsHeader.LocalizedName; }
        }

        public Uri MoreInfoUrl
        {
            get { return this.vsHeader.MoreInfoUrl; }
        }

        public string Name
        {
            get { return this.vsHeader.Name; }
        }

        public string PreviewImage
        {
            get { return this.vsHeader.PreviewImage; }
        }

        public Uri ReleaseNotes
        {
            get { return this.vsHeader.ReleaseNotes; }
        }

        public byte[] ReleaseNotesContent
        {
            get { return this.vsHeader.ReleaseNotesContent; }
        }

        public string ReleaseNotesFormat
        {
            get { return this.vsHeader.ReleaseNotesFormat; }
        }

        public IVersionRange SupportedFrameworkVersionRange
        {
            get { return new VsVersionRange(this.vsHeader.SupportedFrameworkVersionRange); }
        }

        public bool SystemComponent
        {
            get { return this.vsHeader.SystemComponent; }
        }

        public IEnumerable<string> Tags
        {
            get { return this.vsHeader.Tags; }
        }

        public Version Version
        {
            get { return this.vsHeader.Version; }
        }
    }
}