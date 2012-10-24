﻿using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Patterning.Authoring.Authoring;
using Microsoft.VisualStudio.Patterning.Extensibility;
using Microsoft.VisualStudio.TeamArchitect.PowerTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;

namespace Microsoft.VisualStudio.Patterning.Authoring.IntegrationTests
{
    [TestClass]
    public class VersionHelperSpec
    {
        internal static readonly IAssertion Assert = new Assertion();
        private static readonly string TargetsFilePath = AuthoringPackage.TargetsPath;

        private static bool IsTargetsFileExists()
        {
            return File.Exists(TargetsFilePath);
        }

        private static bool IsTargetsFileRewritten()
        {
            var currentFileInfo = new FileInfo(TargetsFilePath);

            if (currentFileInfo.CreationTime > currentFileInfo.LastWriteTime)
                return false;
            else
                return !currentFileInfo.LastWriteTime.Equals(currentFileInfo.CreationTime);
        }

        private static bool IsTargetsFileCurrent()
        {
            return IsTargetsFileExists() 
                && IsTargetsToolkitVersionCurrent()
                && IsTargetsFileExtensionPathsCurrent();
        }

        private static bool IsTargetsToolkitVersionCurrent()
        {
            var targetsInfo = new TargetsInfo
            {
                TargetsPath = TargetsFilePath,
            };

            VersionHelper.ReadTargetsValues(targetsInfo);
            return AuthoringPackage.CurrentToolkitVersion.Equals(targetsInfo.ToolkitVersion);
        }

        private static bool IsTargetsFileExtensionPathsCurrent()
        {
            var targetsInfo = new TargetsInfo
            {
                TargetsPath = TargetsFilePath,
                InstalledExtensionProperties = AuthoringPackage.InstalledExtensionProperties,
            };

            VersionHelper.ReadTargetsValues(targetsInfo);
            return !targetsInfo.InstalledExtensionProperties.Any(ie => string.IsNullOrEmpty(ie.Value));
        }

        [TestClass]
        [DeploymentItem("VersionTargetsSpec", "VersionTargetsSpec")]
        public class GivenNoTargetsFile : IntegrationTest
        {
            private ISolution solution;

            [TestInitialize]
            public void Initialize()
            {
                //Ensure targets file does not exist
                File.Delete(TargetsFilePath);
            }

            [TestCleanup]
            public void Cleanup()
            {
                VsIdeTestHostContext.Dte.Solution.Close();

                // Remove file if written
                File.Delete(TargetsFilePath);
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenNoSolution_ThenTargetsNotWritten()
            {
                Assert.False(IsTargetsFileExists());
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenCreateEmptySolution_ThenTargetsWritten()
            {
                Assert.False(IsTargetsFileExists());

                this.solution = (ISolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(ISolution));
                this.solution.CreateInstance(this.DeploymentDirectory, "EmptySolution");

                Assert.True(IsTargetsFileCurrent());
                Assert.True(IsTargetsFileRewritten());
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenLoadingExistingSolution_ThenTargetsWritten()
            {
                Assert.False(IsTargetsFileExists());

                this.solution = (ISolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(ISolution));
                this.solution.Open(PathTo("VersionTargetsSpec\\SimpleLibrarySolution.sln"));

                Assert.True(IsTargetsFileCurrent());
                Assert.True(IsTargetsFileRewritten());
            }
        }

        [TestClass]
        [DeploymentItem("VersionTargetsSpec", "VersionTargetsSpec")]
        public class GivenExistingTargetsFile : IntegrationTest
        {
            private ISolution solution;
            private FileInfo targetsFileInfo;

            [TestInitialize]
            public void Initialize()
            {
                //Ensure targets file does exist
                if (!Directory.Exists(Path.GetDirectoryName(TargetsFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(TargetsFilePath));
                }
                File.Copy(PathTo("VersionTargetsSpec\\VersionTargets_Current.targets"), TargetsFilePath, true);
                this.targetsFileInfo = new FileInfo(TargetsFilePath);
            }

            [TestCleanup]
            public void Cleanup()
            {
                VsIdeTestHostContext.Dte.Solution.Close();

                // Remove file if written
                File.Delete(TargetsFilePath);
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenNoSolutionOpen_ThenTargetsNotWritten()
            {
                Assert.True(IsTargetsFileExists());
                Assert.False(IsTargetsFileRewritten());
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenCreateEmptySolution_ThenNewTargetsWritten()
            {
                Assert.True(IsTargetsFileExists());

                this.solution = (ISolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(ISolution));
                this.solution.CreateInstance(this.DeploymentDirectory, "EmptySolution");

                Assert.True(IsTargetsFileCurrent());
                Assert.True(IsTargetsFileRewritten());
            }

            [TestMethod]
            [HostType("VS IDE")]
            [TestProperty("VSHostRestartOptions", "Before")]
            public void WhenLoadingExistingSolution_ThenNewTargetsWritten()
            {
                Assert.True(IsTargetsFileExists());

                this.solution = (ISolution)VsIdeTestHostContext.ServiceProvider.GetService(typeof(ISolution));
                this.solution.Open(PathTo("VersionTargetsSpec\\SimpleLibrarySolution.sln"));

                Assert.True(IsTargetsFileCurrent());
                Assert.True(IsTargetsFileRewritten());
            }
        }
    }
}