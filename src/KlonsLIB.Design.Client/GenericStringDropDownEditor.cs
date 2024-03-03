using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client;

using KlonsLIB.Design.Protocol.Endpoints;

namespace KlonsLIB.Design.Client
{
    public class GenericStringDropDownEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        public override object? EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context?.Instance is null)
                return value;

            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (_editorService is null)
                return value;

            var client = provider.GetRequiredService<IDesignToolsClient>();
            var sender = client.Protocol.GetEndpoint<GenericStringDropDownEditorEditValueEndpoint>().GetSender(client);
            var response = sender.SendRequest(new GenericStringDropDownEditorEditValueRequest(context.Instance, context.PropertyDescriptor.Name));
            if (response?.DropDownStrings is null)
                return value;

            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            foreach (string s in response.DropDownStrings)
            {
                int index = lb.Items.Add(s);
                if (s.Equals(value))
                    lb.SelectedIndex = index;
            }
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) return value;
            return lb.SelectedItem;
        }
        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return context?.Instance is not null ? UITypeEditorEditStyle.DropDown : base.GetEditStyle(context);
        }
    }


}
