using System;
using System.Collections.Generic;
using System.Text;

namespace StYouDent.Models
{
    public class User
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string created_date { get; set; }
        public string school { get; set; }
        public string index { get; set; }
    }
}
