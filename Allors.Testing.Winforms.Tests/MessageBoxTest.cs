// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxTest.cs" company="allors bvba">
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
namespace Allors.Testing.Winforms.Tests
{
    using System.Windows.Forms;

    using Allors.Testing.Winforms;
    using Allors.Testing.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using NUnit.Framework;

    [TestFixture]
    public class MessageBoxTest : WinformsTest
    {
        private DefaultForm form;
        private DialogResult dialogResult;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.form = new DefaultForm();
            this.form.Show();
        }

        protected override void OnShown(TestingWinformsEventArgs args)
        {
            var tester = args.Handle;
            if (tester != null && tester.Name.Equals("Hello"))
            {
                var messageBoxTester = new MessageBoxTester(tester);
                messageBoxTester.Target.DialogResult = dialogResult;
            }
        }

        [Test]
        public void Show()
        {
            var button3 = new ButtonTester("button3");
            var textBox1 = new TextBoxTester("textBox1");

            dialogResult = DialogResult.OK;
            button3.Click();

            Assert.AreEqual("OK", textBox1.Target.Text);

            dialogResult = DialogResult.Cancel;
            button3.Click();

            Assert.AreEqual("Cancel", textBox1.Target.Text);
        }
    }
}