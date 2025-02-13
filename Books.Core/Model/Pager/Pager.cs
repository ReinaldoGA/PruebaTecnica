using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Model.Pager
{
    public class Pager
    {
        public int? CurrentPage;
        public int? PageSize;
        public int? TotalPage;

        public Pager(int? CurrentPage, int? PageSize, int? TotalPage)
        {
            this.CurrentPage = CurrentPage;
            this.PageSize = PageSize;
            this.TotalPage = TotalPage;
        }
    }
}
