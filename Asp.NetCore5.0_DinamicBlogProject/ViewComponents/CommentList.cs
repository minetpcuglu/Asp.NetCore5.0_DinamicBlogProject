using Asp.NetCore5._0_DinamicBlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    UserName="Mine"
                    
                },
                 new UserComment
                {
                    Id=2,
                    UserName="Elif"

                },
            };
            return View(commentValues);
        }
    }
}
