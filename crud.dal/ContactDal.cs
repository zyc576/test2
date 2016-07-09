using crud.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.dal
{
  public  class ContactDal
    {
      //查询所有信息
      public List<Contact> GetAllMsg()
      {
          List<Contact> list = new List<Contact>();
          string sql = "select Contacts.*,ContactGroup.groupName from Contacts inner join ContactGroup on Contacts.groupId=ContactGroup.groupId;";
          using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text))
          {
              if(reader.HasRows)
              {
                  while(reader.Read())
                  {
                      Contact model = new Contact();
                      model.ContactId = reader.GetInt32(0);
                      model.ContactName = reader.GetString(1);
                      model.CellPhone = reader.GetString(2);
                      model.Email = reader.GetString(3);
                      model.Group = new ContactGroup() { GroupId = reader.GetInt32(4), GroupName = reader.GetString(5) };
                      list.Add(model);
                  }
              }
          }
          return list;
      }
      //根据Id删除数据
      public int Delete(int id)
      {
          string sql = "delete from Contacts where contactId=@id";
          SqlParameter ps = new SqlParameter("@id", id);
          return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
      }
      //根据Id查询信息
      public Contact SelectMsgById(int id)
      {
          Contact model = new Contact();
          string sql = "select * from Contacts where contactId=@id";
          SqlParameter ps = new SqlParameter("@id", id);
          using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text,ps))
          {
              if(reader.HasRows)
              {
                  while(reader.Read())
                  {
                     
                      model.ContactId = reader.GetInt32(0);
                      model.ContactName = reader.GetString(1);
                      model.CellPhone = reader.GetString(2);
                      model.Email = reader.GetString(3);
                      model.Group = new ContactGroup() { GroupId = reader.GetInt32(4) };
                  }
              }
          }
          return model;
      }
      //根据Id更新信息
      public int Update(Contact model)
      {
          //contactId, contactName, cellPhone, email, groupId
          string sql = "update Contacts set contactName=@name,cellPhone=@phone,email=@email,groupId=@group where contactId=@id ";
          SqlParameter[] ps ={
                                 new SqlParameter("@id",model.ContactId),
                                 new SqlParameter("@name",model.ContactName),
                                 new SqlParameter("@phone",model.CellPhone),
                                 new SqlParameter("@email",model.Email),
                                 new SqlParameter("@group",model.Group.GroupId)
                           };
          return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
      }
      //添加信息
      public int Insert(Contact model)
      {
          string sql = "insert into Contacts values(@name,@phone,@email,@group)";
          SqlParameter[] ps ={
                             new SqlParameter("@name",model.ContactName),
                             new SqlParameter("@phone",model.CellPhone),
                             new SqlParameter("@email",model.Email),
                             new SqlParameter("@group",model.Group.GroupId)
                           };
          return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
      }
      //分页查询
      public List<Contact> SelectMsgByPage(int pageSize,int pageIndex, out int recordCount,out int pageCount)
      {
          List<Contact> list = new List<Contact>();
          string sql = "dbo.LoadPage";
          SqlParameter[] ps ={
                                 new SqlParameter("@pageindex",SqlDbType.Int){Value=pageIndex},
                                 new SqlParameter("@pagesize",SqlDbType.Int){Value=pageSize},
                                 new SqlParameter("@recordcount",SqlDbType.Int){Direction= ParameterDirection.Output},
                                 new SqlParameter("@pagecount",SqlDbType.Int){Direction=ParameterDirection.Output}
                           };
          using(SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.StoredProcedure,ps))
          {
              if(reader.HasRows)
              {
                  while(reader.Read())
                  {
                      Contact model = new Contact();
                      model.ContactId = reader.GetInt32(0);
                      model.ContactName = reader.GetString(1);
                      model.CellPhone = reader.GetString(2);
                      model.Email = reader.GetString(3);
                      model.Group = new ContactGroup() { GroupId = reader.GetInt32(4), GroupName = reader.GetString(5) };
                      list.Add(model);
                  }
              }
          }
          recordCount = Convert.ToInt32(ps[2].Value);
          pageCount = Convert.ToInt32(ps[3].Value);
          return list;
      }
    }
}
