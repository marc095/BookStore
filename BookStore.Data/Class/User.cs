using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Data
{
    public class User: IdentityUser
    {
     public string NickName { get; set; }
    }
}
