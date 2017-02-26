using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    class BlackStorkDbInitializer : DropCreateDatabaseIfModelChanges<BlackStorkContext>
    {
        protected override void Seed(BlackStorkContext context)
        {
            //add other info
            context.Colours.Add(new Colour { Name = "синий & черный", PathForImage = null });
            context.Colours.Add(new Colour { Name = "красный & черный", PathForImage = null });
            context.Colours.Add(new Colour { Name = "желтый & черный", PathForImage = null });
            context.Colours.Add(new Colour { Name = "бирюзовый & черный", PathForImage = null });

            context.Roles.Add(new Role { Name = "Admin" });
            context.Roles.Add(new Role { Name = "Guest" });

            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
        }
    }
}
