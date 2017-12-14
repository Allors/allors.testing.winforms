// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxTest.cs" company="allors bvba">
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
    using Allors.Immersive.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using NUnit.Framework;

    [TestFixture]
    public class TextBoxTest : WinformsTest
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
        public void MultipleReference()
        {
            var textBox1a = new TextBoxTester("textBox1");
            var textBox1b = new TextBoxTester("textBox1");


            textBox1a.Target.Text = "Ok!";

            Assert.AreEqual("Ok!", textBox1a.Target.Text);
            Assert.AreEqual("Ok!", textBox1b.Target.Text);
        }

        [Test]
        public void Read()
        {
            var textBox1 = new TextBoxTester("textBox1");
            var textBox2 = new TextBoxTester("textBox2");
            var button1 = new ButtonTester("button1");

            Assert.AreEqual(string.Empty, textBox1.Target.Text);
            Assert.AreEqual(string.Empty, textBox2.Target.Text);

            textBox1.Target.Text = "Ok!";
            button1.Click();

            Assert.AreEqual("Ok!", textBox1.Target.Text);
            Assert.AreEqual("Ok!", textBox2.Target.Text);
        }
    }
}