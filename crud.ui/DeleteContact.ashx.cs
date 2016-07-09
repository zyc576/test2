using crud.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud.ui
{
    /// <summary>
    /// DeleteContact 的摘要说明
    /// </summary>
    public class DeleteContact : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id =Convert.ToInt32(context.Request.QueryString["id"]);
            ContactBll bll = new ContactBll();
            int r = bll.Delete(id);
            if(r>0)
            {
                context.Response.Redirect("ShowContact.aspx");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}