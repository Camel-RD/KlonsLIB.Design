using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace TestForm
{
    public class DropStringEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;
        public override object? EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            ListBox lb = new ListBox();
            //var tid = context.Instance.GetTypeIdentity();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;
            lb.Items.Add("sss");
            lb.Items.Add("dddd");
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