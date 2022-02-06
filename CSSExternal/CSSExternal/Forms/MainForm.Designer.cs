namespace CSSExternal.Forms
{
    partial class MainForm
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
            this.cbESP = new MetroFramework.Controls.MetroCheckBox();
            this.cbSnaplines = new MetroFramework.Controls.MetroCheckBox();
            this.cbHealthBar = new MetroFramework.Controls.MetroCheckBox();
            this.lblHeaderAimbot = new MetroFramework.Controls.MetroLabel();
            this.lblHeaderVisuals = new MetroFramework.Controls.MetroLabel();
            this.cbAimbot = new MetroFramework.Controls.MetroCheckBox();
            this.cbAimbotDrawFOV = new MetroFramework.Controls.MetroCheckBox();
            this.tbAimbotFOV = new MetroFramework.Controls.MetroTrackBar();
            this.cbESPType = new MetroFramework.Controls.MetroComboBox();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.lblHeaderMiscs = new MetroFramework.Controls.MetroLabel();
            this.cbBunnyHop = new MetroFramework.Controls.MetroCheckBox();
            this.cbAimbotRecoilHelper = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // cbESP
            // 
            this.cbESP.AutoSize = true;
            this.cbESP.Location = new System.Drawing.Point(23, 78);
            this.cbESP.Name = "cbESP";
            this.cbESP.Size = new System.Drawing.Size(42, 15);
            this.cbESP.Style = MetroFramework.MetroColorStyle.Red;
            this.cbESP.TabIndex = 0;
            this.cbESP.Text = "ESP";
            this.cbESP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbESP.UseVisualStyleBackColor = true;
            this.cbESP.CheckedChanged += new System.EventHandler(this.cbESP_CheckedChanged);
            // 
            // cbSnaplines
            // 
            this.cbSnaplines.AutoSize = true;
            this.cbSnaplines.Location = new System.Drawing.Point(23, 99);
            this.cbSnaplines.Name = "cbSnaplines";
            this.cbSnaplines.Size = new System.Drawing.Size(73, 15);
            this.cbSnaplines.Style = MetroFramework.MetroColorStyle.Red;
            this.cbSnaplines.TabIndex = 1;
            this.cbSnaplines.Text = "Snaplines";
            this.cbSnaplines.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbSnaplines.UseVisualStyleBackColor = true;
            this.cbSnaplines.CheckedChanged += new System.EventHandler(this.cbSnaplines_CheckedChanged);
            // 
            // cbHealthBar
            // 
            this.cbHealthBar.AutoSize = true;
            this.cbHealthBar.Location = new System.Drawing.Point(23, 120);
            this.cbHealthBar.Name = "cbHealthBar";
            this.cbHealthBar.Size = new System.Drawing.Size(78, 15);
            this.cbHealthBar.Style = MetroFramework.MetroColorStyle.Red;
            this.cbHealthBar.TabIndex = 2;
            this.cbHealthBar.Text = "Health Bar";
            this.cbHealthBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbHealthBar.UseVisualStyleBackColor = true;
            this.cbHealthBar.CheckedChanged += new System.EventHandler(this.cbHealthBar_CheckedChanged);
            // 
            // lblHeaderAimbot
            // 
            this.lblHeaderAimbot.AutoSize = true;
            this.lblHeaderAimbot.Location = new System.Drawing.Point(19, 141);
            this.lblHeaderAimbot.Name = "lblHeaderAimbot";
            this.lblHeaderAimbot.Size = new System.Drawing.Size(235, 19);
            this.lblHeaderAimbot.Style = MetroFramework.MetroColorStyle.Red;
            this.lblHeaderAimbot.TabIndex = 4;
            this.lblHeaderAimbot.Text = "-- Aimbot ---------------------------";
            this.lblHeaderAimbot.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblHeaderVisuals
            // 
            this.lblHeaderVisuals.AutoSize = true;
            this.lblHeaderVisuals.Location = new System.Drawing.Point(19, 56);
            this.lblHeaderVisuals.Name = "lblHeaderVisuals";
            this.lblHeaderVisuals.Size = new System.Drawing.Size(235, 19);
            this.lblHeaderVisuals.Style = MetroFramework.MetroColorStyle.Red;
            this.lblHeaderVisuals.TabIndex = 5;
            this.lblHeaderVisuals.Text = "-- Visuals ----------------------------";
            this.lblHeaderVisuals.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cbAimbot
            // 
            this.cbAimbot.AutoSize = true;
            this.cbAimbot.Location = new System.Drawing.Point(23, 163);
            this.cbAimbot.Name = "cbAimbot";
            this.cbAimbot.Size = new System.Drawing.Size(63, 15);
            this.cbAimbot.Style = MetroFramework.MetroColorStyle.Red;
            this.cbAimbot.TabIndex = 6;
            this.cbAimbot.Text = "Aimbot";
            this.cbAimbot.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbAimbot.UseVisualStyleBackColor = true;
            this.cbAimbot.CheckedChanged += new System.EventHandler(this.cbAimbot_CheckedChanged);
            // 
            // cbAimbotDrawFOV
            // 
            this.cbAimbotDrawFOV.AutoSize = true;
            this.cbAimbotDrawFOV.Location = new System.Drawing.Point(23, 184);
            this.cbAimbotDrawFOV.Name = "cbAimbotDrawFOV";
            this.cbAimbotDrawFOV.Size = new System.Drawing.Size(98, 15);
            this.cbAimbotDrawFOV.Style = MetroFramework.MetroColorStyle.Red;
            this.cbAimbotDrawFOV.TabIndex = 7;
            this.cbAimbotDrawFOV.Text = "Draw FOV [90]";
            this.cbAimbotDrawFOV.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbAimbotDrawFOV.UseVisualStyleBackColor = true;
            this.cbAimbotDrawFOV.CheckedChanged += new System.EventHandler(this.cbAimbotDrawFOV_CheckedChanged);
            // 
            // tbAimbotFOV
            // 
            this.tbAimbotFOV.BackColor = System.Drawing.Color.Transparent;
            this.tbAimbotFOV.Location = new System.Drawing.Point(23, 205);
            this.tbAimbotFOV.Maximum = 900;
            this.tbAimbotFOV.Minimum = 1;
            this.tbAimbotFOV.Name = "tbAimbotFOV";
            this.tbAimbotFOV.Size = new System.Drawing.Size(231, 23);
            this.tbAimbotFOV.Style = MetroFramework.MetroColorStyle.Red;
            this.tbAimbotFOV.TabIndex = 8;
            this.tbAimbotFOV.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbAimbotFOV.Value = 90;
            this.tbAimbotFOV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tbAimbotFOV_Scroll);
            // 
            // cbESPType
            // 
            this.cbESPType.FormattingEnabled = true;
            this.cbESPType.ItemHeight = 23;
            this.cbESPType.Items.AddRange(new object[] {
            "Rectangle Box",
            "Corner Box"});
            this.cbESPType.Location = new System.Drawing.Point(127, 78);
            this.cbESPType.Name = "cbESPType";
            this.cbESPType.Size = new System.Drawing.Size(121, 29);
            this.cbESPType.Style = MetroFramework.MetroColorStyle.Red;
            this.cbESPType.TabIndex = 9;
            this.cbESPType.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbESPType.SelectedIndexChanged += new System.EventHandler(this.cbESPType_SelectedIndexChanged);
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Red;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblHeaderMiscs
            // 
            this.lblHeaderMiscs.AutoSize = true;
            this.lblHeaderMiscs.Location = new System.Drawing.Point(19, 231);
            this.lblHeaderMiscs.Name = "lblHeaderMiscs";
            this.lblHeaderMiscs.Size = new System.Drawing.Size(234, 19);
            this.lblHeaderMiscs.Style = MetroFramework.MetroColorStyle.Red;
            this.lblHeaderMiscs.TabIndex = 10;
            this.lblHeaderMiscs.Text = "-- Miscs -----------------------------";
            this.lblHeaderMiscs.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cbBunnyHop
            // 
            this.cbBunnyHop.AutoSize = true;
            this.cbBunnyHop.Location = new System.Drawing.Point(23, 253);
            this.cbBunnyHop.Name = "cbBunnyHop";
            this.cbBunnyHop.Size = new System.Drawing.Size(83, 15);
            this.cbBunnyHop.Style = MetroFramework.MetroColorStyle.Red;
            this.cbBunnyHop.TabIndex = 11;
            this.cbBunnyHop.Text = "Bunny Hop";
            this.cbBunnyHop.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbBunnyHop.UseVisualStyleBackColor = true;
            this.cbBunnyHop.CheckedChanged += new System.EventHandler(this.cbBunnyHop_CheckedChanged);
            // 
            // cbAimbotRecoilHelper
            // 
            this.cbAimbotRecoilHelper.AutoSize = true;
            this.cbAimbotRecoilHelper.Location = new System.Drawing.Point(155, 163);
            this.cbAimbotRecoilHelper.Name = "cbAimbotRecoilHelper";
            this.cbAimbotRecoilHelper.Size = new System.Drawing.Size(93, 15);
            this.cbAimbotRecoilHelper.Style = MetroFramework.MetroColorStyle.Red;
            this.cbAimbotRecoilHelper.TabIndex = 12;
            this.cbAimbotRecoilHelper.Text = "Recoil Helper";
            this.cbAimbotRecoilHelper.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cbAimbotRecoilHelper.UseVisualStyleBackColor = true;
            this.cbAimbotRecoilHelper.CheckedChanged += new System.EventHandler(this.cbAimbotRecoilHelper_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 291);
            this.Controls.Add(this.cbAimbotRecoilHelper);
            this.Controls.Add(this.cbBunnyHop);
            this.Controls.Add(this.lblHeaderMiscs);
            this.Controls.Add(this.cbESPType);
            this.Controls.Add(this.tbAimbotFOV);
            this.Controls.Add(this.cbAimbotDrawFOV);
            this.Controls.Add(this.cbAimbot);
            this.Controls.Add(this.lblHeaderVisuals);
            this.Controls.Add(this.lblHeaderAimbot);
            this.Controls.Add(this.cbHealthBar);
            this.Controls.Add(this.cbSnaplines);
            this.Controls.Add(this.cbESP);
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "CS:S External";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox cbESP;
        private MetroFramework.Controls.MetroCheckBox cbSnaplines;
        private MetroFramework.Controls.MetroCheckBox cbHealthBar;
        private MetroFramework.Controls.MetroLabel lblHeaderAimbot;
        private MetroFramework.Controls.MetroLabel lblHeaderVisuals;
        private MetroFramework.Controls.MetroCheckBox cbAimbot;
        private MetroFramework.Controls.MetroCheckBox cbAimbotDrawFOV;
        private MetroFramework.Controls.MetroTrackBar tbAimbotFOV;
        private MetroFramework.Controls.MetroComboBox cbESPType;
        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroCheckBox cbBunnyHop;
        private MetroFramework.Controls.MetroLabel lblHeaderMiscs;
        private MetroFramework.Controls.MetroCheckBox cbAimbotRecoilHelper;
    }
}