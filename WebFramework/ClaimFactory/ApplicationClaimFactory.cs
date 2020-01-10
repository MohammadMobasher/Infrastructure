﻿using DataLayer.DTO.UserRoleDTO;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Repos.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace WebFramework.ClaimFactory
{
    public class ApplicationClaimFactory : UserClaimsPrincipalFactory<Users, Roles>
    {

        private readonly UsersRoleRepository _usersRoleRepository;

        public ApplicationClaimFactory(UserManager<Users> userManager, 
            RoleManager<Roles> roleManager, 
            IOptions<IdentityOptions> options,
            UsersRoleRepository usersRoleRepository) : base(userManager, roleManager, options)
        {
            _usersRoleRepository = usersRoleRepository;
        }

        

        public override async Task<ClaimsPrincipal> CreateAsync(Users user)
        {
            var principal = await base.CreateAsync(user);
            
            List<UserRoleDetailDTO> Roles = await _usersRoleRepository.GetRolesByUserIdAsync(user.Id);

            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                 new Claim("FirstName", user.FirstName ?? ""),
                 new Claim("UserId", user.Id + ""),
                 new Claim("LastName",  user.LastName ?? ""),
                 new Claim("FullName",  user.FirstName + " " + user.LastName),
                 new Claim("UserProfile" , user.ProfilePic ?? "/Uploads/UserImage/NoPhoto.jpg"),

                 new Claim("selectedRoleId", Roles != null ? Roles.First().RoleId + "" : "-1"),
                 new Claim("UserHasRoles", JsonConvert.SerializeObject(Roles, Formatting.Indented))


            });

            return principal;
        }

    }
}
