// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingNavigatorTest.cs" company="allors bvba">
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
    using System.CodeDom;
    using System.Windows.Forms;

    using Allors.Immersive.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using NUnit.Framework;

    [TestFixture]
    public class BindingNavigatorTest : WinformsTest
    {
        private DefaultForm form;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.form = new DefaultForm();
            this.form.Show();
        }

        [Test]
        public void FindTesterByName()
        {
            var tester = new BindingNavigatorTester("bindingNavigator1");
            Assert.IsNotNull(tester.Target);
            Assert.IsInstanceOf<BindingNavigator>(tester.Target);
        }

        [Test]
        public void TesterHandlesEvents()
        {
            var bindingNavigator = new BindingNavigatorTester("bindingNavigator1");
            
            var datagridview = new DataGridViewTester("dataGridView1");
            Assert.AreEqual(3, datagridview.Target.RowCount);

            Assert.AreEqual("bindingNavigator1", bindingNavigator.Target.Name);

            Assert.AreEqual("of 3", bindingNavigator.Target.CountItem.Text);
          
            bindingNavigator.AddNewItem();

            Assert.AreEqual(4, datagridview.Target.RowCount);
            Assert.AreEqual("of 4", bindingNavigator.Target.CountItem.Text);
        }

        [Test]
        public void CustomConstructor()
        {
            var button = new ButtonTester("buttonAddBindingNavigator");
            button.Click();

            var panel = new PanelTester("emptyPanel");
            Assert.AreEqual(1, panel.Target.Controls.Count);
        }
    }
}