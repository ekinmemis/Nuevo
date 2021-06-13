
using Nuevo.Web.Paging;

using System.Web.Mvc;

namespace Nuevo.Web.Extensions
{
    public static class HtmlExtensions
    {
        public static Pager Pager(this HtmlHelper helper, IPageableModel pagination)
        {
            return new Pager(pagination, helper.ViewContext);
        }
    }
}

