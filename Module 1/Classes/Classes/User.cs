using System;
using System.Collections.Generic;

namespace Classes
{
    public class User
    { 
        public const int CurrentYear = 2021;
        
        //Read-only property
        public string Level { get; }

        //Set-only property
        private string _email;
        public string Email
        {
            set => UpdateEmail(value);
        }

        public void UpdateEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new ArgumentException("The email is not valid!");
            }

            _email = email;
        }
        
        //Property with backed field
        private int _startYear;
        public int StartYear
        {
            get => _startYear;
            set => _startYear = value;
        }
        
        //Auto-implemented property
        public int PhNo { get; private set; }

        //Calculated property
        public int Experience
        {
            get => DateTime.Now.Year - _startYear;
            set => _startYear = DateTime.Now.Year - value;
        }
        public static readonly List<User> ListOfUsers = new List<User>();
        public static readonly int quantity = 1;

        public User()
        {
            //ListOfUsers = new List<User>(); compile time error because readonly
            //CurrentYear = DateTime.Now.Year;  compile time error because const
        }

        protected virtual string Action()
        {
            return "I am a user.";
        }
    }
}