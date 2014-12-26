using System;
using System.Windows.Forms;

namespace FormLoadCompletedDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void ShowChildForm(ChildForm.LoadStyle ls)
		{
			ChildForm frm = new ChildForm(ls);
			frm.ShowDialog();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			ShowChildForm(ChildForm.LoadStyle.OnLoad);
		}

		private void btnShown_Click(object sender, EventArgs e)
		{
			ShowChildForm(ChildForm.LoadStyle.OnShown);
		}

		private void btnShownDoEvents_Click(object sender, EventArgs e)
		{
			ShowChildForm(ChildForm.LoadStyle.OnShownDoEvents);
		}

		private void btnChildUsingBase_Click(object sender, EventArgs e)
		{
			ChildFormUsingBase frm = new ChildFormUsingBase();
			frm.ShowDialog();
		}
	}
}
