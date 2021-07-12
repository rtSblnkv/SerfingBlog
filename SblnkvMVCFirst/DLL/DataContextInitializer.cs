using SblnkvMVCFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SblnkvMVCFirst.DLL
{
    public class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            if(!context.Users.Any())
            {
                var user = new User();
                user.Name = "System";
                user.NickName = "System";
                user.Password = "54kk32";
                user.About = "null";
                context.Users.Add(user);
                context.SaveChanges();
            }          
        }
    }
}
