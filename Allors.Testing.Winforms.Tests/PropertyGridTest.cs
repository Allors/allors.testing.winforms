// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyGridTest.cs" company="allors bvba">
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
    using Allors.Testing.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using NUnit.Framework;

    [TestFixture]
    public class PropertyGridTest : WinformsTest
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
        public void FindPropertyGridItem()
        {
            var propertygridtester = new PropertyGridTester("propertyGrid1");
            GridItemTester aFirstX = propertygridtester.FindGridItem("FirstX");
            GridItemTester bFirstX = propertygridtester.FindGridItem("B", "FirstX");
            GridItemTester cFirstX = propertygridtester.FindGridItem("B", "C", "FirstX");

            Assert.AreEqual("A First X", aFirstX.Value.ToString());
            Assert.AreEqual("B First X", bFirstX.Value.ToString());
            Assert.AreEqual("C First X", cFirstX.Value.ToString());
        }
    }
}