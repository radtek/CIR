//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2006 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Reflection;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Type converter class which is used during design time to serialize a correct constructor call for an entity factory2. 
	/// </summary>
	public class EntityFactory2Converter : TypeConverter 
	{
		/// <summary>
		/// Determines whether this instance [can convert to] the specified context.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns>
		/// 	<c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
		{
			if (destinationType == typeof(InstanceDescriptor)) 
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		/// <summary>
		/// Converts to the specified type, if applicable.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="culture">Culture.</param>
		/// <param name="value">Value.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns></returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) 
		{
			IEntityFactory2 factory = value as IEntityFactory2;
			if (destinationType == typeof(InstanceDescriptor) && (value!=null)) 
			{
				ConstructorInfo ctor = value.GetType().GetConstructor(new Type[] {});
				if (ctor != null) 
				{
					return new InstanceDescriptor(ctor, new object[] {});
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);      
		}
	}

	
	/// <summary>
	/// Type converter class which is used during design time to serialize a correct constructor call for an entity factory. 
	/// </summary>
	public class EntityFactoryConverter : TypeConverter 
	{
		/// <summary>
		/// Determines whether this instance [can convert to] the specified context.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns>
		/// 	<c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
		{
			if (destinationType == typeof(InstanceDescriptor)) 
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		/// <summary>
		/// Converts to the specified type, if applicable.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="culture">Culture.</param>
		/// <param name="value">Value.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns></returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) 
		{
			IEntityFactory factory = value as IEntityFactory;
			if (destinationType == typeof(InstanceDescriptor) && (value !=null)) 
			{
				ConstructorInfo ctor = value.GetType().GetConstructor(new Type[] {});
				if (ctor != null) 
				{
					return new InstanceDescriptor(ctor, new object[] {});
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);      
		}
	}


	/// <summary>
	/// Toolbox item for EntityCollectionBase2 derived classes. This class makes sure the designer pops up the first time an entity collection
	/// is dragged onto the form.
	/// </summary>
	[Serializable]
	public class EntityCollectionToolboxItem : System.Drawing.Design.ToolboxItem
	{
		/// <summary>
		/// Creates a new <see cref="EntityCollectionToolboxItem"/> instance.
		/// </summary>
		/// <param name="typeToRepresent">Type to represent.</param>
		public EntityCollectionToolboxItem(Type typeToRepresent) : base(typeToRepresent)
		{
		}

		/// <summary>
		/// Creates a new <see cref="EntityCollectionToolboxItem"/> instance.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
		private EntityCollectionToolboxItem(SerializationInfo info, StreamingContext context)
		{
			this.Deserialize(info, context);
		}
 
		/// <summary>
		/// Creates the components core.
		/// </summary>
		/// <param name="host">Host.</param>
		protected override IComponent[] CreateComponentsCore(IDesignerHost host)
		{
			Type entityCollectionType = Type.GetType(base.TypeName);

			if(entityCollectionType==null)
			{
				MessageBox.Show(null, "Could not resolve the type '" + base.TypeName + "', which is likely caused by a missing reference to the assembly '" + base.AssemblyName + "'. ", "Missing reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			IComponent entityCollectionComponent = (IComponent)Activator.CreateInstance(entityCollectionType);
			host.Container.Add(entityCollectionComponent);

			// Show selector. 
			EntityCollectionComponentDesigner designer = new EntityCollectionComponentDesigner();
			IEntityFactory2 factory = designer.SelectEntityFactoryToUse(entityCollectionComponent, ((EntityCollectionBase2)entityCollectionComponent).EntityFactoryToUse);
			((EntityCollectionBase2)entityCollectionComponent).EntityFactoryToUse = factory;

			// return the created component.
			return new IComponent[1] { entityCollectionComponent } ;
		}
	}


	/// <summary>
	/// Simple designer class for adapter collections to set the entity factory when no factory is set.
	/// </summary>
	public class EntityCollectionComponentDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		#region Static Members
		/// <summary>
		/// Variable which is set as soon as the code determines the objects are used in design mode, instead of runtime mode. 
		/// </summary>
		internal static bool InDesignMode = false;
		#endregion

		/// <summary>
		/// Creates a new <see cref="EntityCollectionComponentDesigner"/> instance.
		/// </summary>
		public EntityCollectionComponentDesigner()
		{
				EntityCollectionComponentDesigner.InDesignMode = true;
		}

		/// <summary>
		/// This method provides an opportunity to perform processing when a designer is initialized.
		/// The component parameter is the component that the designer is associated with.
		/// </summary>
		/// <param name="component">Component.</param>
		public override void Initialize(System.ComponentModel.IComponent component)
		{
			base.Initialize(component);
		}


		/// <summary>
		/// Gets the verbs.
		/// </summary>
		/// <value></value>
		public override System.ComponentModel.Design.DesignerVerbCollection Verbs
		{
			get
			{
				return new DesignerVerbCollection( new DesignerVerb[] { new DesignerVerb("Set EntityFactory to use", new EventHandler(this.OnSetEntityFactory)) } );
			}
		}

		/// <summary>
		/// Called when the user clicks the Set EntityFactory to use command in the menu
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnSetEntityFactory(object sender, EventArgs e)
		{
			IEntityFactory2 oldValue = ((EntityCollectionBase2)this.Component).EntityFactoryToUse;
			IEntityFactory2 factory = SelectEntityFactoryToUse(this.Component, oldValue);
			((EntityCollectionBase2)this.Component).EntityFactoryToUse = factory;
			if( (factory == null) && (oldValue == null) )
			{
				return;
			}
			if( (factory != null) && (oldValue != null) && factory.GetType().Equals( oldValue.GetType() ) )
			{
				return;
			}
			// different
			base.RaiseComponentChanged(
				TypeDescriptor.GetProperties(this.Component).Find("EntityFactoryToUse", false), 
				oldValue, factory);
		}


		/// <summary>
		/// Selects the entity factory to use for the EntityCollectionBase2 instance which is the component.
		/// </summary>
		/// <param name="entityCollectionComponent">Entity collection component.</param>
		/// <param name="currentFactory">Current factory.</param>
		/// <returns></returns>
		public IEntityFactory2 SelectEntityFactoryToUse(IComponent entityCollectionComponent, IEntityFactory2 currentFactory)
		{
			// get the list of factories in the assembly 'this' is in. 
			ArrayList factoriesFound = new ArrayList();
			Assembly assemblyOfComponent = entityCollectionComponent.GetType().Assembly;
			Type[] types = assemblyOfComponent.GetTypes();
			foreach(Type currentType in types)
			{
				if(currentType.GetInterface("IEntityFactory2")!=null)
				{
					factoriesFound.Add(currentType);
				}
			}

			// show selector.
			EntityFactorySelector selector = new EntityFactorySelector();
			selector.SetFactoriesComboBox(factoriesFound, currentFactory);
			selector.ShowDialog();
			IEntityFactory2 factoryToReturn = null;
			if(!selector.CancelClicked)
			{
				Type selectedFactoryType = selector.SelectedFactory;
				if(selectedFactoryType!=null)
				{
					// create instance
					factoryToReturn = (IEntityFactory2)Activator.CreateInstance(selectedFactoryType);
				}
			}

			return factoryToReturn;
		}
	}
}
