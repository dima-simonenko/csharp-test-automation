using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class PersonalInfo
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string photo;

        public PersonalInfo(string firstname, string middlename, string lastname, string nickname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
        }
        public PersonalInfo(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }
        public PersonalInfo(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
    }
}
