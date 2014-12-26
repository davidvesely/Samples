namespace FormLoadCompletedDemo
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
			this.btnShown = new System.Windows.Forms.Button();
			this.btnShownDoEvents = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnChildUsingBase = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnShown
			// 
			this.btnShown.Location = new System.Drawing.Point(50, 49);
			this.btnShown.Name = "btnShown";
			this.btnShown.Size = new System.Drawing.Size(193, 23);
			this.btnShown.TabIndex = 1;
			this.btnShown.Text = "Open Form Without DoEvents";
			this.btnShown.UseVisualStyleBackColor = true;
			this.btnShown.Click += new System.EventHandler(this.btnShown_Click);
			// 
			// btnShownDoEvents
			// 
			this.btnShownDoEvents.Location = new System.Drawing.Point(50, 78);
			this.btnShownDoEvents.Name = "btnShownDoEvents";
			this.btnShownDoEvents.Size = new System.Drawing.Size(193, 23);
			this.btnShownDoEvents.TabIndex = 2;
			this.btnShownDoEvents.Text = "Open Form *With* DoEvents";
			this.btnShownDoEvents.UseVisualStyleBackColor = true;
			this.btnShownDoEvents.Click += new System.EventHandler(this.btnShownDoEvents_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(50, 20);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(193, 23);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Do processing in Load event";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnChildUsingBase
			// 
			this.btnChildUsingBase.Location = new System.Drawing.Point(50, 138);
			this.btnChildUsingBase.Name = "btnChildUsingBase";
			this.btnChildUsingBase.Size = new System.Drawing.Size(193, 23);
			this.btnChildUsingBase.TabIndex = 3;
			this.btnChildUsingBase.Text = "Open Form derived from BaseForm";
			this.btnChildUsingBase.UseVisualStyleBackColor = true;
			this.btnChildUsingBase.Click += new System.EventHandler(this.btnChildUsingBase_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 183);
			this.Controls.Add(this.btnChildUsingBase);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnShownDoEvents);
			this.Controls.Add(this.btnShown);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormLoadCompleteDemo";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnShown;
		private System.Windows.Forms.Button btnShownDoEvents;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnChildUsingBase;
	}
}

