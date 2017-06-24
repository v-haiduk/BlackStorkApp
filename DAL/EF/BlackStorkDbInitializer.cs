using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class BlackStorkDbInitializer : DropCreateDatabaseAlways<BlackStorkContext>
    {
        protected override void Seed(BlackStorkContext context)
        {
            context.Topics.Add(new Topic { Header = "NEWS 1", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 2", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 3", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 4", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 5", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 6", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 7", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 8", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 9", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 10", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 11", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 12", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });

            context.Products.Add(new Product { Name = "Шлейка x-back", Description = "Ipsum dolor sit amet dolor sit amet dolor sit amet dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null});
            context.Products.Add(new Product { Name = "Шлейка h-back", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Нарты спортивные", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Сумка для снаряжения", Description = "Ipsum dolor sit amet dolor sit amet dolor sit amet dolor sit amet dolor sit amet ", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Дождевик", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Попона", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Тапочки", Description = "Ipsum dolor sit amet dolor sit amet dolor sit ametdolor sit ametdolor sit ametdolor sit ametdolor sit ametdolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Шлейка x-back", Description = "Ipsum dolor sit amet dolor sit amet dolor sit amet dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Шлейка h-back", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Нарты спортивные", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Сумка для снаряжения", Description = "Ipsum dolor sit amet dolor sit amet dolor sit amet dolor sit amet dolor sit amet ", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Дождевик", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "Попона", Description = "Ipsum dolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "ТапочкиZ", Description = "Ipsum dolor sit amet dolor sit amet dolor sit ametdolor sit ametdolor sit ametdolor sit ametdolor sit ametdolor sit amet", PathForMainPhoto = "/Content/img/demo.jpg", PathForFolderWithPhotos = null });

            context.UserAccounts.Add(new UserAccount {Login = "admin", HashOfPassword = "123456"});


            base.Seed(context);
        }
    }
}
