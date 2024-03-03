using System.Drawing;
using System.Windows.Forms;

namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userControl11 = new UserControl1();
            propertyGrid1 = new PropertyGrid();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.BackColor = Color.Tan;
            userControl11.Location = new Point(12, 0);
            userControl11.Margin = new Padding(3, 4, 3, 4);
            userControl11.MyStringProp = "1111";
            userControl11.MyStringProp2 = "zz";
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(365, 139);
            userControl11.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            propertyGrid1.CanShowVisualStyleGlyphs = false;
            propertyGrid1.CommandsVisibleIfAvailable = false;
            propertyGrid1.Dock = DockStyle.Right;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.Location = new Point(405, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(320, 251);
            propertyGrid1.TabIndex = 2;
            propertyGrid1.ToolbarVisible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 251);
            Controls.Add(propertyGrid1);
            Controls.Add(userControl11);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private UserControl1 userControl11;
        private PropertyGrid propertyGrid1;
    }
}
