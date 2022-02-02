using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsController.Models
{
    public class Student
    {
        private string date, email;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public string DateOfBirth { 
            get {return date; } 
            set {
                Regex regex = new Regex(@"^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$");
                Match match = regex.Match(value);
                if (!match.Success) throw new ArgumentException("date format is not valid");
                date = value;
            } 
        }
        public string Study { get; set; }
        public string Mode { get; set; }
        public string Email {
            get { return email; }
            set
            {
                Regex regex = new Regex(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)");
                Match match = regex.Match(value);
                if (!match.Success) throw new ArgumentException("email is not valid");
                email = value;
            }
        }
        public string MotherName { get; set; }
        public string FatherName { get; set; }

        public string ToCsvFormat()
        {
            string separator = ",";
            string result = FirstName + separator +
                LastName + separator +
                IndexNumber + separator +
                DateOfBirth + separator +
                Study + separator +
                Mode + separator +
                Email + separator +
                FatherName + separator +
                MotherName;
            return result;
        }

        public void Modify(Student sUpdate)
        {
            this.FirstName = Empty(sUpdate.FirstName) ? FirstName : sUpdate.FirstName;
            this.LastName = Empty(sUpdate.LastName) ? LastName : sUpdate.LastName;
            this.DateOfBirth = Empty(sUpdate.DateOfBirth) ? DateOfBirth : sUpdate.DateOfBirth;
            this.Study = Empty(sUpdate.Study) ? Study : sUpdate.Study;
            this.Mode = Empty(sUpdate.Mode) ? Mode : sUpdate.Mode;
            this.Email = Empty(sUpdate.Email) ? Email : sUpdate.Email;
            this.FatherName = Empty(sUpdate.FatherName) ? FatherName : sUpdate.FatherName;
            this.MotherName = Empty(sUpdate.MotherName) ? MotherName : sUpdate.MotherName;
        }

        public bool DataIsFulfilled()
        {
            if (Empty(FirstName)) return false;
            if (Empty(LastName)) return false;
            if (Empty(DateOfBirth)) return false;
            if (Empty(Study)) return false;
            if (Empty(Mode)) return false;
            if (Empty(Email)) return false;
            if (Empty(FatherName)) return false;
            if (Empty(MotherName)) return false;
            return true;
        }

        private static bool Empty(string String)
        {
            return string.IsNullOrEmpty(String);
        }

    }
}
