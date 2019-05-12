using System;
using System.Collections.Generic;
using System.Text;

namespace StYouDent.Models
{
    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string created { get; set; }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;
        public string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _fullName;
        public string fullName
        {
            get { return _name + " " + _surname; }
            set { _fullName = value; }
        }
    }
}
