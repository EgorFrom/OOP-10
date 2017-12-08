using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectingStrings = new LinkedList<string>();
        }
        LinkedList<string> SelectingStrings;
        string SelectedItem = "";
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.None && e.Button == MouseButtons.Left)
            {
                SelectingStrings.Clear();
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                    SelectingStrings.AddFirst(listBox1.SelectedItems[i].ToString());
                listBox1.DoDragDrop(SelectingStrings, DragDropEffects.All);
                SelectedItem = "listBox1";
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if(SelectedItem == "listBox2")
            {
                foreach (string Node in SelectingStrings)
                {
                    listBox1.Items.Add(Node);
                    listBox2.Items.Remove(Node);
                }

            }
        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.None && e.Button == MouseButtons.Left)
            {
                SelectingStrings.Clear();
                for (int i = 0; i < listBox2.SelectedItems.Count; i++)
                    SelectingStrings.AddFirst(listBox2.SelectedItems[i].ToString());
                listBox2.DoDragDrop(SelectingStrings, DragDropEffects.All);
                SelectedItem = "listBox2";
            }
        }

        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            if(SelectedItem == "listBox1")
            {
                foreach(string Node in SelectingStrings)
                {
                    listBox2.Items.Add(Node);
                    listBox1.Items.Remove(Node);
                }
            }
            

        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            //if (SelectedItem == "listBox1" || SelectedItem == "listBox2")
            //    e.Effect = DragDropEffects.All;
        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
