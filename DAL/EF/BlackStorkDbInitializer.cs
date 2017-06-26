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
            context.Topics.Add(new Topic
            {
                Header = "NEWS 1",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 2",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 3",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 4",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 5",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 6",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 7",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 8",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 9",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 10",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 11",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "NEWS 12",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            //Products
            context.Products.Add(new Product
            {
                Name = "Шлейка x-back",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Шлейка h-back",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Нарты спортивные",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Сумка для снаряжения",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Дождевик",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Попона",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Тапочки",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Шлейка h-back",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Шлейка грузовая",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Нарты грузовые",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Сумка для формы",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Дождевик в стиле БАТЭ",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Бандана",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Тапочки флисовые",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/demo.jpg",
                PathForFolderWithPhotos = null
            });


            context.UserAccounts.Add(new UserAccount {Login = "admin", HashOfPassword = "123"});


            base.Seed(context);
        }
    }
}
