using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        //CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
