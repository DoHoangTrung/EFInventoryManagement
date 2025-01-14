﻿using DGVPrinterHelper;
using QuanLyKhoHang.DAO;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKhoHang.View
{

    public partial class Nghich : Form
    {

        InventoryContext db = new InventoryContext();

        public Nghich()
        {
            InitializeComponent();
        }


        private void Nghich_Load(object sender, EventArgs e)
        {

        }

        private void dtgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dtgv.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dtgv.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dtgv.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dtgv.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
        }

        private void dtgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }
    }
}
