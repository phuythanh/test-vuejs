using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bd.vienkiemsoat.web.api.ViewModel
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public Guid? HuyenId { get; set; }
        public List<string> Roles { get;set;}
        public string Email { get; set; }
        public string TenHuyen { get; set; }
    }
}
