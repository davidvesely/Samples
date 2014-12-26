namespace FormLoadCompletedDemo
{
	partial class ChildForm
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(6, 59);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(112, 134);
			this.listBox1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(6, 59);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(174, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(6, 86);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(174, 21);
			this.comboBox2.TabIndex = 2;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(6, 113);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(174, 21);
			this.comboBox3.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.comboBox4);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Location = new System.Drawing.Point(166, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(193, 199);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "These controls don\'t fully render in form_Shown() unless you call DoEvents() *bef" +
				"ore* loading listBox1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBox1);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(135, 199);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "This list is loaded with 50k items in order to delay the initial rendering of the" +
				" form.";
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(6, 140);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(174, 21);
			this.comboBox4.TabIndex = 4;
			// 
			// comboBox5
			// 
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Location = new System.Drawing.Point(6, 167);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(174, 21);
			this.comboBox5.TabIndex = 5;
			// 
			// ChildForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 224);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChildForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ChildForm";
			this.Load += new System.EventHandler(this.ChildForm_Load);
			this.Shown += new System.EventHandler(this.ChildForm_Shown);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChildForm_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.ComboBox comboBox4;
	}
}