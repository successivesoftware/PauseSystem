using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Login : BaseEntity
    {
        
        public string UserName { get; set; }
        public Nullable<System.DateTime> LoginDate { get; set; }
        public Nullable<System.DateTime> LogoutDate { get; set; }
        public Nullable<bool> LoggedOut { get; set; }
    }
}
