using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactDetails
    {
        private PersonalInfo personal;
        private JobInfo job;
        private ContactInfo contact;
        private WebInfo web;
        private BirthdayInfo birthday;
        private AnniversaryInfo anniversary;

        public ContactDetails(PersonalInfo personal, JobInfo job, ContactInfo contact, WebInfo web, BirthdayInfo birthday, AnniversaryInfo anniversary)
        {
            this.personal = personal;
            this.job = job;
            this.contact = contact;
            this.web = web;
            this.birthday = birthday;
            this.anniversary = anniversary;
        }

        public ContactDetails(PersonalInfo personal, ContactInfo contact)
        {
            this.personal = personal;
            this.contact = contact;
        }

        public PersonalInfo Personal
        {
            get
            {
                return personal;
            }
            set
            {
                personal = value;
            }
        }
        public JobInfo Job
        {
            get
            {
                return job;
            }
            set
            {
                job = value;
            }
        }

        public ContactInfo Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        public WebInfo Web
        {
            get
            {
                return web;
            }
            set
            {
                web = value;
            }
        }

        public BirthdayInfo Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public AnniversaryInfo Anniversary
        {
            get
            {
                return anniversary;
            }
            set
            {
                anniversary = value;
            }
        }

    }
}
