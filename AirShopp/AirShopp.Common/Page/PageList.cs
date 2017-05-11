
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
            if (pageSize == null) { pageSize = 12; }//默认每页显示10条数据
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

        int[] pageBar;
        public int[] getPageBar()
        {
            // 小于等于7 -> 页码序列为1-pageNum
            if (TotalPage <= 7)
            {
                pageBar = new int[TotalPage];
                for (int i = 0; i < TotalPage; i++)
                {
                    pageBar[i] = i + 1;
                }
            }
            else
            {
                pageBar = new int[7];
                // pageNum > 7 且 currentPage <= 4 --> 序列是1,2,3,4,5,...,pageNum
                if (PageIndex <= 4)
                {
                    for (int i = 0; i < 5; i++)
                        pageBar[i] = i + 1;
                    pageBar[5] = 0;
                    pageBar[6] = TotalPage;
                }
                else
                {
                    // pageNum > 7 且 currentPage > 4 且 pageNum - currenPage <= 3
                    // 序列是 1,...,pn-4,pn-3,pn-2,pn-1,pn
                    if (TotalPage - PageIndex <= 3)
                    {
                        pageBar[0] = 1;
                        pageBar[1] = 0;
                        for (int i = 2; i < pageBar.Length; i++)
                        {
                            pageBar[i] = TotalPage - (6 - i);
                        }
                    }
                    else
                    {
                        // 除上述特例, 序列是 1,...,cp-1,cp,cp+1,...,pn
                        pageBar[0] = 1;
                        pageBar[1] = pageBar[5] = 0;
                        pageBar[2] = PageIndex - 1;
                        pageBar[3] = PageIndex;
                        pageBar[4] = PageIndex + 1;
                        pageBar[6] = TotalPage;
                    }
                }
            }
            return pageBar;
        }

        public void setPageBar(int[] pageBar)
        {
            this.pageBar = pageBar;
        }
    }
}


