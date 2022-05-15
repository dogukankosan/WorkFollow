
namespace WorkFollow.Forms
{
    partial class AddMessage
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
            BaiqiSoft.HtmlEditorControl.FormatHtmlOptions formatHtmlOptions1 = new BaiqiSoft.HtmlEditorControl.FormatHtmlOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMessage));
            this.mstHtmlEditor1 = new BaiqiSoft.HtmlEditorControl.MstHtmlEditor();
            this.Btn_MessageAdd = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // mstHtmlEditor1
            // 
            this.mstHtmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            formatHtmlOptions1.BreakBeforeBR = true;
            formatHtmlOptions1.ClosingSingleTags = true;
            formatHtmlOptions1.IndentHtmlTags = true;
            formatHtmlOptions1.IndentScript = true;
            formatHtmlOptions1.IndentSpaces = 4;
            formatHtmlOptions1.IndentWithTabs = false;
            formatHtmlOptions1.LowercaseTags = true;
            formatHtmlOptions1.QuoteAttributeValues = true;
            this.mstHtmlEditor1.FormatHtmlOptions = formatHtmlOptions1;
            this.mstHtmlEditor1.LanguageConfig = null;
            this.mstHtmlEditor1.Location = new System.Drawing.Point(0, 0);
            this.mstHtmlEditor1.Name = "mstHtmlEditor1";
            this.mstHtmlEditor1.SelectionLength = 0;
            this.mstHtmlEditor1.SelectionStart = 0;
            this.mstHtmlEditor1.Size = new System.Drawing.Size(1143, 557);
            this.mstHtmlEditor1.TabIndex = 0;
            // 
            // Btn_MessageAdd
            // 
            this.Btn_MessageAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.Btn_MessageAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_MessageAdd.Appearance.Options.UseBackColor = true;
            this.Btn_MessageAdd.Appearance.Options.UseFont = true;
            this.Btn_MessageAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_MessageAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_MessageAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_CompanyAdd.ImageOptions.SvgImage")));
            this.Btn_MessageAdd.Location = new System.Drawing.Point(1070, 0);
            this.Btn_MessageAdd.Name = "Btn_MessageAdd";
            this.Btn_MessageAdd.Size = new System.Drawing.Size(73, 557);
            this.Btn_MessageAdd.TabIndex = 2;
            this.Btn_MessageAdd.Text = "E\r\nK\r\nL\r\nE\r\n";
            this.Btn_MessageAdd.Click += new System.EventHandler(this.Btn_MessageAdd_Click);
            // 
            // AddMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1143, 557);
            this.Controls.Add(this.Btn_MessageAdd);
            this.Controls.Add(this.mstHtmlEditor1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddMessage.IconOptions.Image")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesaj Gönder";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddMessage_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private BaiqiSoft.HtmlEditorControl.MstHtmlEditor mstHtmlEditor1;
        private DevExpress.XtraEditors.SimpleButton Btn_MessageAdd;
    }
}