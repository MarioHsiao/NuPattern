﻿using System;
using System.Globalization;
using System.Linq;
using NuPattern.Authoring.PatternToolkit.Automation.Properties;
using NuPattern.Diagnostics;
using NuPattern.Runtime;
using NuPattern.Runtime.References;

namespace NuPattern.Authoring.PatternToolkit.Automation
{
    /// <summary>
    /// Helper class for automation of the guidance capabilities.
    /// </summary>
    internal static class GuidanceDocumentHelper
    {
        private const string GuidanceDocumentExtension = ".doc";

        /// <summary>
        /// Gets the path to the guidance document from the current element.
        /// </summary>
        /// <remarks>
        /// Returns the first artifact link with a *.doc extension of the current element.
        /// </remarks>
        public static string GetDocumentPath(ITracer tracer, IProductElement element, IUriReferenceService uriService)
        {
            // Return path of first reference
            var references = SolutionArtifactLinkReference.GetResolvedReferences(element, uriService);
            if (!references.Any())
            {
                tracer.Warn(String.Format(CultureInfo.CurrentCulture,
                    Resources.GuidanceDocumentPathProvider_NoLinksFound, element.InstanceName));
                return string.Empty;
            }
            else
            {
                var reference = references.FirstOrDefault(r => r.PhysicalPath.EndsWith(GuidanceDocumentExtension));
                if (reference == null)
                {
                    tracer.Warn(String.Format(CultureInfo.CurrentCulture,
                        Resources.GuidanceDocumentPathProvider_NoDocumentLinkFound, element.InstanceName));
                    return string.Empty;
                }
                else
                {
                    tracer.Info(String.Format(CultureInfo.CurrentCulture,
                        Resources.GuidanceDocumentPathProvider_LinkFound, element.InstanceName, reference.PhysicalPath));
                    return reference.PhysicalPath;
                }
            }
        }
    }
}
