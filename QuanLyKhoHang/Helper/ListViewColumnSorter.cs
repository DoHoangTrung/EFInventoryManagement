using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public class ListViewColumnSorter : IComparer
    {
        private int columnToSort;
        private SortOrder sortOrder;
        private CaseInsensitiveComparer objectCompare;

        public ListViewColumnSorter()
        {
            this.columnToSort = 0;
            this.sortOrder = SortOrder.None;
            this.objectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listViewItemX = (ListViewItem)x;
            ListViewItem listViewItemY = (ListViewItem)y;

            compareResult = objectCompare.Compare(listViewItemX.SubItems[columnToSort].Text, listViewItemY.SubItems[columnToSort].Text);
            if (sortOrder == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (sortOrder == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            get { return columnToSort; }
            set { columnToSort = value; }
        }

        public SortOrder Order
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }
    }
}
