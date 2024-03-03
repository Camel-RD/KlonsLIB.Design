using KlonsLIB.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class UserControl1 : UserControl, IGenericStringDropDownEditorTarget
    {
        public UserControl1()
        {
            InitializeComponent();
            label1.Text = "Environment.Version: " + Environment.Version;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        string[] IGenericStringDropDownEditorTarget.GetValues(string propertyname)
        {
            if(propertyname == "MyStringProp")
            {
                return new[] { "P1-1", "P1-2" };
            }
            if (propertyname == "MyStringProp2")
            {
                return new[] { "P2-1", "P2-2" };
            }
            return new string[0] ;
        }

        [Category("_MyData")]
        [Editor("KlonsLIB.Design.GenericCollectionEditor, KlonsLIB.Design", "System.Drawing.Design.UITypeEditor, System.Windows.Forms")]
        public MyDataItemList Data { get; } = new MyDataItemList();


        [Category("_MyData")]
        [Editor("KlonsLIB.Design.GenericCollectionEditor, KlonsLIB.Design", "System.Drawing.Design.UITypeEditor, System.Windows.Forms")]
        public MyDataItemList2 Data2 { get; } = new MyDataItemList2();

        [Category("_MyData")]
        [Editor("KlonsLIB.Design.GenericStringDropDownEditor, KlonsLIB.Design", "System.Drawing.Design.UITypeEditor, System.Windows.Forms")]
        public string MyStringProp { get; set; }

        [Category("_MyData")]
        [Editor("KlonsLIB.Design.GenericStringDropDownEditor, KlonsLIB.Design", "System.Drawing.Design.UITypeEditor, System.Windows.Forms")]
        public string MyStringProp2 { get; set; }
    }

    public class MyDataItemList : List<MyDataItem>, IGenericCollectionEditorTarget
    {
        void IGenericCollectionEditorTarget.OnCreatedNew(object item)
        {
            var di = item as MyDataItem;
            if (di == null) return;
            di.Text = "added";
        }

        Type[] IGenericCollectionEditorTarget.GetGenericCollectionTypes(string propname)
        {
            return new[] { typeof(MyDataItem), typeof(MyDataItem2) };
        }

    }

    public class MyDataItemList2 : ArrayList, IGenericCollectionEditorTarget
    {
        void IGenericCollectionEditorTarget.OnCreatedNew(object item)
        {
            var di = item as MyDataItem;
            if (di == null) return;
            di.Text = "added";
        }

        Type[] IGenericCollectionEditorTarget.GetGenericCollectionTypes(string propname)
        {
            return new[] { typeof(MyDataItem), typeof(MyDataItem2) };
        }

    }

    public class MyDataItem
    {
        public MyDataItem() { }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class MyDataItem2 : MyDataItem
    {
        public MyDataItem2() { }
        public int Count { get; set; }
    }

}
