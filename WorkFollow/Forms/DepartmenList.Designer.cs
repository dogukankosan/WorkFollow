
namespace WorkFollow.Forms
{
    partial class DepartmenList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmenList));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excelAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_DepaDelete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_DepaUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_DepaAdd = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_Departmen = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Departmen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(874, 593);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelAlToolStripMenuItem,
            this.pDFAlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 56);
            // 
            // excelAlToolStripMenuItem
            // 
            this.excelAlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excelAlToolStripMenuItem.Image")));
            this.excelAlToolStripMenuItem.Name = "excelAlToolStripMenuItem";
            this.excelAlToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.excelAlToolStripMenuItem.Text = "Excel Al";
            this.excelAlToolStripMenuItem.Click += new System.EventHandler(this.excelAlToolStripMenuItem_Click);
            // 
            // pDFAlToolStripMenuItem
            // 
            this.pDFAlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pDFAlToolStripMenuItem.Image")));
            this.pDFAlToolStripMenuItem.Name = "pDFAlToolStripMenuItem";
            this.pDFAlToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.pDFAlToolStripMenuItem.Text = "PDF Al";
            this.pDFAlToolStripMenuItem.Click += new System.EventHandler(this.pDFAlToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.Btn_DepaDelete);
            this.groupControl1.Controls.Add(this.Btn_DepaUpdate);
            this.groupControl1.Controls.Add(this.Btn_DepaAdd);
            this.groupControl1.Controls.Add(this.Txt_Departmen);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(874, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(306, 593);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Departmanlar";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(27, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 30);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Departman Ad:";
            // 
            // Btn_DepaDelete
            // 
            this.Btn_DepaDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Btn_DepaDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_DepaDelete.Appearance.Options.UseBackColor = true;
            this.Btn_DepaDelete.Appearance.Options.UseFont = true;
            this.Btn_DepaDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DepaDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_DepaDelete.ImageOptions.SvgImage")));
            this.Btn_DepaDelete.Location = new System.Drawing.Point(25, 216);
            this.Btn_DepaDelete.Name = "Btn_DepaDelete";
            this.Btn_DepaDelete.Size = new System.Drawing.Size(244, 49);
            this.Btn_DepaDelete.TabIndex = 3;
            this.Btn_DepaDelete.Text = "SİL (F3)";
            this.Btn_DepaDelete.Click += new System.EventHandler(this.Btn_DepaDelete_Click);
            // 
            // Btn_DepaUpdate
            // 
            this.Btn_DepaUpdate.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Btn_DepaUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_DepaUpdate.Appearance.Options.UseBackColor = true;
            this.Btn_DepaUpdate.Appearance.Options.UseFont = true;
            this.Btn_DepaUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DepaUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_DepaUpdate.ImageOptions.SvgImage")));
            this.Btn_DepaUpdate.Location = new System.Drawing.Point(25, 277);
            this.Btn_DepaUpdate.Name = "Btn_DepaUpdate";
            this.Btn_DepaUpdate.Size = new System.Drawing.Size(244, 49);
            this.Btn_DepaUpdate.TabIndex = 2;
            this.Btn_DepaUpdate.Text = "GÜNCELLE (F5)";
            this.Btn_DepaUpdate.Click += new System.EventHandler(this.Btn_DepaUpdate_Click);
            // 
            // Btn_DepaAdd
            // 
            this.Btn_DepaAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.Btn_DepaAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_DepaAdd.Appearance.Options.UseBackColor = true;
            this.Btn_DepaAdd.Appearance.Options.UseFont = true;
            this.Btn_DepaAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DepaAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_DepaAdd.ImageOptions.SvgImage")));
            this.Btn_DepaAdd.Location = new System.Drawing.Point(25, 151);
            this.Btn_DepaAdd.Name = "Btn_DepaAdd";
            this.Btn_DepaAdd.Size = new System.Drawing.Size(246, 49);
            this.Btn_DepaAdd.TabIndex = 1;
            this.Btn_DepaAdd.Text = "EKLE (F2)";
            this.Btn_DepaAdd.Click += new System.EventHandler(this.Btn_DepaAdd_Click);
            // 
            // Txt_Departmen
            // 
            this.Txt_Departmen.Location = new System.Drawing.Point(27, 95);
            this.Txt_Departmen.Name = "Txt_Departmen";
            this.Txt_Departmen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_Departmen.Properties.Appearance.Options.UseFont = true;
            this.Txt_Departmen.Properties.MaxLength = 50;
            this.Txt_Departmen.Size = new System.Drawing.Size(267, 36);
            this.Txt_Departmen.TabIndex = 0;
            this.Txt_Departmen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Departmen_KeyPress);
            // 
            // DepartmenList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1180, 593);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.Name = "DepartmenList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departmanlar";
            this.Load += new System.EventHandler(this.DepartmenList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmenList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Departmen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_DepaDelete;
        private DevExpress.XtraEditors.SimpleButton Btn_DepaUpdate;
        private DevExpress.XtraEditors.SimpleButton Btn_DepaAdd;
        private DevExpress.XtraEditors.TextEdit Txt_Departmen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excelAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFAlToolStripMenuItem;
    }
}