namespace AirShopp.Common.Page
{
    public interface IPageList
    {
        int TotalPage //总页数
        {
            get;
        }

        int TotalCount//总数量
        {
            get;
            set;
        }

        int PageIndex//第几页
        {
            get;
            set;
        }

        int PageSize//一页显示几条数据
        {
            get;
            set;
        }

        bool IsPreviousPage//是否上一页
        {
            get;
        }

        bool IsNextPage//是否下一页
        {
            get;
        }
    }
}
