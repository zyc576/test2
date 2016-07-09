using crud.bll;
using crud.model;
using CRUD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud.ui
{
    public partial class ShowContact : System.Web.UI.Page
    {
        protected List<Contact> list = null;
        protected string page = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndet=string.IsNullOrEmpty(Request.QueryString["pageindex"])?1:Convert.ToInt32(Request.QueryString["pageindex"]);
            int pageSize=string.IsNullOrEmpty(Request.QueryString["pagesize"])?5:Convert.ToInt32(Request.QueryString["pagesize"]);
            int pageCount,recordCount;
            ContactBll bll = new ContactBll();
            list = bll.SelectMsgByPage(pageSize, pageIndet, out recordCount, out pageCount);
            page = PagerHelper.strPage(recordCount, pageSize, pageCount, pageIndet, "ShowContact.aspx?pagesize=5&pageindex=");
        }
    }
}