using System;
using System.Windows.Forms;

namespace FormLoadCompletedDemo
{
	public partial class ChildForm : Form
	{
		public enum LoadStyle
		{
			OnLoad,
			OnShown,
			OnShownDoEvents
		}

		private LoadStyle _ls;

		public ChildForm(LoadStyle ls)
		{
			InitializeComponent();
			_ls = ls;
		}

		private void ChildForm_Load(object sender, EventArgs e)
		{
			if (_ls == LoadStyle.OnLoad)
				LoadList();
		}

		private void ChildForm_Shown(object sender, EventArgs e)
		{
			if (_ls == LoadStyle.OnShown)
				LoadList();
			else if (_ls == LoadStyle.OnShownDoEvents)
			{
				Application.DoEvents();
				LoadList();
			}
		}

		private void LoadList()
		{
			this.Cursor = Cursors.WaitCursor;

			for (int l = 0; l < 50000; l++)
				this.listBox1.Items.Add("Item " + l.ToString());

			this.Cursor = Cursors.Default;
		}

		private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Without the following, subsequent instances of this form would load
			//  slower than the 1st call, distorting the time-delay of this demo.
			listBox1.Items.Clear();
			GC.Collect();
		}

	}
}
