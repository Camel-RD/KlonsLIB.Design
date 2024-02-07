using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DotNet.DesignTools.Client.Proxies;

namespace KlonsLIB.Design.Client
{
    internal class GenericCollectionEditor : Microsoft.DotNet.DesignTools.Client.Editors.CollectionEditor
    {
        public GenericCollectionEditor(Type type) : base(type) { }
        protected override string Name => nameof(GenericCollectionEditor);

        public override object? EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return base.EditValue(context, provider, value);
        }
    }
}

