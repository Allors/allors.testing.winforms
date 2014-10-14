// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinformsTest.cs" company="allors bvba">
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
    using System;
    using System.Collections;
    using System.Windows.Forms;

    using Allors.Testing.Winforms;
    using Allors.Testing.Winforms.Domain;

    using NUnit.Framework;

    public abstract class WinformsTest
    {
        private Desktop desktop;
        protected Session test;

        private void EventOccured(object sender, TestingWinformsEventArgs args)
        {
            switch (args.Kind)
            {
                case TestingWinformsEventKind.Shown:
Console.WriteLine("Sender: " + sender);
                    OnShown(args);
                    break;
                case TestingWinformsEventKind.CheckedChanged:
                    OnCheckedChanged(args);
                    break;
                case TestingWinformsEventKind.MouseClick:
                    OnClick(args);
                    break;
                default:
                    break;
            }
        }

        [SetUp]
        public virtual void SetUp()
        {
            this.desktop = new Desktop();

            Session.Singleton.Reset();

            this.test = Session.Singleton;

            this.test.TestingWinformsEvent += this.EventOccured;
        }

        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                foreach (Form form in new ArrayList(Application.OpenForms))
                {
                    try
                    {
                        form.Dispose();
                    }
                    catch { }
                }
            }
            finally
            {
                this.desktop.Dispose();
            }
        }

        protected virtual void OnClick(TestingWinformsEventArgs args)
        {
            
        }

        protected virtual void OnShown(TestingWinformsEventArgs args)
        {
        }

        protected virtual void OnCheckedChanged(TestingWinformsEventArgs args)
        {
        }

    }
}