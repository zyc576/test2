using crud.dal;
using crud.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.bll
{
   public class ContactGroupBll
    {
        //获得所有的分组信息
       ContactGroupDal dal = new ContactGroupDal();
       public List<ContactGroup> GetAllGroup()
       {
           return dal.GetAllGroup();
       }
    }
}
