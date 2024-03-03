## KlonsLib.Design.GenericCollectionEditor

Custom type editors written for .Netframework (4.x) won't work with the new .Net WinForms designer.
This project attempts to provide a generic collection editor which can be used with any collection that can contain items with different types.

GenericCollectionEditor is not needed for collections containing items of one type.

Types for the new items to GenericCollectionEditor are provided implementing IGenericCollectionEditorTarget within collections class.

For Visual Studio 2022 to pick up this collection editor, package KlonsLib.Design has to be installed in the project where [Editor("GenericCollectionEditor", (typeof(UITypeEditor)))] and IGenericCollectionEditorTarget is used.

Package is also backwards compatible with .Netfranework projects (net472).

The KlonsLib.Design solution contains a project TestForm which demonstrates how to implement editable collection and setup the project for building with multiple target frameworks (net472; net7-windows).


## KlonsLib.Design.GenericStringDropDownEditor

Enables editing of string properties in PropertyGrid with drop down list box. Items for drop down list box are provided through IGenericStringDropDownEditorTarget implemented in the class owning the property.

