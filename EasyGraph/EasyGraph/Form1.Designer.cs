﻿namespace EasyGraph
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.xInput = new System.Windows.Forms.RichTextBox();
            this.Build = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yInput = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Language = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.Donation = new System.Windows.Forms.ToolStripMenuItem();
            this.output = new System.Windows.Forms.RichTextBox();
            this.Save = new System.Windows.Forms.SaveFileDialog();
            this.PageOuput = new System.Windows.Forms.TabPage();
            this.PageEdit = new System.Windows.Forms.TabPage();
            this.PointEdit = new System.Windows.Forms.Panel();
            this.ColorPointBox = new System.Windows.Forms.TextBox();
            this.ColorPoint = new System.Windows.Forms.Label();
            this.NamePointBox = new System.Windows.Forms.TextBox();
            this.NamePoint = new System.Windows.Forms.Label();
            this.LineEdit = new System.Windows.Forms.Panel();
            this.ColorLineBox = new System.Windows.Forms.TextBox();
            this.ColorLine = new System.Windows.Forms.Label();
            this.NameLineBox = new System.Windows.Forms.TextBox();
            this.NameLine = new System.Windows.Forms.Label();
            this.PointSel = new System.Windows.Forms.ComboBox();
            this.LineSel = new System.Windows.Forms.ComboBox();
            this.PageChart = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.DoneLine = new System.Windows.Forms.Button();
            this.DonePoint = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.PageOuput.SuspendLayout();
            this.PageEdit.SuspendLayout();
            this.PointEdit.SuspendLayout();
            this.LineEdit.SuspendLayout();
            this.PageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // xInput
            // 
            this.xInput.BackColor = System.Drawing.SystemColors.ControlLight;
            this.xInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xInput.Font = new System.Drawing.Font("Arial", 12F);
            this.xInput.ForeColor = System.Drawing.Color.Black;
            this.xInput.Location = new System.Drawing.Point(32, 37);
            this.xInput.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.xInput.Multiline = false;
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(540, 18);
            this.xInput.TabIndex = 1;
            this.xInput.Text = "[0,1,2,3,3,4,5,6,6,7,8,9,9,10,11,12,12,11,10,9,8,7,6,5,4,3,2,1,0]";
            // 
            // Build
            // 
            this.Build.AutoSize = true;
            this.Build.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Build.FlatAppearance.BorderSize = 0;
            this.Build.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Build.Font = new System.Drawing.Font("Arial", 12F);
            this.Build.ForeColor = System.Drawing.Color.Black;
            this.Build.Location = new System.Drawing.Point(13, 85);
            this.Build.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(95, 28);
            this.Build.TabIndex = 3;
            this.Build.Text = "Build";
            this.Build.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "x=";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "y=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yInput
            // 
            this.yInput.BackColor = System.Drawing.SystemColors.ControlLight;
            this.yInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yInput.Font = new System.Drawing.Font("Arial", 12F);
            this.yInput.ForeColor = System.Drawing.Color.Black;
            this.yInput.Location = new System.Drawing.Point(32, 61);
            this.yInput.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.yInput.Multiline = false;
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(540, 18);
            this.yInput.TabIndex = 2;
            this.yInput.Text = "[0,1,2,3][3,4,5,6][6,5,4,3][3,2,1,0][0,0,0,0,0,0,0,0,0,0,0,0,0]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Options,
            this.Donation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(584, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAs});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(35, 19);
            this.File.Text = "File";
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(180, 22);
            this.SaveAs.Text = "Save chart as";
            // 
            // Options
            // 
            this.Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Language});
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(56, 19);
            this.Options.Text = "Options";
            // 
            // Language
            // 
            this.Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageEnglish,
            this.LanguageRussian});
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(180, 22);
            this.Language.Text = "Language";
            // 
            // LanguageEnglish
            // 
            this.LanguageEnglish.Name = "LanguageEnglish";
            this.LanguageEnglish.Size = new System.Drawing.Size(111, 22);
            this.LanguageEnglish.Text = "English";
            // 
            // LanguageRussian
            // 
            this.LanguageRussian.Name = "LanguageRussian";
            this.LanguageRussian.Size = new System.Drawing.Size(111, 22);
            this.LanguageRussian.Text = "Russian";
            // 
            // Donation
            // 
            this.Donation.Name = "Donation";
            this.Donation.Size = new System.Drawing.Size(62, 19);
            this.Donation.Text = "Donation";
            // 
            // output
            // 
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Font = new System.Drawing.Font("Arial", 12F);
            this.output.ForeColor = System.Drawing.Color.Black;
            this.output.Location = new System.Drawing.Point(7, 7);
            this.output.Margin = new System.Windows.Forms.Padding(4);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(538, 338);
            this.output.TabIndex = 5;
            this.output.TabStop = false;
            this.output.Text = "";
            // 
            // PageOuput
            // 
            this.PageOuput.Controls.Add(this.output);
            this.PageOuput.Location = new System.Drawing.Point(4, 27);
            this.PageOuput.Name = "PageOuput";
            this.PageOuput.Padding = new System.Windows.Forms.Padding(3);
            this.PageOuput.Size = new System.Drawing.Size(552, 352);
            this.PageOuput.TabIndex = 2;
            this.PageOuput.Text = "Output";
            this.PageOuput.UseVisualStyleBackColor = true;
            // 
            // PageEdit
            // 
            this.PageEdit.Controls.Add(this.PointEdit);
            this.PageEdit.Controls.Add(this.LineEdit);
            this.PageEdit.Controls.Add(this.PointSel);
            this.PageEdit.Controls.Add(this.LineSel);
            this.PageEdit.Location = new System.Drawing.Point(4, 27);
            this.PageEdit.Name = "PageEdit";
            this.PageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.PageEdit.Size = new System.Drawing.Size(552, 352);
            this.PageEdit.TabIndex = 1;
            this.PageEdit.Text = "Edit";
            this.PageEdit.UseVisualStyleBackColor = true;
            // 
            // PointEdit
            // 
            this.PointEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PointEdit.Controls.Add(this.DonePoint);
            this.PointEdit.Controls.Add(this.ColorPointBox);
            this.PointEdit.Controls.Add(this.ColorPoint);
            this.PointEdit.Controls.Add(this.NamePointBox);
            this.PointEdit.Controls.Add(this.NamePoint);
            this.PointEdit.Location = new System.Drawing.Point(280, 38);
            this.PointEdit.Name = "PointEdit";
            this.PointEdit.Size = new System.Drawing.Size(268, 308);
            this.PointEdit.TabIndex = 9;
            // 
            // ColorPointBox
            // 
            this.ColorPointBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ColorPointBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColorPointBox.Location = new System.Drawing.Point(13, 80);
            this.ColorPointBox.Name = "ColorPointBox";
            this.ColorPointBox.Size = new System.Drawing.Size(243, 19);
            this.ColorPointBox.TabIndex = 4;
            this.ColorPointBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColorPoint
            // 
            this.ColorPoint.Location = new System.Drawing.Point(3, 51);
            this.ColorPoint.Name = "ColorPoint";
            this.ColorPoint.Size = new System.Drawing.Size(262, 26);
            this.ColorPoint.TabIndex = 2;
            this.ColorPoint.Text = "Color:";
            this.ColorPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NamePointBox
            // 
            this.NamePointBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NamePointBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NamePointBox.Location = new System.Drawing.Point(13, 29);
            this.NamePointBox.Name = "NamePointBox";
            this.NamePointBox.Size = new System.Drawing.Size(243, 19);
            this.NamePointBox.TabIndex = 1;
            this.NamePointBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NamePoint
            // 
            this.NamePoint.Location = new System.Drawing.Point(3, 0);
            this.NamePoint.Name = "NamePoint";
            this.NamePoint.Size = new System.Drawing.Size(262, 26);
            this.NamePoint.TabIndex = 0;
            this.NamePoint.Text = "Name:";
            this.NamePoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineEdit
            // 
            this.LineEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LineEdit.Controls.Add(this.DoneLine);
            this.LineEdit.Controls.Add(this.ColorLineBox);
            this.LineEdit.Controls.Add(this.ColorLine);
            this.LineEdit.Controls.Add(this.NameLineBox);
            this.LineEdit.Controls.Add(this.NameLine);
            this.LineEdit.Location = new System.Drawing.Point(6, 38);
            this.LineEdit.Name = "LineEdit";
            this.LineEdit.Size = new System.Drawing.Size(268, 308);
            this.LineEdit.TabIndex = 8;
            // 
            // ColorLineBox
            // 
            this.ColorLineBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ColorLineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColorLineBox.Location = new System.Drawing.Point(13, 80);
            this.ColorLineBox.Name = "ColorLineBox";
            this.ColorLineBox.Size = new System.Drawing.Size(243, 19);
            this.ColorLineBox.TabIndex = 4;
            this.ColorLineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColorLine
            // 
            this.ColorLine.Location = new System.Drawing.Point(3, 51);
            this.ColorLine.Name = "ColorLine";
            this.ColorLine.Size = new System.Drawing.Size(262, 26);
            this.ColorLine.TabIndex = 2;
            this.ColorLine.Text = "Color:";
            this.ColorLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLineBox
            // 
            this.NameLineBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NameLineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameLineBox.Location = new System.Drawing.Point(13, 29);
            this.NameLineBox.Name = "NameLineBox";
            this.NameLineBox.Size = new System.Drawing.Size(243, 19);
            this.NameLineBox.TabIndex = 1;
            this.NameLineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameLine
            // 
            this.NameLine.Location = new System.Drawing.Point(3, 0);
            this.NameLine.Name = "NameLine";
            this.NameLine.Size = new System.Drawing.Size(262, 26);
            this.NameLine.TabIndex = 0;
            this.NameLine.Text = "Name:";
            this.NameLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PointSel
            // 
            this.PointSel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PointSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PointSel.FormattingEnabled = true;
            this.PointSel.Location = new System.Drawing.Point(353, 6);
            this.PointSel.Name = "PointSel";
            this.PointSel.Size = new System.Drawing.Size(121, 26);
            this.PointSel.TabIndex = 7;
            // 
            // LineSel
            // 
            this.LineSel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LineSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineSel.FormattingEnabled = true;
            this.LineSel.Location = new System.Drawing.Point(78, 6);
            this.LineSel.Name = "LineSel";
            this.LineSel.Size = new System.Drawing.Size(121, 26);
            this.LineSel.TabIndex = 6;
            // 
            // PageChart
            // 
            this.PageChart.Controls.Add(this.chart);
            this.PageChart.Location = new System.Drawing.Point(4, 27);
            this.PageChart.Name = "PageChart";
            this.PageChart.Padding = new System.Windows.Forms.Padding(3);
            this.PageChart.Size = new System.Drawing.Size(552, 352);
            this.PageChart.TabIndex = 0;
            this.PageChart.Text = "Chart";
            this.PageChart.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.Location = new System.Drawing.Point(7, 7);
            this.chart.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(538, 338);
            this.chart.TabIndex = 5;
            this.chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.PageChart);
            this.TabControl.Controls.Add(this.PageEdit);
            this.TabControl.Controls.Add(this.PageOuput);
            this.TabControl.Location = new System.Drawing.Point(13, 119);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(560, 383);
            this.TabControl.TabIndex = 5;
            // 
            // DoneLine
            // 
            this.DoneLine.AutoSize = true;
            this.DoneLine.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DoneLine.FlatAppearance.BorderSize = 0;
            this.DoneLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneLine.Font = new System.Drawing.Font("Arial", 12F);
            this.DoneLine.ForeColor = System.Drawing.Color.Black;
            this.DoneLine.Location = new System.Drawing.Point(87, 273);
            this.DoneLine.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.DoneLine.Name = "DoneLine";
            this.DoneLine.Size = new System.Drawing.Size(95, 28);
            this.DoneLine.TabIndex = 5;
            this.DoneLine.Text = "Done";
            this.DoneLine.UseVisualStyleBackColor = false;
            // 
            // DonePoint
            // 
            this.DonePoint.AutoSize = true;
            this.DonePoint.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DonePoint.FlatAppearance.BorderSize = 0;
            this.DonePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DonePoint.Font = new System.Drawing.Font("Arial", 12F);
            this.DonePoint.ForeColor = System.Drawing.Color.Black;
            this.DonePoint.Location = new System.Drawing.Point(87, 273);
            this.DonePoint.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.DonePoint.Name = "DonePoint";
            this.DonePoint.Size = new System.Drawing.Size(95, 28);
            this.DonePoint.TabIndex = 6;
            this.DonePoint.Text = "Done";
            this.DonePoint.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 514);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyGraph";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PageOuput.ResumeLayout(false);
            this.PageEdit.ResumeLayout(false);
            this.PointEdit.ResumeLayout(false);
            this.PointEdit.PerformLayout();
            this.LineEdit.ResumeLayout(false);
            this.LineEdit.PerformLayout();
            this.PageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStripMenuItem LanguageRussian;
        public System.Windows.Forms.ToolStripMenuItem LanguageEnglish;
        public System.Windows.Forms.Button Build;
        public System.Windows.Forms.TabControl TabControl;
        public System.Windows.Forms.TabPage PageChart;
        public System.Windows.Forms.RichTextBox xInput;
        public System.Windows.Forms.RichTextBox yInput;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox output;
        public System.Windows.Forms.ToolStripMenuItem Options;
        public System.Windows.Forms.ToolStripMenuItem Language;
        public System.Windows.Forms.ToolStripMenuItem Donation;
        public System.Windows.Forms.ToolStripMenuItem File;
        public System.Windows.Forms.ToolStripMenuItem SaveAs;
        public System.Windows.Forms.TabPage PageOuput;
        public System.Windows.Forms.TabPage PageEdit;
        public System.Windows.Forms.Panel PointEdit;
        public System.Windows.Forms.TextBox ColorPointBox;
        public System.Windows.Forms.Label ColorPoint;
        public System.Windows.Forms.TextBox NamePointBox;
        public System.Windows.Forms.Label NamePoint;
        public System.Windows.Forms.Panel LineEdit;
        public System.Windows.Forms.TextBox ColorLineBox;
        public System.Windows.Forms.Label ColorLine;
        public System.Windows.Forms.TextBox NameLineBox;
        public System.Windows.Forms.Label NameLine;
        public System.Windows.Forms.ComboBox PointSel;
        public System.Windows.Forms.ComboBox LineSel;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.SaveFileDialog Save;
        public System.Windows.Forms.Button DonePoint;
        public System.Windows.Forms.Button DoneLine;
    }
}

