using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang
{
    public class MyPagedList<T>
    {
        public int pageNum { get; set; }

        public IPagedList<T> pageList { get; set; }

        public MyPagedList()
        {
            pageNum = 0;
            pageList = null;
        }

        public MyPagedList(int pageNum, IPagedList<T> list)
        {
            this.pageNum = pageNum;
            this.pageList = list;
        }
    }
}
