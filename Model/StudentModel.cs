using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentModel
    {
        private int identity;
        private string fullName;
        private DateTime birthDate;

        public StudentModel()
        {
            identity = 0;
            fullName = "";
        }
        public int Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string BirthDate
        {
            get { return birthDate.ToShortDateString(); }
            set { DateTime.TryParse(value, out birthDate); }
        }
    }
}
