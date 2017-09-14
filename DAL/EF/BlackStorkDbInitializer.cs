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
                Header = "Мы запустили новый веб-сайт!",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = null,
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "В продаже появились шлейки в новом цвете! ",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/harness-red.jpg",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "Распродажа в честь открытия сайта",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/sale.png",
                PathForFolderWithPhotos = null
            });

            context.Topics.Add(new Topic
            {
                Header = "Виталий Тишник в снаряжении Black Stork прошел Беренгию! ",
                DateOfCreate = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a",
                PathForMainPhoto = "/Content/img/tishkin.jpg",
                PathForFolderWithPhotos = null
            });

            //Products
            context.Products.Add(new Product
            {
                Name = "Шлейка x-back",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/harness-blue.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Вилка",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/fork.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Потяг",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/pull.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Рюкзак",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/backpack.jpg",
                PathForFolderWithPhotos = null
            });

            context.Products.Add(new Product
            {
                Name = "Ошейник",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.",
                PathForMainPhoto = "/Content/img/collar.jpg",
                PathForFolderWithPhotos = null
            });


            context.UserAccounts.Add(new UserAccount {Login = "v-haiduk@yandex.ru", HashOfPassword = "123" });
            context.UserAccounts.Add(new UserAccount {Login = "v-haiduk@hotmail.com", HashOfPassword = "12345" });
            context.UserAccounts.Add(new UserAccount { Login = "test@test.com", HashOfPassword = "12345" });

            context.Subcribs.Add(new Subscribe { Email = "ivanov@mail.ru" });
            context.Subcribs.Add(new Subscribe { Email = "petrov@mail.ru" });
            context.Subcribs.Add(new Subscribe { Email = "sidorov@mail.ru" });


            base.Seed(context);
        }
    }
}
