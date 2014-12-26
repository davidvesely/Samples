using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Q105657
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(Record);
            bindingSource1.Add(new Record(1, "record 1"));
            gridControl1.DataSource = bindingSource1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bindingSource1.Add(new Record(2, "new record"));
        }
    }

    public class Record
    {
        private int _id;
        private string _text;

        public Record(int id, string text)
        {
            _id = id;
            _text = text;
        }

        public int ID
        {
            get { return _id; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

    }
}
