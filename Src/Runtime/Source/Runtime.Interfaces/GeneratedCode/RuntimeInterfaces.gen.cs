﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NuPattern.Runtime
{
	/// <summary>
	/// The state of all products in the solution.
	/// </summary>
	partial interface IProductState : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IProductState, object>> propertyExpression, Action<IProductState> callbackAction);
	}
	
	/// <summary>
	/// The state of all products in the solution.
	/// </summary>
	[Description("The state of all products in the solution.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IProductState : ISupportTransaction 
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Hidden]
		global::System.Guid Id { get; }
		
		/// <summary>
		/// The products in this solution.
		/// </summary>
		[Description("The products in this solution.")]
		IEnumerable<IProduct> Products { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IProduct"/> with an optional initializer to perform 
		/// object initialization within the creation transaction. The child is automatically added to the 
		///	<see cref="Products"/> property.
		/// </summary>
		IProduct CreateProduct(Action<IProduct> initializer = null);
	
		/// <summary>
		/// Deletes an element from the store.
		/// </summary>
		void Delete();
	}
	
	/// <summary>
	/// A property of an element.
	/// </summary>
	partial interface IProperty : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IProperty, object>> propertyExpression, Action<IProperty> callbackAction);
	}
	
	/// <summary>
	/// A property of an element.
	/// </summary>
	[Description("A property of an element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IProperty : IInstanceBase 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IPropertyInfo Info { get; }
		
		/// <summary>
		/// The current serialized value of the property. Use Value to get the typed value.
		/// </summary>
		[Description("The current serialized value of the property. Use Value to get the typed value.")]
		[ReadOnly(true)]
		global::System.String RawValue { get; set; }
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		[Hidden()]
		IProductElement Owner { get; set; }
	}
	
	/// <summary>
	/// A container for elements in a view.
	/// </summary>
	partial interface ICollection : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<ICollection, object>> propertyExpression, Action<ICollection> callbackAction);
	}
	
	/// <summary>
	/// A container for elements in a view.
	/// </summary>
	[Description("A container for elements in a view.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface ICollection : IAbstractElement 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new ICollectionInfo Info { get; }
	}
	
	/// <summary>
	/// An element of a view.
	/// </summary>
	partial interface IElement : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IElement, object>> propertyExpression, Action<IElement> callbackAction);
	}
	
	/// <summary>
	/// An element of a view.
	/// </summary>
	[Description("An element of a view.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IElement : IAbstractElement 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IElementInfo Info { get; }
	}
	
	/// <summary>
	/// An element within the product.
	/// </summary>
	partial interface IProductElement : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IProductElement, object>> propertyExpression, Action<IProductElement> callbackAction);
	}
	
	/// <summary>
	/// An element within the product.
	/// </summary>
	[Description("An element within the product.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IProductElement : IInstanceBase 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IPatternElementInfo Info { get; }
		
		/// <summary>
		/// The name of this element instance.
		/// </summary>
		[Description("The name of this element instance.")]
		[System.ComponentModel.ParenthesizePropertyNameAttribute(true)]
		global::System.String InstanceName { get; set; }
		
		/// <summary>
		/// The order of this element relative to its siblings.
		/// </summary>
		[Description("The order of this element relative to its siblings.")]
		[ReadOnly(true)]
		global::System.Double InstanceOrder { get; set; }
		
		/// <summary>
		/// The properties of this element.
		/// </summary>
		[Description("The properties of this element.")]
		[Hidden()]
		IEnumerable<IProperty> Properties { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IProperty"/> with an optional initializer to perform 
		/// object initialization within the creation transaction. The child is automatically added to the 
		///	<see cref="Properties"/> property.
		/// </summary>
		IProperty CreateProperty(Action<IProperty> initializer = null);
		
		/// <summary>
		/// The references of this element.
		/// </summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IReference"/> with an optional initializer to perform 
		/// object initialization within the creation transaction. The child is automatically added to the 
		///	<see cref="References"/> property.
		/// </summary>
		IReference CreateReference(Action<IReference> initializer = null);
	}
	
	/// <summary>
	/// A product instance in the solution.
	/// </summary>
	partial interface IProduct : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IProduct, object>> propertyExpression, Action<IProduct> callbackAction);
	}
	
	/// <summary>
	/// A product instance in the solution.
	/// </summary>
	[Description("A product instance in the solution.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IProduct : IProductElement 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IPatternInfo Info { get; }
		
		/// <summary>
		/// The identifier of the Visual Studio extension deploying the product.
		/// </summary>
		[Description("The identifier of the Visual Studio extension deploying the product.")]
		[Hidden()]
		global::System.String ExtensionId { get; set; }
		
		/// <summary>
		/// The name of the Visual Studio extension that deploys this product.
		/// </summary>
		[Description("The name of the Visual Studio extension that deploys this product.")]
		[Hidden()]
		global::System.String ExtensionName { get; }
		
		/// <summary>
		/// The author of this product.
		/// </summary>
		[Description("The author of this product.")]
		[Hidden()]
		global::System.String Author { get; }
		
		/// <summary>
		/// The version of this product.
		/// </summary>
		[Description("The version of this product.")]
		[Hidden()]
		global::System.String Version { get; }
		
		/// <summary>
		/// The views of this product.
		/// </summary>
		[Description("The views of this product.")]
		[Hidden()]
		IEnumerable<IView> Views { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IView"/> with an optional initializer to perform 
		/// object initialization within the creation transaction. The child is automatically added to the 
		///	<see cref="Views"/> property.
		/// </summary>
		IView CreateView(Action<IView> initializer = null);
		
		/// <summary>
		/// The owning state model.
		/// </summary>
		[Description("The owning state model.")]
		[Hidden()]
		IProductState ProductState { get; set; }
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		[Hidden()]
		IAbstractElement Owner { get; set; }
		
		/// <summary>
		/// The owning view.
		/// </summary>
		[Description("The owning view.")]
		[Hidden()]
		IView View { get; set; }
	}
	
	/// <summary>
	/// A view of a product instance.
	/// </summary>
	partial interface IView : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IView, object>> propertyExpression, Action<IView> callbackAction);
	}
	
	/// <summary>
	/// A view of a product instance.
	/// </summary>
	[Description("A view of a product instance.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IView : IInstanceBase 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IViewInfo Info { get; }
		
		/// <summary>
		/// The owning product.
		/// </summary>
		[Description("The owning product.")]
		[Hidden()]
		IProduct Product { get; set; }
	}
	
	/// <summary>
	/// A child collection or element.
	/// </summary>
	partial interface IAbstractElement : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IAbstractElement, object>> propertyExpression, Action<IAbstractElement> callbackAction);
	}
	
	/// <summary>
	/// A child collection or element.
	/// </summary>
	[Description("A child collection or element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IAbstractElement : IProductElement 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		new IAbstractElementInfo Info { get; }
		
		/// <summary>
		/// The owning view.
		/// </summary>
		[Description("The owning view.")]
		[Hidden()]
		IView View { get; set; }
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		[Hidden()]
		IAbstractElement Owner { get; set; }
	}
	
	/// <summary>
	/// An element instance.
	/// </summary>
	partial interface IInstanceBase : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IInstanceBase, object>> propertyExpression, Action<IInstanceBase> callbackAction);
	}
	
	/// <summary>
	/// An element instance.
	/// </summary>
	[Description("An element instance.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IInstanceBase : ISupportTransaction 
	{
		/// <summary>
		/// Provides read-only access to the schema information for this element.
		/// </summary>
		[Description("Provides read-only access to the schema information for this element.")]
		[ReadOnly(true)]
		[Hidden]
		INamedElementInfo Info { get; }
	
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Hidden]
		global::System.Guid Id { get; }
		
		/// <summary>
		/// The model element identifier in the owning definition.
		/// </summary>
		[Description("The model element identifier in the owning definition.")]
		[Hidden()]
		[ReadOnly(true)]
		global::System.Guid DefinitionId { get; set; }
		
		/// <summary>
		/// Informational-only rendering of the defining element referenced by the DefinitionId property.
		/// </summary>
		[Description("Informational-only rendering of the defining element referenced by the DefinitionId property.")]
		[Hidden()]
		global::System.String DefinitionName { get; set; }
		
		/// <summary>
		/// Notes for this element.
		/// </summary>
		[Description("Notes for this element.")]
		[System.ComponentModel.Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
		global::System.String Notes { get; set; }
	
		/// <summary>
		/// Deletes an element from the store.
		/// </summary>
		void Delete();
	}
	
	/// <summary>
	/// A reference to external data or service.
	/// </summary>
	partial interface IReference : INotifyPropertyChanged
	{
	    /// <summary>
	    /// Subscribes to changes in the property referenced in the given 
	    /// <paramref name="propertyExpression"/> with the given 
	    /// <paramref name="callbackAction"/> delegate.
	    /// </summary>
	    /// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
	    /// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
	    IDisposable SubscribeChanged(Expression<Func<IReference, object>> propertyExpression, Action<IReference> callbackAction);
	}
	
	/// <summary>
	/// A reference to external data or service.
	/// </summary>
	[Description("A reference to external data or service.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IReference : ISupportTransaction 
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Hidden]
		global::System.Guid Id { get; }
		
		/// <summary>
		/// The value of the reference, having meaning to the kind of the reference.
		/// </summary>
		[Description("The value of the reference, having meaning to the kind of the reference.")]
		global::System.String Value { get; set; }
		
		/// <summary>
		/// The kind of the reference, used to classify the reference. If this is the full type name of a class, then the class is used to provide the display characteristics of this reference.
		/// </summary>
		[Description("The kind of the reference, used to classify the reference. If this is the full type name of a class, then the class is used to provide the display characteristics of this reference.")]
		global::System.String Kind { get; set; }
		
		/// <summary>
		/// Provides arbitrary annotations on a reference, typically used by automation.
		/// </summary>
		[Description("Provides arbitrary annotations on a reference, typically used by automation.")]
		global::System.String Tag { get; set; }
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		IProductElement Owner { get; set; }
	
		/// <summary>
		/// Deletes an element from the store.
		/// </summary>
		void Delete();
	}
}
