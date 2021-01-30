using ClaimManager.Domain.Entities.Claims;
using ClaimManager.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (!context.Claims.Any())
            {
                return;   // DB has been seeded
            }
            var currencies = new Currency[]
            {
                new Currency { Name="Korean Won", Symbol="KRW" },
                new Currency { Name="Canadian Dollar", Symbol="CAD"},
                new Currency { Name="US Dollar", Symbol="USD"},
            };

            foreach (Currency c in currencies)
            {
                context.Currencies.Add(c);
            }
            context.SaveChanges();

            var categories = new ClaimCategory[]
            {
                new ClaimCategory { Code="AAA", Name="Type A"},
                new ClaimCategory { Code="BBB", Name="Type B"},
                new ClaimCategory { Code="CCC", Name="Type C"},
            };

            foreach (ClaimCategory c in categories)
            {
                context.ClaimCategories.Add(c);
            }
            context.SaveChanges();

            var items1 = new ClaimItem[]
            {
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[1].Id, Amount=10.99M, Date=new DateTime(2021-01-01),  Description="This is a test item", Image="https://static.nike.com/a/images/w_1536,c_limit/9de44154-c8c3-4f77-b47e-d992b7b96379/image.jpg", Payee= "MazcoMac" },
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[2].Id, Amount=110.99M, Date=new DateTime(2021-01-03), Description="This is another test item", Payee="Jason Huang", Image="https://media.glamour.com/photos/5d4d8173a8093800088d56f8/16:9/w_3440,h_1935,c_limit/Jackets%20Everyone%20Should%20Own%20River.jpg"},
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[0].Id, Amount=210.99M, Date=new DateTime(2021-01-05), Description="This is a still yet another test item", Image="https://images2.minutemediacdn.com/image/upload/c_crop,h_1126,w_2000,x_0,y_181/f_auto,q_auto,w_1100/v1554932288/shape/mentalfloss/12531-istock-637790866.jpg", Payee="Carson Xu"},
            };

            var items2 = new ClaimItem[]
            {
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[1].Id, Amount=12.99M, Date=new DateTime(2021-01-02),  Description="This is a test item", Image="https://static.toiimg.com/photo/msid-67586673/67586673.jpg?3918697", Payee= "MazcoMac" },
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[2].Id, Amount=50.99M, Date=new DateTime(2021-01-05),  Description="This is another test item", Payee="Jason Huang", Image="https://c.files.bbci.co.uk/EB24/production/_112669106_66030514-b1c2-4533-9230-272b8368e25f.jpg"},
                new ClaimItem { CurrencyId=currencies[2].Id, CategoryId=categories[0].Id, Amount=310.99M, Date=new DateTime(2021-01-07),  Description="This is a still yet another test item", Image="https://cdn.mos.cms.futurecdn.net/CxLvbQNp2Y4BQkTkpW5m7b.jpg", Payee="Carson Xu"},
            };

            foreach (ClaimItem i in items1)
            {
                context.ClaimItems.Add(i);
            }

            foreach (ClaimItem i in items2)
            {
                context.ClaimItems.Add(i);
            }
            //context.SaveChanges();

            var claims = new Claim[]
            {
                new Claim { ClaimItems=items1, Title="test claim title 1", RequesterId="", ApproverId="", SubmitDate= new DateTime(2021-01-24), RequesterComments="Test Comment 1", },
                new Claim { ClaimItems=items2, Title="test claim title 2", RequesterId="", ApproverId="", SubmitDate= new DateTime(2021-01-20), RequesterComments="Test Comment 2"}
            };

            foreach (Claim c in claims)
            {
                context.Claims.Add(c);
            }
            context.SaveChanges();

        }
    }

}
