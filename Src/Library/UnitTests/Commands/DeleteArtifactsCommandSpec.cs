﻿using System;
using EnvDTE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuPattern.Library.Commands;
using NuPattern.Runtime;
using NuPattern.Runtime.References;
using NuPattern.Runtime.UI;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Library.UnitTests.Commands
{
    [TestClass]
    public class DeleteArtifactsCommandSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenNoContext
        {
            private DeleteArtifactsCommand command;
            private Mock<IUriReferenceService> uriService;
            private Mock<IProductElement> currentElement;

            [TestInitialize]
            public void InitializeContext()
            {
                this.uriService = new Mock<IUriReferenceService>();
                this.currentElement = new Mock<IProductElement>();
                this.command = new DeleteArtifactsCommand
                    {
                        CurrentElement = this.currentElement.Object,
                        UriReferenceService = this.uriService.Object,
                        Solution = new Mock<ISolution>().Object,
                        SolutionSelector = new Mock<ISolutionSelector>().Object,
                    };
            }

            [TestMethod, TestCategory("Unit")]
            public void ThenActionIsDeleteAll()
            {
                Assert.Equal(DeleteAction.DeleteAll, this.command.Action);
            }

            [TestMethod, TestCategory("Unit")]
            public void ThenExecuteReturnsNoItems()
            {
                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenReferencesAreInvalid_ThenExecuteReturnsNoItems()
            {
                this.currentElement.Setup(ce => ce.References).Returns(new[] { Mock.Of<IReference>(re => re.Kind == typeof(SolutionArtifactLinkReference).FullName && re.Value == "solution://foo") });

                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.IsAny<Uri>()), Times.AtLeastOnce());
            }
        }

        [TestClass]
        public class GivenASolutionFileAndDeleteAction
        {
            private DeleteArtifactsCommand command;
            private Mock<IUriReferenceService> uriService;
            private Mock<IProductElement> currentElement;
            private Mock<IItem> solutionItem;
            private Mock<EnvDTE.ProjectItem> projectItem;

            [TestInitialize]
            public void InitializeContext()
            {
                this.projectItem = new Mock<ProjectItem>();
                this.solutionItem = new Mock<IItem>();
                this.solutionItem.Setup(si => si.Name).Returns("foo.cs");
                this.solutionItem.Setup(si => si.As<EnvDTE.ProjectItem>()).Returns(this.projectItem.Object);
                this.uriService = new Mock<IUriReferenceService>();
                this.uriService.Setup(us => us.ResolveUri<IItemContainer>(It.IsAny<Uri>())).Returns(solutionItem.Object);
                this.currentElement = new Mock<IProductElement>();

                this.currentElement.Setup(ce => ce.References).Returns(new[]
                {
                    Mock.Of<IReference>(re => 
                        re.Kind == typeof(SolutionArtifactLinkReference).FullName 
                        && re.Value == "solution://foo"
                        && re.Tag =="foo"),
                    Mock.Of<IReference>(re => 
                        re.Kind == typeof(SolutionArtifactLinkReference).FullName 
                        && re.Value == "solution://bar"
                        && re.Tag =="bar")
                });

                this.command = new DeleteArtifactsCommand
                {
                    Action = DeleteAction.DeleteAll,
                    CurrentElement = this.currentElement.Object,
                    UriReferenceService = this.uriService.Object,
                    Solution = new Mock<ISolution>().Object,
                    SolutionSelector = new Mock<ISolutionSelector>().Object,
                };
            }

            [TestMethod, TestCategory("Unit")]
            public void ThenDeletesAllSolutionItems()
            {
                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://foo")), Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://bar")), Times.AtLeastOnce());
                this.projectItem.Verify(pe => pe.Delete(), Times.Exactly(2));
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenFilterTagButNotMatchReference_ThenDeletesNoSolutionItems()
            {
                this.command.Tag = "foo2";
                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://foo")), Times.Never());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://bar")), Times.Never());
                this.projectItem.Verify(pe => pe.Delete(), Times.Never());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenFilterTagAndMatchReference_ThenDeletesSomeSolutionItems()
            {
                this.command.Tag = "foo,bar";
                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://foo")), Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://bar")), Times.AtLeastOnce());
                this.projectItem.Verify(pe => pe.Delete(), Times.Exactly(2));
            }
        }

        [TestClass]
        public class GivenASolutionFileAndPromptAction
        {
            private DeleteArtifactsCommand command;
            private Mock<IUriReferenceService> uriService;
            private Mock<IProductElement> currentElement;
            private Mock<IItem> solutionItem;
            private Mock<EnvDTE.ProjectItem> projectItem;
            private Mock<ISolutionSelector> solutionSelector;

            [TestInitialize]
            public void InitializeContext()
            {
                this.solutionSelector = new Mock<ISolutionSelector>();
                this.solutionSelector.Setup(ss => ss.Filter).Returns(new Mock<IPickerFilter>().Object);
                this.projectItem = new Mock<ProjectItem>();
                this.solutionItem = new Mock<IItem>();
                this.solutionItem.Setup(si => si.Name).Returns("foo.cs");
                this.solutionItem.Setup(si => si.As<EnvDTE.ProjectItem>()).Returns(this.projectItem.Object);
                this.uriService = new Mock<IUriReferenceService>();
                this.uriService.Setup(us => us.ResolveUri<IItemContainer>(It.IsAny<Uri>())).Returns(solutionItem.Object);
                this.currentElement = new Mock<IProductElement>();
                this.currentElement.Setup(ce => ce.References).Returns(new[] { Mock.Of<IReference>(re => re.Kind == typeof(SolutionArtifactLinkReference).FullName && re.Value == "solution://foo") });

                this.command = new DeleteArtifactsCommand
                {
                    Action = DeleteAction.PromptUser,
                    CurrentElement = this.currentElement.Object,
                    UriReferenceService = this.uriService.Object,
                    Solution = new Mock<ISolution>().Object,
                    SolutionSelector = this.solutionSelector.Object,
                };
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenSelectorReturnsFalse_ThenDeletesNoItems()
            {
                this.solutionSelector.Setup(ss => ss.ShowDialog()).Returns(false);

                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://foo")), Times.AtLeastOnce());
                this.projectItem.Verify(pe => pe.Delete(), Times.Never());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenSelectorReturnsTrue_ThenDeletesItems()
            {
                var selectedProjectItem = new Mock<EnvDTE.ProjectItem>();
                var selectedItem = new Mock<IItem>();
                selectedItem.Setup(si => si.As<EnvDTE.ProjectItem>()).Returns(selectedProjectItem.Object);
                this.solutionSelector.Setup(ss => ss.ShowDialog()).Returns(true);
                this.solutionSelector.Setup(ss => ss.SelectedItems).Returns(new[] { selectedItem.Object });

                this.command.Execute();

                this.currentElement.VerifyGet(ce => ce.References, Times.AtLeastOnce());
                this.uriService.Verify(us => us.ResolveUri<IItemContainer>(It.Is<Uri>(x => x.OriginalString == "solution://foo")), Times.AtLeastOnce());
                selectedProjectItem.Verify(pe => pe.Delete(), Times.Once());
            }
        }
    }
}
