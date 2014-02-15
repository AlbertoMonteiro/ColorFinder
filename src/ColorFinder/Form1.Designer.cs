namespace ColorFinder
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColorDiff = new System.Windows.Forms.TextBox();
            this.txtHexadecimal = new System.Windows.Forms.TextBox();
            this.txtARBG = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.niColorFinder = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsColorFinder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cmsColorFinder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtColorDiff);
            this.panel1.Controls.Add(this.txtHexadecimal);
            this.panel1.Controls.Add(this.txtARBG);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 95);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "RGB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hexadecimal:";
            // 
            // txtColorDiff
            // 
            this.txtColorDiff.Location = new System.Drawing.Point(93, 37);
            this.txtColorDiff.Name = "txtColorDiff";
            this.txtColorDiff.Size = new System.Drawing.Size(281, 22);
            this.txtColorDiff.TabIndex = 18;
            // 
            // txtHexadecimal
            // 
            this.txtHexadecimal.Location = new System.Drawing.Point(167, 9);
            this.txtHexadecimal.Name = "txtHexadecimal";
            this.txtHexadecimal.Size = new System.Drawing.Size(65, 22);
            this.txtHexadecimal.TabIndex = 17;
            // 
            // txtARBG
            // 
            this.txtARBG.Location = new System.Drawing.Point(283, 9);
            this.txtARBG.Name = "txtARBG";
            this.txtARBG.Size = new System.Drawing.Size(91, 22);
            this.txtARBG.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(238, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 20);
            this.panel3.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 72);
            this.panel2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 22);
            this.textBox1.TabIndex = 13;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Base color:";
            // 
            // niColorFinder
            // 
            this.niColorFinder.ContextMenuStrip = this.cmsColorFinder;
            this.niColorFinder.Icon = ((System.Drawing.Icon)(resources.GetObject("niColorFinder.Icon")));
            this.niColorFinder.Text = "Color Finder";
            this.niColorFinder.Visible = true;
            // 
            // cmsColorFinder
            // 
            this.cmsColorFinder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFechar});
            this.cmsColorFinder.Name = "cmsColorFinder";
            this.cmsColorFinder.Size = new System.Drawing.Size(153, 48);
            this.cmsColorFinder.Text = "Fechar";
            // 
            // tsmiFechar
            // 
            this.tsmiFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiFechar.Name = "tsmiFechar";
            this.tsmiFechar.Size = new System.Drawing.Size(152, 22);
            this.tsmiFechar.Text = "&Fechar";
            this.tsmiFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsmiFechar.Click += new System.EventHandler(this.tsmiFechar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 95);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Color Picker";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsColorFinder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColorDiff;
        private System.Windows.Forms.TextBox txtHexadecimal;
        private System.Windows.Forms.TextBox txtARBG;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon niColorFinder;
        private System.Windows.Forms.ContextMenuStrip cmsColorFinder;
        private System.Windows.Forms.ToolStripMenuItem tsmiFechar;

    }
}

