// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataGridViewTest.cs" company="allors bvba">
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

namespace Allors.Immersive.Winforms.Tests
{
    using System.Windows.Forms;

    using Allors.Immersive.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using NUnit.Framework;

    [TestFixture]
    public class DataGridViewTest : WinformsTest
    {
        const string GridName = "dataGridView1";
        const string ButtonName = "button1";

        private DataGridViewForm form;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.form = new DataGridViewForm();
            this.form.Show();
        }

        [Test]
        public void FindTesterByName()
        {
            var tester = new DataGridViewTester("dataGridView1");
            Assert.IsNotNull(tester.Target);
            Assert.IsInstanceOf<DataGridView>(tester.Target);
        }

        [Test]
        public void FindRow()
        {
            var tester = new DataGridViewTester("dataGridView1");

            var row = tester.FindRow(v => v.Index == 0);
            Assert.IsNotNull(row);
            Assert.IsInstanceOf<DataGridViewRow>(row);
        }

        [Test]
        public void FindRows()
        {
            var tester = new DataGridViewTester("dataGridView1");

            var rows = tester.FindRows(v => v.Index > 0 && v.Index < 5);
            Assert.IsNotNull(rows);
            Assert.AreEqual(4, rows.Length);
        }


        [Test]
        public void GetRowCount()
        {
            var dataGridView = new DataGridViewTester(GridName);
            Assert.That(dataGridView.Target.Rows.Count, Is.EqualTo(10));
        }

        [Test]
        public void GetColumnCount()
        {
            var dataGridView = new DataGridViewTester(GridName);
            Assert.That(dataGridView.Target.Columns.Count, Is.EqualTo(2));
        }

        [Test]
        public void CanTestCellContent()
        {
            var dataGridView = new DataGridViewTester(GridName);   
            Assert.That(dataGridView.Target.Rows[0].Cells["Name"].Value, Is.EqualTo("person0"));
        }

        [Test]
        public void CanTestSelectedRows()
        {
            var dataGridView = new DataGridViewTester(GridName);
            var button1 = new ButtonTester(ButtonName);

            button1.Click();

            var selectedRows = dataGridView.Target.SelectedRows;
            Assert.That(selectedRows.Count, Is.EqualTo(5));

            foreach(DataGridViewRow row in selectedRows)
            {
                Assert.That(row.Selected, Is.EqualTo(row.Index % 2 == 0));
            }
        }

        [Test]
        public void CanSetSelectedRows()
        {
            var dataGridView = new DataGridViewTester(GridName);
            
            foreach(DataGridViewRow row in dataGridView.Target.Rows)
            {
                // Select the odd rows here ...
                row.Selected = row.Index % 2 != 0;
            }

            var selectedRows = dataGridView.Target.SelectedRows;

            Assert.That(selectedRows.Count, Is.EqualTo(5));

            foreach (DataGridViewRow row in selectedRows)
            {
                Assert.That(row.Selected, Is.EqualTo(row.Index % 2 != 0));
            }
        }
    }
}