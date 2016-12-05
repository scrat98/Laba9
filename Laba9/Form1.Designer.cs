namespace Laba9
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
            this.TextInput = new System.Windows.Forms.RichTextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.Fano = new System.Windows.Forms.TabControl();
            this.Default = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DefImg = new System.Windows.Forms.PictureBox();
            this.Huffman = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.HuffmanImg = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FanoImg = new System.Windows.Forms.PictureBox();
            this.LoadImg = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Kvant = new System.Windows.Forms.RichTextBox();
            this.DefaultInfo = new System.Windows.Forms.RichTextBox();
            this.KodHuffman = new System.Windows.Forms.RichTextBox();
            this.KodFano = new System.Windows.Forms.RichTextBox();
            this.Fano.SuspendLayout();
            this.Default.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefImg)).BeginInit();
            this.Huffman.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HuffmanImg)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FanoImg)).BeginInit();
            this.SuspendLayout();
            // 
            // TextInput
            // 
            this.TextInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextInput.Location = new System.Drawing.Point(12, 7);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(665, 47);
            this.TextInput.TabIndex = 1;
            this.TextInput.Text = "Hello!";
            this.TextInput.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Location = new System.Drawing.Point(683, 7);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(87, 24);
            this.Generate.TabIndex = 2;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // Fano
            // 
            this.Fano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fano.Controls.Add(this.Default);
            this.Fano.Controls.Add(this.Huffman);
            this.Fano.Controls.Add(this.tabPage3);
            this.Fano.Location = new System.Drawing.Point(12, 103);
            this.Fano.Name = "Fano";
            this.Fano.SelectedIndex = 0;
            this.Fano.Size = new System.Drawing.Size(740, 438);
            this.Fano.TabIndex = 7;
            // 
            // Default
            // 
            this.Default.Controls.Add(this.splitContainer3);
            this.Default.Location = new System.Drawing.Point(4, 25);
            this.Default.Name = "Default";
            this.Default.Padding = new System.Windows.Forms.Padding(3);
            this.Default.Size = new System.Drawing.Size(732, 409);
            this.Default.TabIndex = 0;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DefaultInfo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.DefImg);
            this.splitContainer3.Size = new System.Drawing.Size(726, 403);
            this.splitContainer3.SplitterDistance = 242;
            this.splitContainer3.TabIndex = 2;
            // 
            // DefImg
            // 
            this.DefImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DefImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefImg.Location = new System.Drawing.Point(0, 0);
            this.DefImg.Name = "DefImg";
            this.DefImg.Size = new System.Drawing.Size(480, 403);
            this.DefImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DefImg.TabIndex = 1;
            this.DefImg.TabStop = false;
            // 
            // Huffman
            // 
            this.Huffman.Controls.Add(this.splitContainer1);
            this.Huffman.Location = new System.Drawing.Point(4, 25);
            this.Huffman.Name = "Huffman";
            this.Huffman.Padding = new System.Windows.Forms.Padding(3);
            this.Huffman.Size = new System.Drawing.Size(732, 409);
            this.Huffman.TabIndex = 1;
            this.Huffman.Text = "Huffman";
            this.Huffman.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.KodHuffman);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.HuffmanImg);
            this.splitContainer1.Size = new System.Drawing.Size(726, 403);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 2;
            // 
            // HuffmanImg
            // 
            this.HuffmanImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HuffmanImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HuffmanImg.Location = new System.Drawing.Point(0, 0);
            this.HuffmanImg.Name = "HuffmanImg";
            this.HuffmanImg.Size = new System.Drawing.Size(485, 403);
            this.HuffmanImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HuffmanImg.TabIndex = 0;
            this.HuffmanImg.TabStop = false;
            this.HuffmanImg.Click += new System.EventHandler(this.HuffmanImg_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fano";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.KodFano);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.FanoImg);
            this.splitContainer2.Size = new System.Drawing.Size(726, 403);
            this.splitContainer2.SplitterDistance = 242;
            this.splitContainer2.TabIndex = 1;
            // 
            // FanoImg
            // 
            this.FanoImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FanoImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FanoImg.Location = new System.Drawing.Point(0, 0);
            this.FanoImg.Name = "FanoImg";
            this.FanoImg.Size = new System.Drawing.Size(480, 403);
            this.FanoImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FanoImg.TabIndex = 0;
            this.FanoImg.TabStop = false;
            this.FanoImg.Click += new System.EventHandler(this.FanoImg_Click);
            // 
            // LoadImg
            // 
            this.LoadImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadImg.Location = new System.Drawing.Point(683, 37);
            this.LoadImg.Name = "LoadImg";
            this.LoadImg.Size = new System.Drawing.Size(87, 26);
            this.LoadImg.TabIndex = 8;
            this.LoadImg.Text = "Load img";
            this.LoadImg.UseVisualStyleBackColor = true;
            this.LoadImg.Click += new System.EventHandler(this.LoadImg_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(692, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "as Img";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(683, 66);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(87, 23);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Kvant
            // 
            this.Kvant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Kvant.Location = new System.Drawing.Point(12, 60);
            this.Kvant.Name = "Kvant";
            this.Kvant.Size = new System.Drawing.Size(665, 37);
            this.Kvant.TabIndex = 12;
            this.Kvant.Text = "Квантования не было.";
            // 
            // DefaultInfo
            // 
            this.DefaultInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultInfo.Location = new System.Drawing.Point(3, 3);
            this.DefaultInfo.Name = "DefaultInfo";
            this.DefaultInfo.Size = new System.Drawing.Size(237, 397);
            this.DefaultInfo.TabIndex = 0;
            this.DefaultInfo.Text = "";
            // 
            // KodHuffman
            // 
            this.KodHuffman.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KodHuffman.Location = new System.Drawing.Point(3, 3);
            this.KodHuffman.Name = "KodHuffman";
            this.KodHuffman.Size = new System.Drawing.Size(231, 397);
            this.KodHuffman.TabIndex = 0;
            this.KodHuffman.Text = "";
            // 
            // KodFano
            // 
            this.KodFano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KodFano.Location = new System.Drawing.Point(3, 3);
            this.KodFano.Name = "KodFano";
            this.KodFano.Size = new System.Drawing.Size(236, 397);
            this.KodFano.TabIndex = 0;
            this.KodFano.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Kvant);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LoadImg);
            this.Controls.Add(this.Fano);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.TextInput);
            this.Name = "Form1";
            this.Text = "Кодирование";
            this.Fano.ResumeLayout(false);
            this.Default.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DefImg)).EndInit();
            this.Huffman.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HuffmanImg)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FanoImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox TextInput;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TabControl Fano;
        private System.Windows.Forms.TabPage Default;
        private System.Windows.Forms.TabPage Huffman;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button LoadImg;
        private System.Windows.Forms.PictureBox HuffmanImg;
        private System.Windows.Forms.PictureBox FanoImg;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox DefImg;
        private System.Windows.Forms.RichTextBox Kvant;
        private System.Windows.Forms.RichTextBox DefaultInfo;
        private System.Windows.Forms.RichTextBox KodHuffman;
        private System.Windows.Forms.RichTextBox KodFano;
    }
}

