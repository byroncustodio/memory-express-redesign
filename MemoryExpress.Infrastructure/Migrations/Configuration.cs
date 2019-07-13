namespace MemoryExpress.Infrastructure.Migrations
{
    using MemoryExpress.Core.Domain.Catalog;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MemoryExpress.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // seed AspNetRoles
            var roles = new List<string> { "Admin", "User" };

            roles.ForEach(s => context.Roles.AddOrUpdate(r => r.Name, new IdentityRole(s)));
            context.SaveChanges();

            // seed default User in AspNetUsers
            if (!context.Users.Any(u => u.Email == "user@memxpress.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser
                {
                    FirstName = "User",
                    LastName = "Account",
                    Email = "user@memxpress.com",
                    UserName = "user@memxpress.com",
                    PhoneNumber = null,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = userManager.PasswordHasher.HashPassword("user"),
                    LockoutEnabled = false,
                };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "User");

                context.SaveChanges();
            }

            // seed default Admin in AspNetUsers
            if (!context.Users.Any(u => u.Email == "admin@memxpress.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var admin = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Account",
                    Email = "admin@memxpress.com",
                    UserName = "admin@memxpress.com",
                    PhoneNumber = null,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = userManager.PasswordHasher.HashPassword("admin"),
                    LockoutEnabled = false,
                };
                userManager.Create(admin);
                userManager.AddToRole(admin.Id, "Admin");

                context.SaveChanges();
            }

            // seed Category
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Computer Hardware", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 2, Name = "Computer Systems", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 3, Name = "Software & Gaming", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 4, Name = "Networking", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 5, Name = "TVs & Home Theater", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 6, Name = "Cameras & Camcorders", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 7, Name = "Accessories", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 8, Name = "Cables & Adapters", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 9, Name = "Telephones", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 10, Name = "Toys & Gadgets", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 11, Name = "Home & Office", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 12, Name = "Food & Drinks", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 13, Name = "Gift Cards", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 14, Name = "Computer Parts", ParentCategoryId = 1, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 15, Name = "Adapter Cards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 16, Name = "Optical Disc Drives", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 17, Name = "Computer Cases", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 18, Name = "Controller Cards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 19, Name = "Cooling", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 20, Name = "Floppy Drives", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 21, Name = "SSD & Hard Drives", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 22, Name = "Memory", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 23, Name = "Modems", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 24, Name = "Motherboards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 25, Name = "Network Adapters", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 26, Name = "Power Supplies", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 27, Name = "Processors", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 28, Name = "Sound Cards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 29, Name = "Video Capture Cards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 30, Name = "Video Cards", ParentCategoryId = 14, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 31, Name = "Computer Peripherals", ParentCategoryId = 1, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 32, Name = "3D Glasses", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 33, Name = "Barcode Scanners", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 34, Name = "Card Readers", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 35, Name = "Speakers", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 36, Name = "External Enclosures", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 37, Name = "Gaming Devices", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 38, Name = "Headsets & Microphones", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 39, Name = "Keyboards", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 40, Name = "KVM Switches", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 41, Name = "Mice", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 42, Name = "Printers", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 43, Name = "Remote Controls", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 44, Name = "Scanners", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 45, Name = "Pen Tablets", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 46, Name = "UPS (Battery Backups)", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 47, Name = "USB & Firewire Hubs", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 48, Name = "Web Cams", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 49, Name = "Bluetooth Adapters", ParentCategoryId = 31, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 50, Name = "Display Devices", ParentCategoryId = 1, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 51, Name = "LCD Monitors", ParentCategoryId = 50, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 52, Name = "Projectors", ParentCategoryId = 50, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 53, Name = "VR Headsets & HMDs", ParentCategoryId = 50, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 54, Name = "Storage Media", ParentCategoryId = 1, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 55, Name = "Blu-Ray Media", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 56, Name = "CD Media", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 57, Name = "DVD Media", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 58, Name = "Memory Cards", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 59, Name = "Tape Media", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 60, Name = "USB Drives", ParentCategoryId = 54, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 61, Name = "Desktop Computers", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 62, Name = "Business Computers", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 63, Name = "Gaming Computers", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 64, Name = "Home Computers", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 65, Name = "Mini Computers", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 66, Name = "All-In-One Computers", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 67, Name = "Refurbished", ParentCategoryId = 61, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 68, Name = "Laptop Computers", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 69, Name = "Business Laptops", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 70, Name = "Gaming Laptops", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 71, Name = "Home Laptops", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 72, Name = "Netbooks", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 73, Name = "Refurbished", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 74, Name = "Ultrabooks", ParentCategoryId = 68, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 75, Name = "Tablets & Mobile Devices", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 76, Name = "Mobile Phones", ParentCategoryId = 75, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 77, Name = "Tablets", ParentCategoryId = 75, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 78, Name = "Server Systems", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 79, Name = "Barebone Servers", ParentCategoryId = 78, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 80, Name = "Rackmount Servers", ParentCategoryId = 78, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 81, Name = "Tower Servers", ParentCategoryId = 78, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 82, Name = "Home Servers", ParentCategoryId = 78, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 83, Name = "Single Board Computers", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 84, Name = "Custom System Configurator", ParentCategoryId = 2, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 85, Name = "Software", ParentCategoryId = 3, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 86, Name = "Computer Games", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 87, Name = "Operating Systems", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 88, Name = "Anti-Virus & Security", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 89, Name = "Office & Productivity", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 90, Name = "Graphics Software", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 91, Name = "Tools & Utilities", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 92, Name = "Media Playback & Decoders", ParentCategoryId = 85, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 93, Name = "Gaming", ParentCategoryId = 3, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 94, Name = "Computer Games", ParentCategoryId = 93, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 95, Name = "Gaming Devices", ParentCategoryId = 93, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 96, Name = "Xbox", ParentCategoryId = 93, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 97, Name = "Playstation", ParentCategoryId = 93, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 98, Name = "Wired Networking", ParentCategoryId = 4, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 99, Name = "Network Adapters", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 100, Name = "Switches", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 101, Name = "Routers", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 102, Name = "Security / Firewall / VPN", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 103, Name = "PoE (Power over Ethernet)", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 104, Name = "Power Line Networking", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 105, Name = "Network Attached Storage (NAS)", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 106, Name = "Cable / DSL Modems", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 107, Name = "Print Servers", ParentCategoryId = 98, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 108, Name = "Televisions", ParentCategoryId = 5, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 109, Name = "LED Backlit TVs", ParentCategoryId = 108, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 110, Name = "OLED TVs", ParentCategoryId = 108, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 111, Name = "Audio", ParentCategoryId = 5, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 112, Name = "Audio / Hi-Fi Systems", ParentCategoryId = 111, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 113, Name = "Home Theatre Speakers", ParentCategoryId = 111, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 114, Name = "Home Theatre Systems", ParentCategoryId = 111, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 115, Name = "Receivers", ParentCategoryId = 111, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 116, Name = "Digital Cameras", ParentCategoryId = 6, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 117, Name = "Point & Shoot Digital Cameras", ParentCategoryId = 116, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 118, Name = "Digital SLR Cameras", ParentCategoryId = 116, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 119, Name = "Mirrorless System Cameras", ParentCategoryId = 116, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 120, Name = "Camera Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 121, Name = "Case Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 122, Name = "Computer Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 123, Name = "Notebook Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 124, Name = "Projector Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 125, Name = "TV & Video Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 126, Name = "Mobile Phone Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 127, Name = "Tablet Accessories", ParentCategoryId = 7, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 128, Name = "Audio Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 129, Name = "Cable Management", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 130, Name = "Computer Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 131, Name = "Home Theater Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 132, Name = "Monitor Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 133, Name = "Network Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 134, Name = "Printer Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 135, Name = "Projector Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 136, Name = "Video Cables", ParentCategoryId = 8, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 137, Name = "Mobile Phones", ParentCategoryId = 9, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 138, Name = "VOIP Phones", ParentCategoryId = 9, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 139, Name = "Wearables & Watches", ParentCategoryId = 10, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 140, Name = "Calculators", ParentCategoryId = 10, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 141, Name = "USB Devices", ParentCategoryId = 10, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 142, Name = "Toys & Collectibles", ParentCategoryId = 10, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 143, Name = "DIY / Maker Products", ParentCategoryId = 10, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 144, Name = "Small Appliances", ParentCategoryId = 11, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 145, Name = "Office Furniture & Chairs", ParentCategoryId = 11, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 146, Name = "Kitchen Utensils & Gadgets", ParentCategoryId = 11, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 147, Name = "Energy Drinks", ParentCategoryId = 12, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 148, Name = "Candy & Mints", ParentCategoryId = 12, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Category { Id = 149, Name = "All Gift Cards", ParentCategoryId = 13, Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.Id, s));
            context.SaveChanges();

            // seed Deal
            var deals = new List<Deal>
            {
                new Deal { Id = 1, Name = "Featured Deals", DealType = DealTypes.Single, Published = true, StartDealDate = DateTime.Now, EndDealDate = DateTime.Now.AddDays(7) },
                new Deal { Id = 2, Name = "Laptops & PC Deals", DealType = DealTypes.Single, Published = true, StartDealDate = DateTime.Now, EndDealDate = DateTime.Now.AddDays(7) },
                new Deal { Id = 3, Name = "Component Deals", DealType = DealTypes.Single, Published = true, StartDealDate = DateTime.Now, EndDealDate = DateTime.Now.AddDays(7) },
            };

            deals.ForEach(s => context.Deals.AddOrUpdate(d => d.Id, s));
            context.SaveChanges();

            // seed Image
            var images = new List<Image>
            {
                new Image { Id = 1, FileName = "/Content/Images/Products/Default/BDL_MM00001330-0.jpg" },
                new Image { Id = 2, FileName = "/Content/Images/Products/Default/BDL_MM00001380-0.jpg" },
                new Image { Id = 3, FileName = "/Content/Images/Products/Default/BDL_MM00001391-0.jpg" },
                new Image { Id = 4, FileName = "/Content/Images/Products/Default/MX59124-0.jpg" },
                new Image { Id = 5, FileName = "/Content/Images/Products/Default/MX61626-0.jpg" },
                new Image { Id = 6, FileName = "/Content/Images/Products/Default/MX63475-0.jpg" },
                new Image { Id = 7, FileName = "/Content/Images/Products/Default/MX63475-0.jpg" },
                new Image { Id = 8, FileName = "/Content/Images/Products/Default/MX75587-0.jpg" },
                new Image { Id = 9, FileName = "/Content/Images/Products/Default/MX75686-0.jpg" },
                new Image { Id = 10, FileName = "/Content/Images/Products/Default/MX72510-0.jpg" },
                new Image { Id = 11, FileName = "/Content/Images/Products/Default/MX71352-0.jpg" },
                new Image { Id = 12, FileName = "/Content/Images/Products/Default/MX68022-0.jpg" },
                new Image { Id = 13, FileName = "/Content/Images/Products/Default/MX76730-0.jpg" },
                new Image { Id = 14, FileName = "/Content/Images/Products/Default/MX76395-0.jpg" },
                new Image { Id = 15, FileName = "/Content/Images/Products/Default/MX76460-0.jpg" },
                new Image { Id = 16, FileName = "/Content/Images/Products/Default/MX72839-0.jpg" },
                new Image { Id = 17, FileName = "/Content/Images/Products/Medium/MX72510-0.jpg" },
                new Image { Id = 18, FileName = "/Content/Images/Products/Medium/MX72510-1.jpg" },
                new Image { Id = 19, FileName = "/Content/Images/Products/Medium/MX72510-2.jpg" },
            };

            images.ForEach(s => context.Images.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            // seed Manufacturer
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "G.SKILL", LogoImage = "/Content/Images/Manufacturers/gskill.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 2, Name = "ME PC", LogoImage = "/Content/Images/Manufacturers/mepc.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 3, Name = "Lenovo", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 4, Name = "Intel", LogoImage = "/Content/Images/Manufacturers/intel.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 5, Name = "Gigabyte", LogoImage = "/Content/Images/Manufacturers/gigabyte.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 6, Name = "ASUS", LogoImage = "/Content/Images/Manufacturers/asus.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 7, Name = "Mee Audio", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 8, Name = "Samsung", LogoImage = "/Content/Images/Manufacturers/samsung.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 9, Name = "LG", LogoImage = "/Content/Images/Manufacturers/lg.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Manufacturer { Id = 10, Name = "Acer", LogoImage = "/Content/Images/Manufacturers/acer.png", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
            };

            manufacturers.ForEach(s => context.Manufacturers.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            // seed Specification
            var specifications = new List<Specification>
            {
                new Specification { Id = 1, Name = "Make and Model", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 2, Name = "Part Number", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 3, Name = "Color", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 4, Name = "Capacity", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 5, Name = "Memory Type", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 6, Name = "Operating System", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 7, Name = "Processor", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 8, Name = "Chipset", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 9, Name = "Graphics", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 10, Name = "Memory", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 11, Name = "Storage", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 12, Name = "Audio", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 13, Name = "Ethernet", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 14, Name = "I/O Ports", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 15, Name = "Keyboard", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 16, Name = "Mouse", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 17, Name = "Enterprise Security", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 18, Name = "Compliance", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 19, Name = "Power Supply", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 20, Name = "Dimensions", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Specification { Id = 21, Name = "Weight", Published = true, DateAdded = DateTime.Now, DateModified = DateTime.Now },
            };

            specifications.ForEach(s => context.Specifications.AddOrUpdate(sp => sp.Id, s));
            context.SaveChanges();

            // seed Product
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    SKU = "MX75587",
                    ILC = "848354032724",
                    PartNumber = "F4-3600C18D-16GTRG",
                    Name = "Trident Z Royal Gold DDR4-3600 C18 RAM Kit (2x 8GB)",
                    Description = "",
                    Price = 199.99m,
                    StockQuantity = 100,
                    MaxCartQuantity = 2,
                    SeoUrl = "MX75587",
                    Published = true,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    SKU = "MX72510",
                    ILC = "192330243384",
                    PartNumber = "10UR001LUS",
                    Name = "M710e SFF Business PC w/ Core&trade; i5-7400, 8GB, 256GB M.2 PCIe SSD, TPM 2.0, Windows 10 Pro, USB Keyboard & Mouse",
                    Description = "",
                    Price = 849.99m,
                    StockQuantity = 100,
                    MaxCartQuantity = 2,
                    SeoUrl = "MX72510",
                    Published = true,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now,
                },
                new Product
                {
                    Id = 3,
                    SKU = "MX72839",
                    ILC = "191114735800",
                    PartNumber = "NH.GXBAA.006",
                    Name = "Aspire 7 A715-72G-55EP w/ Core&trade; i5-8300H, 8GB, 128GB SSD + 1TB HDD, 15.6in FHD, GTX 1050, Windows 10",
                    Description = "",
                    Price = 1099.99m,
                    StockQuantity = 100,
                    MaxCartQuantity = 2,
                    SeoUrl = "MX72839",
                    Published = true,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now,
                },
            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            // seed ProductCategory
            var productCategories = new List<ProductCategoryMapping>
            {
                new ProductCategoryMapping { ProductId = 1, CategoryId = 22 },
                new ProductCategoryMapping { ProductId = 2, CategoryId = 61 },
                new ProductCategoryMapping { ProductId = 3, CategoryId = 71 },
            };

            foreach (ProductCategoryMapping pc in productCategories)
            {
                var productCategoryInDatabase = context.ProductCategoryMappings.Where(
                    s =>
                        s.Product.Id == pc.ProductId &&
                        s.Category.Id == pc.CategoryId
                ).SingleOrDefault();

                if (productCategoryInDatabase == null)
                {
                    context.ProductCategoryMappings.Add(pc);
                }
            }
            context.SaveChanges();

            // seed ProductDeal
            var productDeals = new List<ProductDealMapping>
            {
                new ProductDealMapping { ProductId = 1, DealId = 1, Price = 189.99m },
                new ProductDealMapping { ProductId = 2, DealId = 2, Price = 739.99m },
                new ProductDealMapping { ProductId = 3, DealId = 2, Price = 999.99m },
            };

            foreach (ProductDealMapping pd in productDeals)
            {
                var productDealInDatabase = context.ProductDealMappings.Where(
                    s =>
                        s.Product.Id == pd.ProductId &&
                        s.Deal.Id == pd.DealId
                ).SingleOrDefault();

                if (productDealInDatabase == null)
                {
                    context.ProductDealMappings.Add(pd);
                }
            }
            context.SaveChanges();

            // seed ProductImage
            var productImages = new List<ProductImageMapping>
            {
                new ProductImageMapping { ProductId = 1, ImageId = 8, SortOrder = 0 },
                new ProductImageMapping { ProductId = 2, ImageId = 10, SortOrder = 0 },
                new ProductImageMapping { ProductId = 3, ImageId = 16, SortOrder = 0 },
                new ProductImageMapping { ProductId = 2, ImageId = 17, SortOrder = 0 },
                new ProductImageMapping { ProductId = 2, ImageId = 18, SortOrder = 1 },
                new ProductImageMapping { ProductId = 2, ImageId = 19, SortOrder = 2 },
            };

            foreach (ProductImageMapping pi in productImages)
            {
                var productImageInDatabase = context.ProductImageMappings.Where(
                    s =>
                        s.Product.Id == pi.ProductId &&
                        s.Image.Id == pi.ImageId
                ).SingleOrDefault();

                if (productImageInDatabase == null)
                {
                    context.ProductImageMappings.Add(pi);
                }
            }
            context.SaveChanges();

            // seed ProductManufacturer
            var productManufacturers = new List<ProductManufacturerMapping>
            {
                new ProductManufacturerMapping { ProductId = 1, ManufacturerId = 1 },
                new ProductManufacturerMapping { ProductId = 2, ManufacturerId = 3 },
                new ProductManufacturerMapping { ProductId = 3, ManufacturerId = 10 },
            };

            foreach (ProductManufacturerMapping pm in productManufacturers)
            {
                var productManufacturerInDatabase = context.ProductManufacturerMappings.Where(
                    s =>
                        s.Product.Id == pm.ProductId &&
                        s.Manufacturer.Id == pm.ManufacturerId
                ).SingleOrDefault();

                if (productManufacturerInDatabase == null)
                {
                    context.ProductManufacturerMappings.Add(pm);
                }
            }
            context.SaveChanges();

            // seed ProductSpecification
            var productSpecifications = new List<ProductSpecificationMapping>
            {
                new ProductSpecificationMapping { ProductId = 1, SpecificationId = 1, SortOrder = 0, Value = "G.SKILL Trident Z Royal Gold DDR4-3600 16GB RAM Kit" },
                new ProductSpecificationMapping { ProductId = 1, SpecificationId = 2, SortOrder = 1, Value = "F4-3600C18D-16GTRG" },
                new ProductSpecificationMapping { ProductId = 1, SpecificationId = 3, SortOrder = 2, Value = "Royal Gold" },
                new ProductSpecificationMapping { ProductId = 1, SpecificationId = 4, SortOrder = 3, Value = "16GB RAM Kit (2x 8GB)" },
                new ProductSpecificationMapping { ProductId = 1, SpecificationId = 5, SortOrder = 4, Value = "PC4-28800 DDR4-3600 RAM Sticks, Unbuffered, non-ECC, non-Registered RAM" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 1, SortOrder = 0, Value = "Lenovo ThinkCentre M710e SFF Enterprise PC" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 2, SortOrder = 1, Value = "10UR001LUS" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 6, SortOrder = 2, Value = "Windows&reg; 10 Professional 64bit" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 7, SortOrder = 3, Value = "Intel&reg; Core&trade; i5-7400 3.0GHz Quad Core Processor w/ 3.5GHz Turbo, 4 Threads, 6MB Smart Cache, 14nm" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 8, SortOrder = 4, Value = "Intel&reg; B250 Chipset" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 9, SortOrder = 5, Value = "CPU Integrated: Intel&reg; HD Graphics 630" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 10, SortOrder = 6, Value = "8GB DDR4-2400 RAM (2x 4GB), 32GB Maximum (2x 16GB)" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 11, SortOrder = 7, Value = "1x 256GB NVMe M.2 PCI-E SSD w/ Opal Encryption\n1x Slim SATA III DVD&plusmn;RW Optical Drive\n2x Sata III ports (1x unused SATA III port)\n1x 3.5 / 2.5in Drive Bay (unused)" },
                new ProductSpecificationMapping { ProductId = 2, SpecificationId = 12, SortOrder = 8, Value = "Realtek ALC233 Chipset:\n High Definition Audio\n1x 1.5W Internal Speaker" },
            };

            foreach (ProductSpecificationMapping ps in productSpecifications)
            {
                var productSpecificationInDatabase = context.ProductSpecificationMappings.Where(
                    s =>
                        s.Product.Id == ps.ProductId &&
                        s.Specification.Id == ps.SpecificationId
                ).SingleOrDefault();

                if (productSpecificationInDatabase == null)
                {
                    context.ProductSpecificationMappings.Add(ps);
                }
            }
            context.SaveChanges();
        }
    }
}
