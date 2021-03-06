﻿using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuPattern.Library.Conditions;
using NuPattern.Runtime;

namespace NuPattern.Library.UnitTests.Conditions
{
    [TestClass]
    public class ElementPropertyExistsConditionSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenNoContext
        {
            private ElementPropertyExistsCondition condition;

            [TestInitialize]
            public void InitializeContext()
            {
                this.condition = new ElementPropertyExistsCondition();
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenOwnerIsNull_ThenEvaluateThrows()
            {
                Assert.Throws<ValidationException>(() => this.condition.Evaluate());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenPropertyNameIsNullOrEmpty_ThenEvaluateThrows()
            {
                Mock<IProductElement> mockOwner = new Mock<IProductElement>();
                this.condition.CurrentElement = mockOwner.Object;

                Assert.Throws<ValidationException>(() => this.condition.Evaluate());
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenPropertyNotFoundOnOwner_ThenEvaluateThrows()
            {
                Mock<IProductElement> mockOwner = new Mock<IProductElement>();
                mockOwner.Setup(owner => owner.Properties).Returns(new IProperty[0]);
                this.condition.CurrentElement = mockOwner.Object;

                Assert.Throws<ValidationException>(() => this.condition.Evaluate());
            }
        }

        [TestClass]
        public class GivenAnOwnerWithAProperty
        {
            private ElementPropertyExistsCondition condition;
            private Mock<IProperty> mockProperty;

            [TestInitialize]
            public void InitializeContext()
            {
                this.condition = new ElementPropertyExistsCondition();

                string propertyName = "TestPropertyName";

                this.mockProperty = new Mock<IProperty>();
                this.mockProperty.SetupGet(property => property.Info.Name).Returns(propertyName);
                Mock<IProductElement> mockOwner = new Mock<IProductElement>();
                mockOwner.Setup(owner => owner.Properties).Returns(new IProperty[] { this.mockProperty.Object });
                this.condition.CurrentElement = mockOwner.Object;
                this.condition.PropertyName = propertyName;
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenMustHaveValueIsFalse_ThenEvaluateReturnsTrue()
            {
                this.condition.MustHaveValue = false;
                var result = this.condition.Evaluate();

                Assert.True(result);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenMustHaveValueIsTrueAndPropertyValueIsNull_ThenEvaluateReturnsFalse()
            {
                this.mockProperty.SetupGet(property => property.RawValue).Returns((string)null);

                this.condition.MustHaveValue = true;
                var result = this.condition.Evaluate();

                mockProperty.VerifyGet(property => property.RawValue, Times.Once());
                Assert.False(result);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenMustHaveValueIsTrueAndPropertyValueIsEmpty_ThenEvaluateReturnsFalse()
            {
                this.mockProperty.SetupGet(property => property.RawValue).Returns(string.Empty);

                this.condition.MustHaveValue = true;
                var result = this.condition.Evaluate();

                mockProperty.VerifyGet(property => property.RawValue, Times.Once());
                Assert.False(result);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenMustHaveValueIsTrueAndPropertyValueIsNotNull_ThenEvaluateReturnsTrue()
            {
                this.mockProperty.SetupGet(property => property.RawValue).Returns("Foo");

                this.condition.MustHaveValue = true;
                var result = this.condition.Evaluate();

                mockProperty.VerifyGet(property => property.RawValue, Times.Once());
                Assert.True(result);
            }
        }
    }
}
