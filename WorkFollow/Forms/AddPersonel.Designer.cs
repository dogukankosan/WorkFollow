﻿
namespace WorkFollow.Forms
{
    partial class AddPersonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPersonel));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_PersonTel = new System.Windows.Forms.MaskedTextBox();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Txt_PersonelMail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Txt_PersonelSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_PersonelAdd = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_PersonelName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.Txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.Btn_EyeVisible = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_UnVisible = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.Btn_EyeVisible);
            this.groupControl1.Controls.Add(this.Btn_UnVisible);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.Txt_Password);
            this.groupControl1.Controls.Add(this.Btn_Clear);
            this.groupControl1.Controls.Add(this.Txt_PersonTel);
            this.groupControl1.Controls.Add(this.lookUpEdit1);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.Txt_PersonelMail);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.Txt_PersonelSurname);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.Btn_PersonelAdd);
            this.groupControl1.Controls.Add(this.Txt_PersonelName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(582, 516);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Personeller";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.Btn_Clear.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_Clear.Appearance.Options.UseBackColor = true;
            this.Btn_Clear.Appearance.Options.UseFont = true;
            this.Btn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Clear.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_Clear.ImageOptions.SvgImage")));
            this.Btn_Clear.Location = new System.Drawing.Point(18, 454);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(244, 49);
            this.Btn_Clear.TabIndex = 18;
            this.Btn_Clear.Text = "TEMİZLE (F1)";
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Txt_PersonTel
            // 
            this.Txt_PersonTel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_PersonTel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Txt_PersonTel.Location = new System.Drawing.Point(307, 91);
            this.Txt_PersonTel.Mask = "000-0000000";
            this.Txt_PersonTel.Name = "Txt_PersonTel";
            this.Txt_PersonTel.Size = new System.Drawing.Size(267, 38);
            this.Txt_PersonTel.TabIndex = 17;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(307, 335);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "Departman Seçiniz";
            this.lookUpEdit1.Size = new System.Drawing.Size(267, 22);
            this.lookUpEdit1.TabIndex = 16;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(307, 183);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(267, 96);
            this.pictureEdit1.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(307, 295);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(137, 30);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Departmanı:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(307, 147);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(178, 30);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Personel Resim:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(307, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(145, 30);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Personel Tel:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(16, 211);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(155, 30);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Personel Mail:";
            // 
            // Txt_PersonelMail
            // 
            this.Txt_PersonelMail.Location = new System.Drawing.Point(16, 247);
            this.Txt_PersonelMail.Name = "Txt_PersonelMail";
            this.Txt_PersonelMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_PersonelMail.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Txt_PersonelMail.Properties.Appearance.Options.UseFont = true;
            this.Txt_PersonelMail.Properties.Appearance.Options.UseForeColor = true;
            this.Txt_PersonelMail.Properties.MaxLength = 50;
            this.Txt_PersonelMail.Size = new System.Drawing.Size(267, 36);
            this.Txt_PersonelMail.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(16, 133);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(178, 30);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Personel Soyad:";
            // 
            // Txt_PersonelSurname
            // 
            this.Txt_PersonelSurname.Location = new System.Drawing.Point(16, 169);
            this.Txt_PersonelSurname.Name = "Txt_PersonelSurname";
            this.Txt_PersonelSurname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_PersonelSurname.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Txt_PersonelSurname.Properties.Appearance.Options.UseFont = true;
            this.Txt_PersonelSurname.Properties.Appearance.Options.UseForeColor = true;
            this.Txt_PersonelSurname.Properties.MaxLength = 50;
            this.Txt_PersonelSurname.Size = new System.Drawing.Size(267, 36);
            this.Txt_PersonelSurname.TabIndex = 5;
            this.Txt_PersonelSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_PersonelSurname_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(140, 30);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Personel Ad:";
            // 
            // Btn_PersonelAdd
            // 
            this.Btn_PersonelAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.Btn_PersonelAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Btn_PersonelAdd.Appearance.Options.UseBackColor = true;
            this.Btn_PersonelAdd.Appearance.Options.UseFont = true;
            this.Btn_PersonelAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_PersonelAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Btn_PersonelAdd.ImageOptions.SvgImage")));
            this.Btn_PersonelAdd.Location = new System.Drawing.Point(16, 392);
            this.Btn_PersonelAdd.Name = "Btn_PersonelAdd";
            this.Btn_PersonelAdd.Size = new System.Drawing.Size(246, 49);
            this.Btn_PersonelAdd.TabIndex = 1;
            this.Btn_PersonelAdd.Text = "EKLE (F2)";
            this.Btn_PersonelAdd.Click += new System.EventHandler(this.Btn_PersonelAdd_Click);
            // 
            // Txt_PersonelName
            // 
            this.Txt_PersonelName.Location = new System.Drawing.Point(16, 91);
            this.Txt_PersonelName.Name = "Txt_PersonelName";
            this.Txt_PersonelName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_PersonelName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Txt_PersonelName.Properties.Appearance.Options.UseFont = true;
            this.Txt_PersonelName.Properties.Appearance.Options.UseForeColor = true;
            this.Txt_PersonelName.Properties.MaxLength = 50;
            this.Txt_PersonelName.Size = new System.Drawing.Size(267, 36);
            this.Txt_PersonelName.TabIndex = 0;
            this.Txt_PersonelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_PersonelName_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(18, 297);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(161, 30);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "Personel Şifre:";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(18, 333);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.Txt_Password.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Txt_Password.Properties.Appearance.Options.UseFont = true;
            this.Txt_Password.Properties.Appearance.Options.UseForeColor = true;
            this.Txt_Password.Properties.MaxLength = 50;
            this.Txt_Password.Properties.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(267, 36);
            this.Txt_Password.TabIndex = 19;
            // 
            // Btn_EyeVisible
            // 
            this.Btn_EyeVisible.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_EyeVisible.Appearance.Options.UseBackColor = true;
            this.Btn_EyeVisible.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_EyeVisible.ImageOptions.Image")));
            this.Btn_EyeVisible.Location = new System.Drawing.Point(244, 295);
            this.Btn_EyeVisible.Name = "Btn_EyeVisible";
            this.Btn_EyeVisible.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_EyeVisible.Size = new System.Drawing.Size(39, 30);
            this.Btn_EyeVisible.TabIndex = 34;
            this.Btn_EyeVisible.Click += new System.EventHandler(this.Btn_EyeVisible_Click);
            // 
            // Btn_UnVisible
            // 
            this.Btn_UnVisible.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Btn_UnVisible.Appearance.Options.UseBackColor = true;
            this.Btn_UnVisible.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_UnVisible.ImageOptions.Image")));
            this.Btn_UnVisible.Location = new System.Drawing.Point(244, 295);
            this.Btn_UnVisible.Name = "Btn_UnVisible";
            this.Btn_UnVisible.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_UnVisible.Size = new System.Drawing.Size(39, 30);
            this.Btn_UnVisible.TabIndex = 33;
            this.Btn_UnVisible.Click += new System.EventHandler(this.Btn_UnVisible_Click);
            // 
            // AddPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(582, 516);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("AddPersonel.IconOptions.LargeImage")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPersonel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Ekle";
            this.Load += new System.EventHandler(this.AddPersonel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPersonel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PersonelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Password.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Clear;
        private System.Windows.Forms.MaskedTextBox Txt_PersonTel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit Txt_PersonelMail;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Txt_PersonelSurname;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_PersonelAdd;
        private DevExpress.XtraEditors.TextEdit Txt_PersonelName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit Txt_Password;
        private DevExpress.XtraEditors.SimpleButton Btn_EyeVisible;
        private DevExpress.XtraEditors.SimpleButton Btn_UnVisible;
    }
}