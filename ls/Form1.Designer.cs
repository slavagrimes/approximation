namespace ls
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelInputCount = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.dataClear = new System.Windows.Forms.Button();
            this.Calc1 = new System.Windows.Forms.Button();
            this.labelInputTable = new System.Windows.Forms.Label();
            this.dataGridTable = new System.Windows.Forms.DataGridView();
            this.valueX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).BeginInit();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1074, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.программаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(104, 25);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxInput.Controls.Add(this.button2);
            this.groupBoxInput.Controls.Add(this.button1);
            this.groupBoxInput.Controls.Add(this.label1);
            this.groupBoxInput.Controls.Add(this.numericUpDown1);
            this.groupBoxInput.Controls.Add(this.labelInputCount);
            this.groupBoxInput.Controls.Add(this.quantity);
            this.groupBoxInput.Controls.Add(this.dataClear);
            this.groupBoxInput.Controls.Add(this.Calc1);
            this.groupBoxInput.Controls.Add(this.labelInputTable);
            this.groupBoxInput.Controls.Add(this.dataGridTable);
            this.groupBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxInput.Location = new System.Drawing.Point(10, 32);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(530, 509);
            this.groupBoxInput.TabIndex = 5;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Ввод данных";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(0, 465);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 39);
            this.button2.TabIndex = 13;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(132, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Заполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Количество столбцов в таблице";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(313, 55);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(93, 29);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDownCount_ValueChanged);
            // 
            // labelInputCount
            // 
            this.labelInputCount.AutoSize = true;
            this.labelInputCount.Location = new System.Drawing.Point(6, 25);
            this.labelInputCount.Name = "labelInputCount";
            this.labelInputCount.Size = new System.Drawing.Size(268, 24);
            this.labelInputCount.TabIndex = 9;
            this.labelInputCount.Text = "Количество строк в таблице";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(279, 22);
            this.quantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(93, 29);
            this.quantity.TabIndex = 8;
            this.quantity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.numericUpDownCount_ValueChanged);
            // 
            // dataClear
            // 
            this.dataClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataClear.Location = new System.Drawing.Point(267, 465);
            this.dataClear.Name = "dataClear";
            this.dataClear.Size = new System.Drawing.Size(114, 38);
            this.dataClear.TabIndex = 5;
            this.dataClear.Text = "Очистить";
            this.dataClear.UseVisualStyleBackColor = true;
            this.dataClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Calc1
            // 
            this.Calc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Calc1.Location = new System.Drawing.Point(387, 465);
            this.Calc1.Name = "Calc1";
            this.Calc1.Size = new System.Drawing.Size(137, 38);
            this.Calc1.TabIndex = 4;
            this.Calc1.Text = "Вычислить";
            this.Calc1.UseVisualStyleBackColor = true;
            this.Calc1.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // labelInputTable
            // 
            this.labelInputTable.AutoSize = true;
            this.labelInputTable.Location = new System.Drawing.Point(6, 83);
            this.labelInputTable.Name = "labelInputTable";
            this.labelInputTable.Size = new System.Drawing.Size(161, 24);
            this.labelInputTable.TabIndex = 0;
            this.labelInputTable.Text = "Введите данные";
            // 
            // dataGridTable
            // 
            this.dataGridTable.AllowUserToAddRows = false;
            this.dataGridTable.AllowUserToResizeColumns = false;
            this.dataGridTable.AllowUserToResizeRows = false;
            this.dataGridTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueX,
            this.inputY});
            this.dataGridTable.Location = new System.Drawing.Point(10, 110);
            this.dataGridTable.Name = "dataGridTable";
            this.dataGridTable.RowHeadersWidth = 45;
            this.dataGridTable.ShowEditingIcon = false;
            this.dataGridTable.Size = new System.Drawing.Size(507, 349);
            this.dataGridTable.TabIndex = 3;
            // 
            // valueX
            // 
            this.valueX.HeaderText = "X";
            this.valueX.MinimumWidth = 6;
            this.valueX.Name = "valueX";
            // 
            // inputY
            // 
            this.inputY.HeaderText = "Y";
            this.inputY.MinimumWidth = 6;
            this.inputY.Name = "inputY";
            this.inputY.Width = 110;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.Controls.Add(this.richTextBoxResult);
            this.groupBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxResult.Location = new System.Drawing.Point(546, 32);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(535, 509);
            this.groupBoxResult.TabIndex = 6;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Вычисление коэффициентов и вывод функции";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResult.Location = new System.Drawing.Point(3, 25);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxResult.Size = new System.Drawing.Size(529, 481);
            this.richTextBoxResult.TabIndex = 6;
            this.richTextBoxResult.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 551);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Полиномиальная аппроксимация методом наименьших квадратов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).EndInit();
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Button dataClear;
        private System.Windows.Forms.Button Calc1;
        private System.Windows.Forms.Label labelInputTable;
        private System.Windows.Forms.DataGridView dataGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueX;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputY;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Label labelInputCount;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

