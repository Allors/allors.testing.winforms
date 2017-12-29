// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBoxTest.cs" company="allors bvba">
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
    public class CheckBoxTest : WinformsTest
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
            var tester = new CheckBoxTester("checkBox1");
            Assert.IsNotNull(tester.Target);
            Assert.IsInstanceOf<CheckBox>(tester.Target);
        }

        [Test]
        public void CheckCheckBox()
        {
            var checkBox = new CheckBoxTester("checkBox1");
            checkBox.Target.Checked = true;
            Assert.IsTrue(checkBox.Target.Checked);
            checkBox.Target.Checked = false;
            Assert.IsFalse(checkBox.Target.Checked);

            checkBox.Target.Text = "tuttefrut";
            Assert.AreEqual("tuttefrut", checkBox.Target.Text);
        }
    }
}