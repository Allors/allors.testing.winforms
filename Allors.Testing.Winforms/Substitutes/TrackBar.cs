// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackBar.cs" company="allors bvba">
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
    using Allors.Binary.Attributes;
    using Allors.Testing.Winforms.Domain;

    [SubstituteClass]
    public partial class TrackBar : System.Windows.Forms.TrackBar, ISubstitute
    {
        private Handle handle;

        public TrackBar()
        {
            this.handle = Session.Singleton.Create(this);
        }

        #region Target Members

        public string SubstituteName
        {
            get { return Name; }
        }

        #endregion
    }
}