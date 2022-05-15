
namespace WorkFollow.Forms
{
    partial class AddDepartman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDepartman));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_DepaAdd = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_Departmen = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Departmen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.Btn_DepaAdd);
            this.groupControl1.Controls.Add(this.Txt_Departmen);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(301, 233);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Departmanlar";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 30);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Departman Ad:";
            // 
            // Btn_DepaAdd
            // 
            this.Btn_DepaAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.Btn_DepaAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_DepaAdd.Appearance.Options.UseBackColor = true;
            this.Btn_DepaAdd.Appearance.Options.UseFont = true;
            this.Btn_DepaAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DepaAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_DepaAdd.ImageOptions.SvgImage")));
            this.Btn_DepaAdd.Location = new System.Drawing.Point(20, 152);
            this.Btn_DepaAdd.Name = "Btn_DepaAdd";
            this.Btn_DepaAdd.Size = new System.Drawing.Size(246, 49);
            this.Btn_DepaAdd.TabIndex = 1;
            this.Btn_DepaAdd.Text = "EKLE (F2)";
            this.Btn_DepaAdd.Click += new System.EventHandler(this.Btn_DepaAdd_Click);
            // 
            // Txt_Departmen
            // 
            this.Txt_Departmen.Location = new System.Drawing.Point(22, 96);
            this.Txt_Departmen.Name = "Txt_Departmen";
            this.Txt_Departmen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_Departmen.Properties.Appearance.Options.UseFont = true;
            this.Txt_Departmen.Properties.MaxLength = 50;
            this.Txt_Departmen.Size = new System.Drawing.Size(267, 36);
            this.Txt_Departmen.TabIndex = 0;
            this.Txt_Departmen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Departmen_KeyPress);
            // 
            // AddDepartman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(301, 233);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AddDepartman.IconOptions.SvgImage")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDepartman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departman Ekle";
            this.Load += new System.EventHandler(this.AddDepartman_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddDepartman_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Departmen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_DepaAdd;
        private DevExpress.XtraEditors.TextEdit Txt_Departmen;
    }
}