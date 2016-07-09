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
    public partial class InsertContact : System.Web.UI.Page
    {
        protected List<ContactGroup> list = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.Form["txtName"]))
            {
                ContactGroupBll bll = new ContactGroupBll();
                list = bll.GetAllGroup();
            }
            else
            {
                Contact model = new Contact();
                model.ContactName = Request.Form["txtName"];
                model.CellPhone = Request.Form["txtPhone"];
                model.Email = Request.Form["txtEmail"];
                model.Group = new ContactGroup();
                model.Group.GroupId=Convert.ToInt32(Request.Form["selGroup"]);
                ContactBll bll = new ContactBll();
                int r = bll.Insert(model);
                if(r>0)
                {
                    Response.Redirect("ShowContact.aspx");
                }
                else
                {
                    Response.Write("添加失败");
                }
            }
        }
    }
}