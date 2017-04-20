
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirShopp.Common.Page
{
    public class PageList<T>:List<T>, IPageList
    {
        public bool IsNextPage
        {
            get
            {
                return (PageIndex * PageSize) < TotalCount;
            }
        }

        public bool IsPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int TotalPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PageSize);
            }
        }

        public PageList(IQueryable<T> source, int? pageIndex, int? pageSize)
        {
            if (pageIndex == null) { pageIndex = 1; }//默认显示第一页数据
            if (pageSize == null) { pageSize = 10; }//默认每页显示10条数据
            this.TotalCount = source.Count();
            this.PageSize = pageSize.Value;
            this.PageIndex = pageIndex.Value;

            if (IsPreviousPage == false)
            {
                pageIndex = 1;
            }

            if (IsNextPage == false)
            {
                pageIndex = TotalPage;
            }
            int BeforePageIndex = pageIndex.Value - 1;
            if (BeforePageIndex < 0)
            {
                BeforePageIndex = 0;
            }
            AddRange(source.Skip((BeforePageIndex) * pageSize.Value).Take(pageSize.Value));
            //如果Index是0会报错，不能够是负数
        }
    }
}


