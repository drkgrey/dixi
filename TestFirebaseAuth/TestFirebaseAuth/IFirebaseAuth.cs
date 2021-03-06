﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestFirebaseAuth
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<Boolean> IsCurrent();
        void LogOut();

    }
}
