using crud.dal;
using crud.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.bll
{
  public  class ContactBll
    {
      ContactDal dal = new ContactDal();
      //查询所有信息
      public List<Contact> GetAllMsg()
      {
          return dal.GetAllMsg();
      }
       //根据Id删除数据
      public int Delete(int id)
      {
          return dal.Delete(id);
      }
            //根据Id查询信息
      public Contact SelectMsgById(int id)
      {
          return dal.SelectMsgById(id);
      }
       //根据Id更新信息
      public int Update(Contact model)
      {
          return dal.Update(model);
      }
      //添加信息
      public int Insert(Contact model)
      {
          return dal.Insert(model);
      }
         //分页查询
      public List<Contact> SelectMsgByPage(int pageSize,int pageIndex, out int recordCount,out int pageCount)
      {
          return dal.SelectMsgByPage(pageSize, pageIndex, out recordCount, out pageCount);
      }
    }
}
