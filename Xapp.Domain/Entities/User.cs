﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xapp.Domain.Entities
{
    public class User
    {
        public int IdUser { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        
        public List<PTO> PTOs { get; set; }
        public List<Rol> Roles { get; set; }
        public List<Post> Posts { get; set; }
        public virtual Perfil PerfilUser { get; set; }
        public virtual Wallet WalletlUser { get; set; }


        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }

        public void CreateEntity()
        {
            CreationDate = DateTime.Now;
            EditEntity();
            IsActive = true;
            IsDeleted = false;
        }
        public void EditEntity()
        {
            LastUpdate = DateTime.Now;
        }

        public void ChangeStatus()
        {
            IsActive = !IsActive;
            EditEntity();
        }

        public void Delete()
        {
            IsActive = false;
            IsDeleted = true;
            EditEntity();
        }

    }
}
