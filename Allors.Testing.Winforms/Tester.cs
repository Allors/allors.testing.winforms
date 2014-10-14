// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tester.cs" company="allors bvba">
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
namespace Allors.Testing.Winforms
{
    using Allors.Testing.Winforms.Domain;

    public class Tester<T> where T : ISubstitute
    {
        private Handle handle;

        public Tester(Handle handle)
        {
            this.handle = handle;
        }

        public Tester(params string[] names) : this(Session.Singleton.FindTester(names))
        {
        }

        public Handle Handle
        {
            get { return this.handle; }
        }

        public T Target
        {
            get { return (T) this.handle.Substitute; }
        }
    }
}