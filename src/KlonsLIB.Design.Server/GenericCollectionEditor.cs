using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.DotNet.DesignTools.Editors;

namespace KlonsLIB.Design.Server;

internal partial class GenericCollectionEditor : CollectionEditor
{
    public GenericCollectionEditor(IServiceProvider serviceProvider, Type collectionType)
            : base(serviceProvider, collectionType)
    {
    }

    protected override CollectionEditorViewModel BeginEditValue(ITypeDescriptorContext context, object value)
    {
        editedObject = value;
        return base.BeginEditValue(context!, value);
    }

    private object? editedObject = null;

    protected override Type[] CreateNewItemTypes()
    {
        var o = editedObject as IGenericCollectionEditorTarget;
        if (o != null)
        {
            return o.GetGenericCollectionTypes(Context.PropertyDescriptor.Name);
        }
        var ret = GetDerivedItemTypes(CollectionItemType);
        return ret;
    }

    protected Type[] GetDerivedItemTypes(Type type)
    {
        if (type == null) return Type.EmptyTypes;
        return (new[] { type })
            .Concat(type.Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(type)))
            .ToArray();
    }

    protected override object CreateInstance(Type itemType)
    {
        var instance = base.CreateInstance(itemType);
        var collection = editedObject as IGenericCollectionEditorTarget;
        if (instance != null && collection != null)
        {
            collection.OnCreatedNew(instance);
        }
        return instance;
    }


}