using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactDetails : IEquatable<ContactDetails>, IComparable<ContactDetails>
    {
        public ContactDetails(PersonalInfo personal, JobInfo job, ContactInfo contact, WebInfo web, BirthdayInfo birthday, AnniversaryInfo anniversary)
        {
            Personal = personal;
            Job = job;
            Contact = contact;
            Web = web;
            Birthday = birthday;
            Anniversary = anniversary;
        }

        public bool Equals(ContactDetails other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Personal.Firstname == other.Personal.Firstname
                && Personal.Lastname == other.Personal.Lastname;
        }
        public override int GetHashCode()
        {
            return (Personal.Firstname + Personal.Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return $"Firstname = {Personal.Firstname}, Lastname = {Personal.Lastname}";
        }

        public int CompareTo(ContactDetails other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Personal.Lastname + Personal.Firstname)
                .CompareTo(other.Personal.Lastname + other.Personal.Firstname);
        }

        public ContactDetails(PersonalInfo personal, ContactInfo contact)
        {
            Personal = personal;
            Contact = contact;
        }

        public PersonalInfo Personal { get; set; }

        public JobInfo Job { get; set; }
        public ContactInfo Contact { get; set; }

        public WebInfo Web { get; set; }

        public BirthdayInfo Birthday { get; set; }

        public AnniversaryInfo Anniversary { get; set; }

        public string Id { get; set; }
    }
}
