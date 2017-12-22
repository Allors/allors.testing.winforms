// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Session.cs" company="allors bvba">
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

namespace Allors.Immersive.Winforms.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Session 
    {
        public static readonly Session Singleton;

        private readonly List<Handle> handles;

        private TestingWinformsEventHandler testingWinformsEvent;

        static Session()
        {
            Singleton = new Session();
        }

        private Session()
        {
            this.handles = new List<Handle>();
        }

        public event TestingWinformsEventHandler TestingWinformsEvent
        {
            add
            {
                this.testingWinformsEvent = value;
            }

            remove
            {
                this.testingWinformsEvent -= value;
            }
        }

        public void Reset()
        {
            this.handles.Clear();
        }

        public Handle Create(ISubstitute substitute)
        {
            var handle = new Handle(this, substitute);
            this.handles.Add(handle);

            Console.WriteLine("-> " + handle);

            return handle;
        }

        public Handle FindTester(params string[] names)
        {
            if (names != null && names.Length > 0)
            {
                var name = names[names.Length - 1];

                for (var i = this.handles.Count - 1; i >= 0; --i)
                {
                    var handle = this.handles[i];

                    if (handle.Name.Equals(name))
                    {
                        var matched = true;
                        var parent = handle;
                        for (var j = names.Length - 2; j >= 0; j--)
                        {
                            parent = parent.Parent;
                            if (parent == null || !parent.Name.Equals(names[j]))
                            {
                                matched = false;
                                break;
                            }
                        }

                        if (matched)
                        {
                            return handle;
                        }
                    }
                }
            }
 
            return null;
        }
        
        public Handle FindTester(object testedObject)
        {
            return this.handles.FirstOrDefault(tester => testedObject.Equals(tester.Substitute));
        }

        internal void OnTestingWinformsEvent(Handle source, TestingWinformsEventKind testingWinformsEventKind)
        {
            Console.WriteLine("--- Event Fired --- " + source + " --- " + testingWinformsEventKind);
            var eventHandler = this.testingWinformsEvent;
            if (eventHandler != null)
            {
                var args = new TestingWinformsEventArgs(source, testingWinformsEventKind);
                eventHandler(source, args);
            }
        }
    }
}
