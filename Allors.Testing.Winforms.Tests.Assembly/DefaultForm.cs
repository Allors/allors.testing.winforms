// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultForm.cs" company="allors bvba">
//   Copyright 2008-2014 Allors bvba.
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU Lesser General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU Lesser General Public License for more details.
//   
//   You should have received a copy of the GNU Lesser General Public License
//   along with this program.  If not, see http://www.gnu.org/licenses.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace AllorsTestWindowsAssembly
{
    using System;
    using System.Windows.Forms;

    public partial class DefaultForm : Form
    {
        public DefaultForm()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = new A();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Text;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Text;
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = e.Node.Text;
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = e.Location.ToString();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = menuItem1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm();
            dialogForm.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = MessageBox.Show("Hello", "Hello").ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "toolStripMenuItem1";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "toolStripButton1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
Console.WriteLine(0);
            DialogForm dialogForm = new DialogForm();

Console.WriteLine(dialogForm.GetHashCode());

Console.WriteLine(1);
            dialogForm.ShowDialog(this);
Console.WriteLine(2);
        }
    }
}