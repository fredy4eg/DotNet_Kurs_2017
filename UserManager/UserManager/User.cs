﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    public enum UserType
    {
        User,
        Moderator,
        Admin
    }

    public class User
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }

        public static User[] GetUsers()
        {
            return new User[]
            {
                new User() { Name = "Ivan", Phone="256884", Email ="1@mail", Type = UserType.Moderator},
                new User() { Name = "Bhamri", Phone="2755884", Email ="2@mail", Type = UserType.User},
                new User() { Name = "Vlad", Phone="174767", Email ="3@mail", Type = UserType.User},
                new User() { Name = "Nasty", Phone="4845874", Email ="4@mail", Type = UserType.Admin}
            };
        }

        public override string ToString()
        {
            return "I " + Name;
        }
    }
}
