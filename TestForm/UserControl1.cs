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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            label1.Text = "Environment.Version: " + Environment.Version;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        [Category("_MyData")]
#if NETFRAMEWORK
        [Editor("KlonsLIB.Design.GenericCollectionEditor, KlonsLIB.Design", typeof(UITypeEditor))]
#else
        [Editor("GenericCollectionEditor", (typeof(UITypeEditor)))]
#endif
        public MyDataItemList Data { get; } = new MyDataItemList();


        [Category("_MyData")]
#if NETFRAMEWORK
        [Editor("KlonsLIB.Design.GenericCollectionEditor, KlonsLIB.Design", typeof(UITypeEditor))]
#else
        [Editor("GenericCollectionEditor", (typeof(UITypeEditor)))]
#endif
        public MyDataItemList2 Data2 { get; } = new MyDataItemList2();
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
