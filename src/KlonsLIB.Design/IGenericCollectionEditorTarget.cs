using System;

namespace KlonsLIB.Design
{
    public interface IGenericCollectionEditorTarget
    {
        void OnCreatedNew(object item);
        Type[] GetGenericCollectionTypes(string propname);
    }
}
