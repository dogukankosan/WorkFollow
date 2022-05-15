
namespace WorkFollow.Login
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Btn_Admin = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_Username = new DevExpress.XtraEditors.TextEdit();
            this.Txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_EyeVisible = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_UnVisible = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Admin
            // 
            this.Btn_Admin.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.Btn_Admin.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_Admin.Appearance.Options.UseBackColor = true;
            this.Btn_Admin.Appearance.Options.UseFont = true;
            this.Btn_Admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Admin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Admin.ImageOptions.SvgImage")));
            this.Btn_Admin.Location = new System.Drawing.Point(12, 284);
            this.Btn_Admin.Name = "Btn_Admin";
            this.Btn_Admin.Size = new System.Drawing.Size(275, 62);
            this.Btn_Admin.TabIndex = 0;
            this.Btn_Admin.Text = "GİRİŞ YAP";
            this.Btn_Admin.Click += new System.EventHandler(this.Btn_Admin_Click);
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(5, 99);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.Txt_Username.Properties.Appearance.Options.UseFont = true;
            this.Txt_Username.Properties.MaxLength = 70;
            this.Txt_Username.Size = new System.Drawing.Size(285, 36);
            this.Txt_Username.TabIndex = 2;
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(5, 204);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.Txt_Password.Properties.Appearance.Options.UseFont = true;
            this.Txt_Password.Properties.MaxLength = 50;
            this.Txt_Password.Properties.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(285, 36);
            this.Txt_Password.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(25, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(237, 40);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "      KULLANICI ADI";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl2.ImageOptions.SvgImage")));
            this.labelControl2.Location = new System.Drawing.Point(78, 157);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(118, 40);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "      ŞİFRE";
            // 
            // Btn_EyeVisible
            // 
            this.Btn_EyeVisible.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_EyeVisible.Appearance.Options.UseBackColor = true;
            this.Btn_EyeVisible.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_EyeVisible.ImageOptions.Image")));
            this.Btn_EyeVisible.Location = new System.Drawing.Point(203, 162);
            this.Btn_EyeVisible.Name = "Btn_EyeVisible";
            this.Btn_EyeVisible.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_EyeVisible.Size = new System.Drawing.Size(39, 30);
            this.Btn_EyeVisible.TabIndex = 33;
            this.Btn_EyeVisible.Click += new System.EventHandler(this.Btn_EyeVisible_Click);
            // 
            // Btn_UnVisible
            // 
            this.Btn_UnVisible.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_UnVisible.Appearance.Options.UseBackColor = true;
            this.Btn_UnVisible.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_UnVisible.ImageOptions.Image")));
            this.Btn_UnVisible.Location = new System.Drawing.Point(203, 162);
            this.Btn_UnVisible.Name = "Btn_UnVisible";
            this.Btn_UnVisible.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_UnVisible.Size = new System.Drawing.Size(39, 30);
            this.Btn_UnVisible.TabIndex = 34;
            this.Btn_UnVisible.Click += new System.EventHandler(this.Btn_UnVisible_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(301, 359);
            this.Controls.Add(this.Btn_UnVisible);
            this.Controls.Add(this.Btn_EyeVisible);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.Btn_Admin);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Login.IconOptions.SvgImage")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Btn_Admin;
        private DevExpress.XtraEditors.TextEdit Txt_Username;
        private DevExpress.XtraEditors.TextEdit Txt_Password;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_EyeVisible;
        private DevExpress.XtraEditors.SimpleButton Btn_UnVisible;
    }
}