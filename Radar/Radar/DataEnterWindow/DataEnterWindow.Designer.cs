namespace Radar
{
    partial class DataEnterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEnterWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sensorCountField = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EnterDataBut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.side2Field = new System.Windows.Forms.NumericUpDown();
            this.side1Field = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupListUserControl1 = new Radar.GroupListUserControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorCountField)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.side2Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.side1Field)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sensorCountField);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 0;
            // 
            // sensorCountField
            // 
            this.sensorCountField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorCountField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorCountField.Location = new System.Drawing.Point(673, 12);
            this.sensorCountField.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sensorCountField.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.sensorCountField.Name = "sensorCountField";
            this.sensorCountField.Size = new System.Drawing.Size(120, 27);
            this.sensorCountField.TabIndex = 7;
            this.sensorCountField.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sensorCountField.ValueChanged += new System.EventHandler(this.sensorCountField_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Введите количество датчиков";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EnterDataBut);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 39);
            this.panel2.TabIndex = 1;
            // 
            // EnterDataBut
            // 
            this.EnterDataBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnterDataBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterDataBut.Location = new System.Drawing.Point(0, 0);
            this.EnterDataBut.Name = "EnterDataBut";
            this.EnterDataBut.Size = new System.Drawing.Size(800, 39);
            this.EnterDataBut.TabIndex = 0;
            this.EnterDataBut.Text = "Внести данные";
            this.EnterDataBut.UseVisualStyleBackColor = true;
            this.EnterDataBut.Click += new System.EventHandler(this.EnterDataBut_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.side2Field);
            this.panel3.Controls.Add(this.side1Field);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 108);
            this.panel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(271, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "м";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(271, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "м";
            // 
            // side2Field
            // 
            this.side2Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.side2Field.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.side2Field.Location = new System.Drawing.Point(145, 67);
            this.side2Field.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.side2Field.Name = "side2Field";
            this.side2Field.Size = new System.Drawing.Size(120, 23);
            this.side2Field.TabIndex = 4;
            this.side2Field.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.side2Field.ValueChanged += new System.EventHandler(this.side2Field_ValueChanged);
            // 
            // side1Field
            // 
            this.side1Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.side1Field.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.side1Field.Location = new System.Drawing.Point(145, 38);
            this.side1Field.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.side1Field.Name = "side1Field";
            this.side1Field.Size = new System.Drawing.Size(120, 23);
            this.side1Field.TabIndex = 3;
            this.side1Field.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.side1Field.ValueChanged += new System.EventHandler(this.side1Field_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "сторона 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "сторона 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(188, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите параметры защищаемой области";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 324);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupListUserControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 280);
            this.panel5.TabIndex = 2;
            // 
            // groupListUserControl1
            // 
            this.groupListUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupListUserControl1.Location = new System.Drawing.Point(0, 0);
            this.groupListUserControl1.Name = "groupListUserControl1";
            this.groupListUserControl1.Size = new System.Drawing.Size(800, 280);
            this.groupListUserControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(347, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(102, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Обработка";
            // 
            // DataEnterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataEnterWindow";
            this.Text = "DataEnterWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataEnterWindow_FormClosing);
            this.Load += new System.EventHandler(this.DataEnterWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorCountField)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.side2Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.side1Field)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown sensorCountField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button EnterDataBut;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown side2Field;
        private System.Windows.Forms.NumericUpDown side1Field;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel5;
        private GroupListUserControl groupListUserControl1;
    }
}