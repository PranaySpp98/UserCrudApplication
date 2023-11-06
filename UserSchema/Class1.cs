using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSchema
{
    public class Class1
    {
        private string _Name;
        private string _Designation;
        private string _Skills;
        private DateTime? _DOB;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }
        public string Skills
        {
            get
            {
                return _Skills;
            }
            set
            {
                _Skills = value;
            }
        }
        public DateTime? DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }
    }
}
