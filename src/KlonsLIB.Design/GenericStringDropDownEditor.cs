using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace KlonsLIB.Design
{
    public class GenericStringDropDownEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            var listprov = context.Instance as IGenericStringDropDownEditorTarget;
            if (listprov == null || context.PropertyDescriptor == null) return value;
            var list = listprov.GetValues(context.PropertyDescriptor.Name);
            if (list == null) return value;

            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;

            foreach (string s in list)
            {
                int index = lb.Items.Add(s);
                if (s.Equals(value))
                    lb.SelectedIndex = index;
            }

            int k = lb.Items.Count + 1;
            if (k > 15) k = 12;
            lb.Height = k * 30;
            lb.Width = 300;

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
            if (context != null)
                return UITypeEditorEditStyle.DropDown;
            else
                return base.GetEditStyle(context);
        }

    }


}
