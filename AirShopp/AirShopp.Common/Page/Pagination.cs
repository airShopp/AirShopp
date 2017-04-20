using System.Linq;

namespace AirShopp.Common.Page
{
    public static class Pagination
    {
        /// <summary>
        /// 返回第几页的数据
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="source">数据源，数据源需继承IQueryable接口</param>
        /// <param name="index">第几页</param>
        /// <param name="pageSize">每页显示的数据条数，默认每页显示10条数据</param>
        /// <returns></returns>
        public static PageList<T> ToPagedList<T>(this IQueryable<T> source, int? index, int? pageSize)
        {
            return new PageList<T>(source, index, pageSize);
        }
    }
}
