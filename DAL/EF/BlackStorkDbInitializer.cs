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
            context.Topics.Add(new Topic { Header = "NEWS 1", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 2", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 3", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 4", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 5", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Topics.Add(new Topic { Header = "NEWS 6", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });

            context.Products.Add(new Product { Name = "OBJECT 1", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null});
            context.Products.Add(new Product { Name = "OBJECT 2", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "OBJECT 3", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "OBJECT 4", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "OBJECT 5", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "OBJECT 6", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });
            context.Products.Add(new Product { Name = "OBJECT 7", Description = "Ipsum dolor sit amet", PathForMainPhoto = null, PathForFolderWithPhotos = null });



            base.Seed(context);
        }
    }
}
