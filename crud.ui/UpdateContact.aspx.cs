using crud.bll;
using crud.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud.ui
{
    public partial class UpdateContact : System.Web.UI.Page
    {
        protected Contact model = null;
        protected List<ContactGroup>list = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Form["txtName"]==null)
            {
                ContactGroupBll bll=new ContactGroupBll ();
                list = bll.GetAllGroup();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ContactBll bll2 = new ContactBll();
                model = bll2.SelectMsgById(id);
            }
            else
            {
                Contact model = new Contact();
                model.ContactId =Convert.ToInt32(Request.Form["id"]);
                model.ContactName = Request.Form["txtName"];
                model.CellPhone = Request.Form["txtPhone"];
                model.Email = Request.Form["txtEmail"];
                model.Group = new ContactGroup();
                model.Group.GroupId =Convert.ToInt32(Request.Form["selGroup"]);
                ContactBll bll = new ContactBll();
                int r = bll.Update(model);
                if(r>0)
                {
                    Response.Redirect("ShowContact.aspx");
                }
                else
                {
                    Response.Write("更新失败");
                }
            }
           
        }
    }
}