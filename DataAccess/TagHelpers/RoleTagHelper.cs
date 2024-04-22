using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class RoleTagHelper : TagHelper
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IUserRepository _userRepo;

        public RoleTagHelper(IRoleRepository roleRepo, IUserRepository userRepo)
        {
            _roleRepo = roleRepo;
            _userRepo = userRepo;
        }

        [HtmlAttributeName("user-role")]
        public string RoleId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> userNames = new List<string>();

            var role = await _roleRepo.FindRole(RoleId);
            if (role != null) 
            {
                var users = await _userRepo.GetUsers();
                foreach ( var user in users )
                {
                    if (await _userRepo.IsUserInRole(user, role.Name))
                    {
                        userNames.Add(user.UserName);
                    }
                }
            }

            output.Content.SetContent
                (
                    userNames.Count == 0 ? "Bu rolde hiçbir kullanıcı yok!" :
                    userNames.Count > 3 ?
                    (string.Join(", ", userNames.Take(3)) + " ...") :
                    string.Join(", ", userNames)
                );
        }
    }
}
