using Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        public IActionResult ExportStaticExelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var blogcount in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = blogcount.BlogId;
                    worksheet.Cell(BlogRowCount, 2).Value = blogcount.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }

        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>
            {
                new BlogModel{BlogId=1 , BlogName = "C# Programlamaya Giriş"},
                new BlogModel{BlogId=2 , BlogName = "2022 Olimpiyatları"},
                new BlogModel{BlogId=3 , BlogName = "Tesla Firma Araçları"}

            };
            return blogModel;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDinamicExelBlogList()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var blogcount in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = blogcount.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = blogcount.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }


        }

        public List<DinamicBlogModel> BlogTitleList()
        {
            List<DinamicBlogModel> blogModels = new List<DinamicBlogModel>();
            using (var context = new Context())
            {
                blogModels = context.Blogs.Select(x => new DinamicBlogModel
                {
                    ID=x.BlogId,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return blogModels;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
