using AutoMapper.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using To_Do_Lists.Data.Entities;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace To_Do_Lists.Data
{
    public class ListDbContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public DbSet<Item>ItemsTable { get; set; }
        public DbSet<ListOfItems>ListOfItemsTable { get; set; }

        public ListDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            //bldr.Entity<ListOfItems>().HasOne<ListOfLists>().WithMany().HasForeignKey(x => x.ListOfItemsId);
            //bldr.Entity<Item>().HasOne<ListOfItems>().WithMany().HasForeignKey(x => x.ItemId);

            /*
            bldr.Entity<ListOfLists>()
            .HasData(new
            {
                Id = 1
            });
            
            
            bldr.Entity<ListOfItems>()
                .HasData(new
                    {
                        ListOfItemsID = 1,
                        ListTitle = "gym",
                        mainListid = 1
                    }
                    , new
                    {
                        ListOfItemsID = 2,
                        ListTitle = "internship",
                        mainListid = 1,
                    }, new
                    {
                        ListOfItemsID = 3,
                        ListTitle = "Typical day",
                        mainListid = 1
                    });
            
            bldr.Entity<Item>()
                .HasData(new
                    {
                        ItemID = 1,
                        text = "add",
                        ListOfItemsID = 1
                    }, new
                    {
                        ItemID = 2,
                        text = "add",
                        ListOfItemsID = 1
                    }, new
                    {
                        ItemID = 3,
                        text = "add",
                        ListOfItemsID = 1
                    }
                    , new
                    {
                        ItemID = 4,
                        text = "learn",
                        ListOfItemsID = 2
                    }, new
                    {
                        ItemID = 5,
                        text = "work",
                        ListOfItemsID = 2
                    }, new
                    {
                        ItemID = 6,
                        text = "Wake up",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 7,
                        text = "Pray",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 8,
                        text = "Get ready",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 9,
                        text = "Go to the bus station",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 10,
                        text = "Ride a bus",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 11,
                        text = "Read a book on the rode",
                        ListOfItemsID = 3
                    }, new
                    {
                        ItemID = 12,
                        text = "Arrive to Terkwaz",
                        ListOfItemsID = 3
                    }
                );
                */
        }
    }
}