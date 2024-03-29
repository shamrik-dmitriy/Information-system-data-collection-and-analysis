﻿namespace InfSysDCAA.Forms.Settings
{
    partial class SettingsDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDB));
            this.data_db_grpbx = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selected_db_combobox = new System.Windows.Forms.ComboBox();
            this.field_db_password = new System.Windows.Forms.TextBox();
            this.field_db_user = new System.Windows.Forms.TextBox();
            this.field_db_host = new System.Windows.Forms.TextBox();
            this.field_db_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_test_settings = new System.Windows.Forms.Button();
            this.button_save_settings = new System.Windows.Forms.Button();
            this.data_db_grpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_db_grpbx
            // 
            this.data_db_grpbx.Controls.Add(this.label5);
            this.data_db_grpbx.Controls.Add(this.selected_db_combobox);
            this.data_db_grpbx.Controls.Add(this.field_db_password);
            this.data_db_grpbx.Controls.Add(this.field_db_user);
            this.data_db_grpbx.Controls.Add(this.field_db_host);
            this.data_db_grpbx.Controls.Add(this.field_db_name);
            this.data_db_grpbx.Controls.Add(this.label4);
            this.data_db_grpbx.Controls.Add(this.label3);
            this.data_db_grpbx.Controls.Add(this.label2);
            this.data_db_grpbx.Controls.Add(this.label1);
            this.data_db_grpbx.Location = new System.Drawing.Point(12, 12);
            this.data_db_grpbx.Name = "data_db_grpbx";
            this.data_db_grpbx.Size = new System.Drawing.Size(310, 154);
            this.data_db_grpbx.TabIndex = 0;
            this.data_db_grpbx.TabStop = false;
            this.data_db_grpbx.Text = "Параметры соединения с базой данных";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пароль";
            // 
            // selected_db_combobox
            // 
            this.selected_db_combobox.FormattingEnabled = true;
            this.selected_db_combobox.Items.AddRange(new object[] {
            "MySQL",
            "PostgreSQL"});
            this.selected_db_combobox.Location = new System.Drawing.Point(122, 16);
            this.selected_db_combobox.Name = "selected_db_combobox";
            this.selected_db_combobox.Size = new System.Drawing.Size(182, 21);
            this.selected_db_combobox.TabIndex = 8;
            // 
            // field_db_password
            // 
            this.field_db_password.Location = new System.Drawing.Point(122, 124);
            this.field_db_password.Name = "field_db_password";
            this.field_db_password.Size = new System.Drawing.Size(182, 20);
            this.field_db_password.TabIndex = 7;
            // 
            // field_db_user
            // 
            this.field_db_user.Location = new System.Drawing.Point(122, 98);
            this.field_db_user.Name = "field_db_user";
            this.field_db_user.Size = new System.Drawing.Size(182, 20);
            this.field_db_user.TabIndex = 6;
            // 
            // field_db_host
            // 
            this.field_db_host.Location = new System.Drawing.Point(122, 72);
            this.field_db_host.Name = "field_db_host";
            this.field_db_host.Size = new System.Drawing.Size(182, 20);
            this.field_db_host.TabIndex = 5;
            // 
            // field_db_name
            // 
            this.field_db_name.Location = new System.Drawing.Point(122, 46);
            this.field_db_name.Name = "field_db_name";
            this.field_db_name.Size = new System.Drawing.Size(182, 20);
            this.field_db_name.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Хост подключения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя базы данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбор базы даных";
            // 
            // button_test_settings
            // 
            this.button_test_settings.Location = new System.Drawing.Point(12, 172);
            this.button_test_settings.Name = "button_test_settings";
            this.button_test_settings.Size = new System.Drawing.Size(150, 23);
            this.button_test_settings.TabIndex = 1;
            this.button_test_settings.Text = "Проверить соединение";
            this.button_test_settings.UseVisualStyleBackColor = true;
            this.button_test_settings.Click += new System.EventHandler(this.btn_test_connect_Click);
            // 
            // button_save_settings
            // 
            this.button_save_settings.Location = new System.Drawing.Point(174, 172);
            this.button_save_settings.Name = "button_save_settings";
            this.button_save_settings.Size = new System.Drawing.Size(148, 23);
            this.button_save_settings.TabIndex = 2;
            this.button_save_settings.Text = "Сохранить настройки";
            this.button_save_settings.UseVisualStyleBackColor = true;
            this.button_save_settings.Click += new System.EventHandler(this.btn_save_settings_connect_Click);
            // 
            // SetingsApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.button_save_settings);
            this.Controls.Add(this.button_test_settings);
            this.Controls.Add(this.data_db_grpbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetingsApps";
            this.Text = "SetingsDBApps";
            this.data_db_grpbx.ResumeLayout(false);
            this.data_db_grpbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox data_db_grpbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selected_db_combobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_test_settings;
        private System.Windows.Forms.Button button_save_settings;
        private System.Windows.Forms.TextBox field_db_password;
        private System.Windows.Forms.TextBox field_db_user;
        private System.Windows.Forms.TextBox field_db_host;
        private System.Windows.Forms.TextBox field_db_name;
    }
}