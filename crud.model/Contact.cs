using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.model
{
   public class Contact
    {
        //contactId, contactName, cellPhone, email, groupId
        private ContactGroup _group;

        public ContactGroup Group
        {
            get { return _group; }
            set { _group = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _cellPhone;

        public string CellPhone
        {
            get { return _cellPhone; }
            set { _cellPhone = value; }
        }
        private string _contactName;

        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }
        private int _contactId;

        public int ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }
    }
}
