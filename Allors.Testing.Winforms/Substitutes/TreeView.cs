// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeView.cs" company="allors bvba">
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
    using System.Windows.Forms;

    using Allors.Binary.Attributes;
    using Allors.Testing.Winforms.Domain;

    [SubstituteClass]
    public partial class TreeView : System.Windows.Forms.TreeView, ISubstitute
    {
        private readonly Handle handle;

        public TreeView()
        {
            this.handle = Session.Singleton.Create(this);
        }

        #region Target Members

        public string SubstituteName
        {
            get { return Name; }
        }

        #endregion

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            Session.Singleton.OnTestingWinformsEvent(this.handle, TestingWinformsEventKind.NodeMouseClick);
        }

        protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        {
            base.OnNodeMouseHover(e);
            Session.Singleton.OnTestingWinformsEvent(this.handle, TestingWinformsEventKind.NodeMouseHover);
        }

        public void PerformClick(TreeNode treeNode)
        {
            SelectedNode = treeNode;
            OnNodeMouseClick(new TreeNodeMouseClickEventArgs(treeNode, MouseButtons.Left, 1, treeNode.Bounds.Left, 
                                                             treeNode.Bounds.Top));
        }
    }
}