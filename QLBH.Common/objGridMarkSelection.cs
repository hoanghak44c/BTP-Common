using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace QLBH.Common
{
	public class objGridMarkSelection {
        protected GridView view;
        // Use a binding list so we get a live list of selected objects
        public BindingList<object> selection = new BindingList<object>();
        private GridColumn column;
        private RepositoryItemCheckEdit edit;
        private int row;
      
        public objGridMarkSelection()
            : base()
        {
        }

        public objGridMarkSelection(GridView view)
            : this()
        {
            View = view;
        }
        #region Actions

        protected virtual void Attach(GridView view)
        {
            if (view == null) return;
            selection.Clear();
            this.view = view;
            edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            edit.EditValueChanged += new EventHandler(edit_EditValueChanged);

            column = view.Columns.Add();
            column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            column.VisibleIndex = 0;
            //column.Fixed = FixedStyle.Left;
            column.FieldName = "CheckMarkSelection";
            column.Caption = " ";
            column.OptionsColumn.ShowCaption = true;
            column.OptionsColumn.FixedWidth = true;
            column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            column.ColumnEdit = edit;
            column.Width = 50;

            view.Click += new EventHandler(View_Click);
            //view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            view.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            view.RowStyle += new RowStyleEventHandler(view_RowStyle);
            view.RowClick += new RowClickEventHandler(view_RowClick);
        }

       

        protected virtual void Detach()
        {
            if (view == null) return;
            if (column != null)
                column.Dispose();
            if (edit != null)
            {
                try
                {
                    view.GridControl.RepositoryItems.Remove(edit);
                    edit.Dispose();
                }
                catch { }
            }

            view.Click -= new EventHandler(View_Click);
            //view.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            view.CustomDrawGroupRow -= new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            view.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            view.RowStyle -= new RowStyleEventHandler(view_RowStyle);
            view.RowClick += new RowClickEventHandler(view_RowClick);
            view = null;
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }



        public GridView View
        {
            get
            {
                return view;
            }
            set
            {
                if (view != value)
                {
                    Detach();
                    Attach(value);
                }
            }
        }

        public GridColumn CheckMarkColumn
        {
            get
            {
                return column;
            }
          
        }

        public int SelectedCount
        {
            get
            {
                return selection.Count;
            }
        }

        public void RemoveSelect() 
        {
            selection.RemoveAt(row);
        }

        public int SelectRowIndex {
            get {
                return row;
            }
        }

        public object GetSelectedRow(int index)
        {
            return selection[index];
        }

        public int GetSelectedIndex(object row)
        {
            return selection.IndexOf(row);
        }

        public void ClearSelection()
        {
            selection.Clear();
            Invalidate();
        }

        private void Invalidate()
        {
            view.BeginUpdate();
            view.EndUpdate();
        }

        public void SelectAll()
        {
            selection.Clear();
            if (view.DataRowCount > 0)
            {
                for (int i = 0; i < view.DataRowCount; i++)  // slow
                    selection.Add(view.GetRow(i));
                Invalidate();
            }
        }

        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }

        public void SelectRow(int rowHandle, bool select)
        {
            SelectRow(rowHandle, select, true);
        }

        private void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = view.GetRow(rowHandle);
            if (select)
                selection.Add(row);
            else
                selection.Remove(row);
            
            if (invalidate)
            {
                Invalidate();
            }
        }

        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int row = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row)) return false;
                }
                else
                    if (!IsRowSelected(row)) return false;
            }
            return true;
        }

        public bool IsRowSelected(int rowHandle)
        {
            if (view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);

            object row = view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        #endregion

        #region Events

        private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == CheckMarkColumn)
            {
                if (e.IsGetData)
                    e.Value = IsRowSelected(e.RowHandle);
                else
                    SelectRow(e.RowHandle, (bool)e.Value);
            }
        }

        private void edit_EditValueChanged(object sender, EventArgs e)
        {
            view.PostEditor();
        }

        private void View_Click(object sender, EventArgs e)
        {
            //row = e.RowHandle;
            GridHitInfo info;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            info = view.CalcHitInfo(pt);
            if (info.InColumn && info.Column == column)
            {
                if (SelectedCount == view.DataRowCount)
                    ClearSelection();
                else
                    SelectAll();
            }
            if (info.InRow && view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
            {
                bool selected = IsGroupRowSelected(info.RowHandle);
                SelectGroup(info.RowHandle, !selected);
            }
        }

        //private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        //{
        //    if (e.Column == column)
        //    {
        //        e.Info.InnerElements.Clear();
        //        e.Painter.DrawObject(e.Info);
        //        DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == view.DataRowCount);
        //        e.Handled = true;
        //    }
        //}

        private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
            info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;

            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);

            Rectangle r = info.ButtonBounds;
            r.Offset(r.Width * 2, 0);
            DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }

        void view_RowStyle(object sender, RowStyleEventArgs e)
        {
            
            if (IsRowSelected(e.RowHandle))
            {
              //  e.Appearance.BackColor = Color.SkyBlue;
               // e.Appearance.ForeColor = SystemColors.HighlightText;
            }
        }

        void view_RowClick(object sender, RowClickEventArgs e)
        {
            row = e.RowHandle;
        }

        #endregion
    }
}
