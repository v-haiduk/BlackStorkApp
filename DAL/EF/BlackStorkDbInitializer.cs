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
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });
            context.Topics.Add(new Topic { Header = "Lorem ipsum", DateOfCreate = DateTime.Now, Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. " });

            base.Seed(context);
        }
    }
}
