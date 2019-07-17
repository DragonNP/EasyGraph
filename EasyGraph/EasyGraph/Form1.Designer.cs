namespace EasyGraph
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
            this.showValues = new System.Windows.Forms.ToolStripMenuItem();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Language = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.Donation = new System.Windows.Forms.ToolStripMenuItem();
            this.output = new System.Windows.Forms.RichTextBox();
            this.Save = new System.Windows.Forms.SaveFileDialog();
            this.PageOuput = new System.Windows.Forms.TabPage();
            this.PageEdit = new System.Windows.Forms.TabPage();
            this.EditControl = new System.Windows.Forms.TabControl();
            this.PageLines = new System.Windows.Forms.TabPage();
            this.LineSel = new System.Windows.Forms.ComboBox();
            this.LineEdit = new System.Windows.Forms.Panel();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PagePoints = new System.Windows.Forms.TabPage();
            this.PageChart = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ColorBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.PageOuput.SuspendLayout();
            this.PageEdit.SuspendLayout();
            this.EditControl.SuspendLayout();
            this.PageLines.SuspendLayout();
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
            this.xInput.Size = new System.Drawing.Size(300, 18);
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
            this.Build.Location = new System.Drawing.Point(126, 85);
            this.Build.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(95, 28);
            this.Build.TabIndex = 3;
            this.Build.Text = "Построить";
            this.Build.UseVisualStyleBackColor = false;
            this.Build.Click += new System.EventHandler(this.Build_Click);
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
            this.yInput.Size = new System.Drawing.Size(300, 18);
            this.yInput.TabIndex = 2;
            this.yInput.Text = "[0,1,2,3][3,4,5,6][6,5,4,3][3,2,1,0][0,0,0,0,0,0,0,0,0,0,0,0,0]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.showValues,
            this.Options,
            this.Donation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAs});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(45, 18);
            this.File.Text = "Файл";
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(168, 22);
            this.SaveAs.Text = "Сохранаить как...";
            // 
            // showValues
            // 
            this.showValues.Name = "showValues";
            this.showValues.Size = new System.Drawing.Size(117, 18);
            this.showValues.Text = "Показать значения";
            // 
            // Options
            // 
            this.Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Language});
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(51, 18);
            this.Options.Text = "Опции";
            // 
            // Language
            // 
            this.Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageEnglish,
            this.LanguageRussian});
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(100, 22);
            this.Language.Text = "Язык";
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
            this.Donation.Size = new System.Drawing.Size(100, 18);
            this.Donation.Text = "Пожертвование";
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
            this.PageOuput.Text = "Вывод";
            this.PageOuput.UseVisualStyleBackColor = true;
            // 
            // PageEdit
            // 
            this.PageEdit.Controls.Add(this.EditControl);
            this.PageEdit.Location = new System.Drawing.Point(4, 27);
            this.PageEdit.Name = "PageEdit";
            this.PageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.PageEdit.Size = new System.Drawing.Size(552, 352);
            this.PageEdit.TabIndex = 1;
            this.PageEdit.Text = "Редактирование";
            this.PageEdit.UseVisualStyleBackColor = true;
            // 
            // EditControl
            // 
            this.EditControl.Controls.Add(this.PageLines);
            this.EditControl.Controls.Add(this.PagePoints);
            this.EditControl.Location = new System.Drawing.Point(7, 7);
            this.EditControl.Name = "EditControl";
            this.EditControl.SelectedIndex = 0;
            this.EditControl.Size = new System.Drawing.Size(539, 339);
            this.EditControl.TabIndex = 0;
            // 
            // PageLines
            // 
            this.PageLines.Controls.Add(this.LineSel);
            this.PageLines.Controls.Add(this.LineEdit);
            this.PageLines.Location = new System.Drawing.Point(4, 27);
            this.PageLines.Name = "PageLines";
            this.PageLines.Padding = new System.Windows.Forms.Padding(3);
            this.PageLines.Size = new System.Drawing.Size(531, 308);
            this.PageLines.TabIndex = 0;
            this.PageLines.Text = "Линии";
            this.PageLines.UseVisualStyleBackColor = true;
            // 
            // LineSel
            // 
            this.LineSel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LineSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineSel.FormattingEnabled = true;
            this.LineSel.Location = new System.Drawing.Point(6, 6);
            this.LineSel.Name = "LineSel";
            this.LineSel.Size = new System.Drawing.Size(121, 26);
            this.LineSel.TabIndex = 2;
            this.LineSel.DropDownClosed += new System.EventHandler(this.LineSel_DropDownClosed);
            // 
            // LineEdit
            // 
            this.LineEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LineEdit.Controls.Add(this.ColorBox);
            this.LineEdit.Controls.Add(this.ColorLabel);
            this.LineEdit.Controls.Add(this.NameBox);
            this.LineEdit.Controls.Add(this.NameLabel);
            this.LineEdit.Location = new System.Drawing.Point(6, 38);
            this.LineEdit.Name = "LineEdit";
            this.LineEdit.Size = new System.Drawing.Size(519, 264);
            this.LineEdit.TabIndex = 1;
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Location = new System.Drawing.Point(7, 32);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(48, 18);
            this.ColorLabel.TabIndex = 2;
            this.ColorLabel.Text = "Цвет:";
            this.ColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Location = new System.Drawing.Point(91, 7);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 19);
            this.NameBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(7, 7);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(82, 18);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Название:";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PagePoints
            // 
            this.PagePoints.Location = new System.Drawing.Point(4, 27);
            this.PagePoints.Name = "PagePoints";
            this.PagePoints.Padding = new System.Windows.Forms.Padding(3);
            this.PagePoints.Size = new System.Drawing.Size(531, 308);
            this.PagePoints.TabIndex = 1;
            this.PagePoints.Text = "Точки";
            this.PagePoints.UseVisualStyleBackColor = true;
            // 
            // PageChart
            // 
            this.PageChart.Controls.Add(this.chart);
            this.PageChart.Location = new System.Drawing.Point(4, 27);
            this.PageChart.Name = "PageChart";
            this.PageChart.Padding = new System.Windows.Forms.Padding(3);
            this.PageChart.Size = new System.Drawing.Size(552, 352);
            this.PageChart.TabIndex = 0;
            this.PageChart.Text = "График";
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
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseClick);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.PageChart);
            this.TabControl.Controls.Add(this.PageEdit);
            this.TabControl.Controls.Add(this.PageOuput);
            this.TabControl.Location = new System.Drawing.Point(12, 119);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(560, 383);
            this.TabControl.TabIndex = 5;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColorBox.Location = new System.Drawing.Point(61, 32);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(100, 19);
            this.ColorBox.TabIndex = 4;
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
            this.EditControl.ResumeLayout(false);
            this.PageLines.ResumeLayout(false);
            this.LineEdit.ResumeLayout(false);
            this.LineEdit.PerformLayout();
            this.PageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox xInput;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox yInput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showValues;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.ToolStripMenuItem Options;
        private System.Windows.Forms.ToolStripMenuItem Language;
        private System.Windows.Forms.ToolStripMenuItem Donation;
        public System.Windows.Forms.ToolStripMenuItem LanguageRussian;
        public System.Windows.Forms.ToolStripMenuItem LanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.SaveFileDialog Save;
        private System.Windows.Forms.TabPage PageOuput;
        private System.Windows.Forms.TabPage PageEdit;
        private System.Windows.Forms.TabPage PageChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabControl EditControl;
        private System.Windows.Forms.TabPage PageLines;
        private System.Windows.Forms.TabPage PagePoints;
        private System.Windows.Forms.Panel LineEdit;
        private System.Windows.Forms.ComboBox LineSel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.TextBox ColorBox;
    }
}

