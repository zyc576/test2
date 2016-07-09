using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.model
{
   public class ContactGroup
    {
        private int _groupId;

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
    }
}
