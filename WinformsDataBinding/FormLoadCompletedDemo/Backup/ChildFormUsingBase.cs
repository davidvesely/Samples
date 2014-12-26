using System;
using System.Windows.Forms;

namespace FormLoadCompletedDemo
{
	public partial class ChildFormUsingBase : BaseForm
	{
		public ChildFormUsingBase()
		{
			InitializeComponent();
		}

		private void ChildFormUsingBase_LoadCompleted()
		{
			this.Cursor = Cursors.WaitCursor;

			for (int l = 0; l < 50000; l++)
				this.listBox1.Items.Add("Item " + l.ToString());

			this.Cursor = Cursors.Default;
		}

		private void ChildFormUsingBase_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Without the following, subsequent instances of this form would load
			//  slower than the 1st call, distorting the time-delay of this demo.
			listBox1.Items.Clear();
			GC.Collect();

		}
	}
}
