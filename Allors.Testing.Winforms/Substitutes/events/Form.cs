// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form.cs" company="allors bvba">
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

namespace Allors.Testing.Winforms.Substitutes
{
    using System;

    using Allors.Testing.Winforms.Domain;

    public partial class Form
    {
        protected override void OnShown(EventArgs e)
        {
Console.WriteLine("Onshown - A - " + this.GetHashCode());
            base.OnShown(e);
Console.WriteLine("Onshown - B - " + this.GetHashCode());
            Session.Singleton.OnTestingWinformsEvent(this.handle, TestingWinformsEventKind.Shown);
Console.WriteLine("Onshown - C - " + this.GetHashCode());
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnShown(e);
            Session.Singleton.OnTestingWinformsEvent(this.handle, TestingWinformsEventKind.Activated);
        }
    }
}