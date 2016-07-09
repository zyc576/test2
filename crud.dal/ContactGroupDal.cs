using crud.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.dal
{
   public class ContactGroupDal
    {
       //获得所有的分组信息
       public List<ContactGroup> GetAllGroup()
       {
           List<ContactGroup> list = new List<ContactGroup>();
           string sql = "select * from ContactGroup";
           using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,System.Data.CommandType.Text))
           {
               if(reader.HasRows)
               {
                   while(reader.Read())
                   {
                       ContactGroup model = new ContactGroup();
                       model.GroupId = reader.GetInt32(0);
                       model.GroupName = reader.GetString(1);
                       list.Add(model);
                   }
               }
           }
           return list;
       }
    }
}
