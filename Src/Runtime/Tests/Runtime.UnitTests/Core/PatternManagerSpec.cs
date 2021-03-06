﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuPattern.Runtime.Store;
using NuPattern.VisualStudio;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Runtime.UnitTests
{
    public class PatternManagerSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenNoContext
        {
            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullServiceProvider_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(null, Mock.Of<ISolution>(), Mock.Of<IShellEvents>(), Mock.Of<ISolutionEvents>(), Mock.Of<IItemEvents>(), Enumerable.Empty<IInstalledToolkitInfo>(), Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullSolution_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), null, Mock.Of<IShellEvents>(), Mock.Of<ISolutionEvents>(), Mock.Of<IItemEvents>(), Enumerable.Empty<IInstalledToolkitInfo>(), Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullShellEvents_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), Mock.Of<ISolution>(), null, Mock.Of<ISolutionEvents>(), Mock.Of<IItemEvents>(), Enumerable.Empty<IInstalledToolkitInfo>(), Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullSolutionEvents_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), Mock.Of<ISolution>(), Mock.Of<IShellEvents>(), null, Mock.Of<IItemEvents>(), Enumerable.Empty<IInstalledToolkitInfo>(), Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullItemEvents_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), Mock.Of<ISolution>(), Mock.Of<IShellEvents>(), Mock.Of<ISolutionEvents>(), null, Enumerable.Empty<IInstalledToolkitInfo>(), Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullInstalledFactories_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), Mock.Of<ISolution>(), Mock.Of<IShellEvents>(), Mock.Of<ISolutionEvents>(), Mock.Of<IItemEvents>(), null, Mock.Of<IUserMessageService>()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingWithNullMessageService_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new PatternManager(Mock.Of<IServiceProvider>(), Mock.Of<ISolution>(), Mock.Of<IShellEvents>(), Mock.Of<ISolutionEvents>(), Mock.Of<IItemEvents>(), Enumerable.Empty<IInstalledToolkitInfo>(), null));
            }

        }

        [TestClass]
        [DeploymentItem(RuntimeStoreFilename, @"Core")]
        [DeploymentItem(@"Core\Invalid.slnbldr", @"Core")]
        [DeploymentItem(@"Core\InvalidVersion.slnbldr", @"Core")]
        [DeploymentItem(@"Core\OldVersion.slnbldr", @"Core")]
        [SuppressMessage("Microsoft.Design", "CA1001", Justification = "Disposed on cleanup.")]
        public class GivenAConfiguredPatternManager
        {
            private static readonly string solutionItemsDir = Path.GetTempPath() + "\\Solution Items";
            private const string RuntimeStoreFilename = @"Core\Blank.gen" + StoreConstants.RuntimeStoreExtension;
            private Solution solution;
            private Mock<IShellEvents> shellEvents;
            private Mock<ISolutionEvents> solutionEvents;
            private Mock<IItemEvents> itemEvents;
            private Mock<IUserMessageService> messageService;
            private Mock<IInstalledToolkitInfo> toolkitInfo;
            private PatternManager manager;
            private DslTestStore<ProductStateStoreDomainModel> store;

            [TestInitialize]
            public void Initialize()
            {
                this.solutionEvents = new Mock<ISolutionEvents>();
                this.itemEvents = new Mock<IItemEvents>();
                this.messageService = new Mock<IUserMessageService>();

                if (Directory.Exists(solutionItemsDir))
                {
                    Directory.Delete(solutionItemsDir, true);
                }

                Directory.CreateDirectory(solutionItemsDir);

                this.solution = new Solution
                {
                    PhysicalPath = Path.GetTempFileName(),
                    Items =
                    {
                        new SolutionFolder 
                        {
                            PhysicalPath = Path.GetTempPath() + "\\Solution Items",
                            Name = "Solution Items"
                        }
                    }
                };

                this.store = new DslTestStore<ProductStateStoreDomainModel>();

                this.toolkitInfo = new Mock<IInstalledToolkitInfo>
                {
                    DefaultValue = DefaultValue.Mock
                };
                this.toolkitInfo.Setup(f => f.Id).Returns("foo");
                this.toolkitInfo.Setup(f => f.Version).Returns(new Version("1.0.0.0"));
                this.toolkitInfo.Setup(f => f.Schema.Pattern.ExtensionId).Returns("foo");

                var installedFactories = new[] { this.toolkitInfo.Object };

                var componentModel = new Mock<IComponentModel>();
                componentModel.Setup(cm => cm.GetService<IEnumerable<IInstalledToolkitInfo>>()).Returns(installedFactories);
                componentModel.Setup(cm => cm.GetService<IToolkitRepository>()).Returns(Mock.Of<IToolkitRepository>());

                var serviceProvider = Mock.Get(this.store.ServiceProvider);
                serviceProvider.Setup(s => s.GetService(typeof(SComponentModel))).Returns(componentModel.Object);
                serviceProvider.Setup(s => s.GetService(typeof(ISolution))).Returns(this.solution);

                this.shellEvents = new Mock<IShellEvents>();
                this.shellEvents.Setup(x => x.IsInitialized).Returns(true);

                this.manager = new TestPatternManager(this.store.ServiceProvider, this.solution, this.shellEvents.Object, this.solutionEvents.Object, this.itemEvents.Object, installedFactories, this.messageService.Object);
            }

            [TestCleanup]
            public void Cleanup()
            {
                if (this.manager.IsOpen)
                {
                    this.manager.Products.ToList().ForEach(p => this.manager.DeleteProduct(p));
                    this.manager.Save();
                }

                this.store.Dispose();
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingAProductWithNullToolkitInfo_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => this.manager.CreateProduct(null, "foo"));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingAProductWithNullName_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => this.manager.CreateProduct(new Mock<IInstalledToolkitInfo>().Object, null));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingAProductWithEmptyName_ThenThrowsArgumentException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => this.manager.CreateProduct(new Mock<IInstalledToolkitInfo>().Object, string.Empty));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenDeletingANullProduct_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => this.manager.DeleteProduct((IProduct)null));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenDeletingANullProductName_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => this.manager.Delete((string)null));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenDeletingAnEmptyProductName_ThenThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => this.manager.Delete(string.Empty));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingProduct_ThenRaisesElementInstantiatedEvent()
            {
                this.manager.Open(RuntimeStoreFilename);
                IProduct instantiatedProduct = null;
                this.manager.ElementInstantiated += (sender, args) => instantiatedProduct = (IProduct)args.Value;

                this.manager.CreateProduct(this.toolkitInfo.Object, "toolkit");

                Assert.NotNull(instantiatedProduct);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenSavingCreatedProduct_ThenRaisesStoreSavedEvent()
            {
                this.manager.Open(RuntimeStoreFilename);
                this.manager.CreateProduct(this.toolkitInfo.Object, "toolkit");

                var managerSavedCalled = false;
                var storeSavedCalled = false;

                this.manager.StoreSaved += (sender, args) => managerSavedCalled = true;
                this.manager.Store.Saved += (sender, args) => storeSavedCalled = true;

                this.manager.Save();

                Assert.True(managerSavedCalled);
                Assert.True(storeSavedCalled);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenCreatingProduct_ThenDoesNotRaisePropertyChangedEvents()
            {
                this.manager.Open(RuntimeStoreFilename);
                bool changed = false;
                this.manager.PropertyChanged += (sender, args) => changed = true;

                this.manager.CreateProduct(this.toolkitInfo.Object, "propertyChangedTest");

                Assert.False(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningStateFile_ThenRaisesIsOpenChanged()
            {
                var changed = false;

                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.manager.Open(new FileInfo(RuntimeStoreFilename).FullName);

                Assert.True(changed);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Dont")]
            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningStateFileAndAlreadyOpened_SavesExistingStateEvenIfNoSolutionIsOpened()
            {
                var tempFile = Path.Combine(solutionItemsDir, Guid.NewGuid().ToString());
                File.Copy(new FileInfo(RuntimeStoreFilename).FullName, tempFile, true);

                this.manager.Open(tempFile);

                Assert.Equal(tempFile, this.manager.StoreFile);

                var product = this.manager.CreateProduct(this.toolkitInfo.Object, "Foo");

                this.manager.Open(new FileInfo(RuntimeStoreFilename).FullName);

                Assert.True(File.ReadAllText(tempFile).Contains(product.Id.ToString()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningInvalidStateFile_ThenIsOpenChangedIsNotRaised()
            {
                var changed = false;

                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.manager.Open(new FileInfo(@"Core\Invalid" + StoreConstants.RuntimeStoreExtension).FullName);

                Assert.False(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningOldVersionWithoutUpgradeStateFile_ThenIsOpenChangedIsNotRaised()
            {
                var changed = false;

                this.messageService.Setup(m => m.PromptWarning(It.IsAny<string>())).Returns(false);

                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.manager.Open(new FileInfo(@"Core\OldVersion" + StoreConstants.RuntimeStoreExtension).FullName);

                Assert.False(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningOldVersionWithUpgradeStateFile_ThenIsOpenChangedIsNotRaised()
            {
                var changed = false;

                this.messageService.Setup(m => m.PromptWarning(It.IsAny<string>())).Returns(true);

                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.manager.Open(new FileInfo(@"Core\OldVersion" + StoreConstants.RuntimeStoreExtension).FullName);

                Assert.True(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningInvalidVersionStateFile_ThenIsOpenChangedIsNotRaised()
            {
                var changed = false;

                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.manager.Open(new FileInfo(@"Core\InvalidVersion" + StoreConstants.RuntimeStoreExtension).FullName);

                Assert.False(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenSavingAClosedManager_ThenThrowsInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(() => this.manager.Save());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenClosingAClosedManager_ThenThrowsInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(() => this.manager.Close());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenRetrievingProductsFromClosedManager_ThenReturnsEmptyEnumeration()
            {
                Assert.NotNull(this.manager.Products);
                Assert.Equal(0, this.manager.Products.Count());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionWithNoState_ThenDoesNotRiseIsOpenChanged()
            {
                var changed = false;
                this.manager.IsOpenChanged += (s, e) => changed = true;

                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(this.solution));

                Assert.False(changed);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionButShellNotInitialized_ThenWaitsForShellInitialized()
            {
                var stateFile = new FileInfo(RuntimeStoreFilename).FullName;

                // Add the product state file to cause the auto-open behavior.
                this.solution.Items.OfType<SolutionFolder>().First().Items.Add(new Item { PhysicalPath = stateFile });

                // Shell is uninitialized.
                this.shellEvents.Setup(x => x.IsInitialized).Returns(false);

                // Raise the event.
                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(this.solution));

                Assert.False(this.manager.IsOpen);

                // Initialize the shell
                this.shellEvents.Setup(x => x.IsInitialized).Returns(true);
                this.shellEvents.Raise(x => x.ShellInitialized += null, EventArgs.Empty);

                Assert.True(this.manager.IsOpen);
                Assert.Equal(stateFile, this.manager.StoreFile);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionWithOneStateFile_ThenOpensItInManager()
            {
                var stateFile = new FileInfo(RuntimeStoreFilename).FullName;

                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(new Solution
                {
                    PhysicalPath = "Bar.sln",
                    Items = 
                    {
                        new SolutionFolder
                        {
                            Name = "Solution Items", 
                            Items = 
                            {
                                new Item
                                {
                                    PhysicalPath = stateFile
                                }
                            }
                        }
                    }
                }));

                Assert.Equal(stateFile, this.manager.StoreFile);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionWithStateFileUnderOtherFolder_ThenDoesNotOpenItInManager()
            {
                var stateFile = new FileInfo(RuntimeStoreFilename).FullName;

                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(new Solution
                {
                    PhysicalPath = "Bar.sln",
                    Items = 
                    {
                        new SolutionFolder
                        {
                            Name = "My Folder", 
                            Items = 
                            {
                                new Item
                                {
                                    PhysicalPath = stateFile
                                }
                            }
                        }
                    }
                }));

                Assert.False(this.manager.IsOpen);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionWithMultipleStateFiles_ThenOpensTheOneMatchingTheSolutionName()
            {
                var stateFile = new FileInfo(RuntimeStoreFilename).FullName;

                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(new Solution
                {
                    Name = "Blank.gen.sln",
                    PhysicalPath = "Blank.gen.sln",
                    Items = 
                    {
                        new SolutionFolder
                        {
                            Name = "Solution Items", 
                            Items = 
                            {
                                new Item { PhysicalPath = "Foo" + StoreConstants.RuntimeStoreExtension },
                                new Item { PhysicalPath = stateFile },
                            }
                        }
                    }
                }));

                Assert.Equal(stateFile, this.manager.StoreFile);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOpeningSolutionWithMultipleStateFiles_ThenOpensFirstOneIfNoSolutionNameMatch()
            {
                var stateFile = new FileInfo(RuntimeStoreFilename).FullName;

                this.solutionEvents.Raise(x => x.SolutionOpened += null, new SolutionEventArgs(new Solution
                {
                    Name = "Baz.sln",
                    PhysicalPath = "Baz.sln",
                    Items = 
                    {
                        new SolutionFolder
                        {
                            Name = "Solution Items", 
                            Items = 
                            {
                                new Item { PhysicalPath = stateFile },
                                new Item { PhysicalPath = "Foo" + StoreConstants.RuntimeStoreExtension },
                                new Item { PhysicalPath = "Bar" + StoreConstants.RuntimeStoreExtension },
                            }
                        }
                    }
                }));

                Assert.Equal(stateFile, this.manager.StoreFile);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenClosingSolution_ThenNoOpIfNotOpened()
            {
                this.solutionEvents.Raise(x => x.SolutionClosing += null, new SolutionEventArgs(new Solution()));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenClosingSolution_ThenClosesManagerIfOpened()
            {
                this.manager.Open(new FileInfo(RuntimeStoreFilename).FullName);

                Assert.True(this.manager.IsOpen);

                this.solutionEvents.Raise(x => x.SolutionClosing += null, new SolutionEventArgs(new Solution()));

                Assert.False(this.manager.IsOpen);
            }

            private class TestPatternManager : PatternManager
            {
                public TestPatternManager(IServiceProvider serviceProvider, ISolution solution, IShellEvents shellEvents, ISolutionEvents solutionEvents, IItemEvents itemEvents, IEnumerable<IInstalledToolkitInfo> installedFactories, IUserMessageService messageService)
                    : base(serviceProvider, solution, shellEvents, solutionEvents, itemEvents, installedFactories, messageService)
                {
                }

                protected override IItemContainer AddStateToSolution(IItemContainer targetFolder, string targetName, string sourceFile)
                {
                    File.WriteAllText(Path.Combine(targetFolder.PhysicalPath, targetName), File.ReadAllText(sourceFile));

                    return Mocks.Of<IItemContainer>().First(x => x.Name == targetName && x.Parent == targetFolder && x.PhysicalPath == sourceFile);
                }
            }
        }
    }
}