using System;
using Microsoft.DotNet.DesignTools.Editors;

namespace KlonsLIB.Design.Server;

internal partial class GenericCollectionEditor
{
    [ExportCollectionEditorFactory(nameof(GenericCollectionEditor))]
    private class Factory : CollectionEditorFactory<GenericCollectionEditor>
    {
        protected override GenericCollectionEditor CreateCollectionEditor(IServiceProvider serviceProvider, Type collectionType)
        {
            return new(serviceProvider, collectionType);
        }
    }
}
