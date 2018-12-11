using Microsoft.AspNetCore.Identity;
using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebCoreApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }

            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = Status.Active
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            if (!_context.Contacts.Any())
            {
                _context.Contacts.Add(new Contact()
                {
                    Id = CommonConstants.DefaultContactId,
                    Address = "No 36 Lane 133 Nguyen Phong Sac Cau Giay",
                    Email = "pandashop@gmail.com",
                    Name = "Panda Shop",
                    Phone = "0942 324 543",
                    Status = Status.Active,
                    Website = "http://pandashop.com",
                    Lat = 21.0435009,
                    Lng = 105.7894758
                });
            }

            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "PRODUCT",Name = "Product Management",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.Active,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/Advertisement/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                });
            }

            if (_context.ProductTypes.Count() == 0)
            {
                //_context.ProductTypes.AddRange(new List<ProductType>()
                //{
                //    new ProductType(){Name = "Động phổ thông"}
                //});
                List<ProductType> listProductType = new List<ProductType>()
                {
                    new ProductType(){Name = "Động phổ thông",
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 1",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-1", SeoPageTitle = "", ModifiedDate = DateTime.Now, Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 2",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-2", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 3",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-3", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 4",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-4", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 5",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-5", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 6",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-6", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 7",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-7", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 8",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-8", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 9",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-9", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 10",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-10", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 11",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-11", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 12",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-12", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 13",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-13", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 14",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-14", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 15",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-15", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 16",CreatedDate=DateTime.Now, ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-16", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 17",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-17", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 18",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-18", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 19",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-19", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                            new Product(){Name = "Product 20",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-20", SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
                        }
                    }
                };
                _context.ProductTypes.AddRange(listProductType);
            }

            //if (_context.Products.Count() == 0)
            //{
            //    _context.Products.AddRange(new List<Product>()
            //    {
            //            new Product(){Name = "Product 1",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-1", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now, Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 2",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-2", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 3",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-3", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 4",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-4", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 5",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-5", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 6",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-6", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 7",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-7", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 8",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-8", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 9",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-9", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 10",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-10", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 11",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-11", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 12",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-12", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 13",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-13", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 14",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-14", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 15",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-15", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 16",CreatedDate=DateTime.Now, ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-16", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 17",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-17", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 18",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-18", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 19",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-19", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //            new Product(){Name = "Product 20",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-20", TypeId = 1, SeoPageTitle = "", ModifiedDate = DateTime.Now,Price = 1000,Status = Status.Active},
            //    });
            //}

            if (_context.Footers.Count() == 0)
            {
                string content = "Footer";
                _context.Footers.Add(new Footer()
                {
                    Name = "Footer chính",
                    Content = content
                });
            }

            //if (_context.Colors.Count() == 0)
            //{
            //    List<Color> listColor = new List<Color>()
            //    {
            //        new Color() {Name="Black", Code="#000000" },
            //        new Color() {Name="White", Code="#FFFFFF"},
            //        new Color() {Name="Red", Code="#ff0000" },
            //        new Color() {Name="Blue", Code="#1000ff" },
            //    };
            //    _context.Colors.AddRange(listColor);
            //}

            if (_context.AdvertisementPages.Count() == 0)
            {
                List<AdvertisementPage> pages = new List<AdvertisementPage>()
                {
                    new AdvertisementPage() {Id="home", Name="Home",AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="home-left",Name="Bên trái"}
                    } },
                    new AdvertisementPage() {Id="product-cate", Name="Product category" ,
                        AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="product-cate-left",Name="Bên trái"}
                    }},
                    new AdvertisementPage() {Id="product-detail", Name="Product detail",
                        AdvertisementPositions = new List<AdvertisementPosition>(){
                        new AdvertisementPosition(){Id="product-detail-left",Name="Bên trái"}
                    } },

                };
                _context.AdvertisementPages.AddRange(pages);
            }

            //if (_context.Slides.Count() == 0)
            //{
            //    List<Slide> slides = new List<Slide>()
            //    {
            //        new Slide() {Name="Slide 1",Image="/client-side/images/slider/slide-1.jpg",Url="#",DisplayOrder = 0, GroupId = 1, Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 2",Image="/client-side/images/slider/slide-2.jpg",Url="#",DisplayOrder = 1,GroupId = 1, Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 3",Image="/client-side/images/slider/slide-3.jpg",Url="#",DisplayOrder = 2,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

            //        new Slide() {Name="Slide 1",Image="/client-side/images/brand1.png",Url="#",DisplayOrder = 1,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 2",Image="/client-side/images/brand2.png",Url="#",DisplayOrder = 2,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 3",Image="/client-side/images/brand3.png",Url="#",DisplayOrder = 3,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 4",Image="/client-side/images/brand4.png",Url="#",DisplayOrder = 4,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 5",Image="/client-side/images/brand5.png",Url="#",DisplayOrder = 5,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 6",Image="/client-side/images/brand6.png",Url="#",DisplayOrder = 6,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 7",Image="/client-side/images/brand7.png",Url="#",DisplayOrder = 7,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 8",Image="/client-side/images/brand8.png",Url="#",DisplayOrder = 8,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 9",Image="/client-side/images/brand9.png",Url="#",DisplayOrder = 9,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 10",Image="/client-side/images/brand10.png",Url="#",DisplayOrder = 10,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Slide() {Name="Slide 11",Image="/client-side/images/brand11.png",Url="#",DisplayOrder = 11,GroupId = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //    };
            //    _context.Slides.AddRange(slides);
            //}

            //if (_context.Sizes.Count() == 0)
            //{
            //    List<Size> listSize = new List<Size>()
            //    {
            //        new Size() { Name="XXL" },
            //        new Size() { Name="XL"},
            //        new Size() { Name="L" },
            //        new Size() { Name="M" },
            //        new Size() { Name="S" },
            //        new Size() { Name="XS" }
            //    };
            //    _context.Sizes.AddRange(listSize);
            //}

            if (_context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Men shirt",SeoAlias="men-shirt", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Men shirt", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active,SortOrder=1,
                        //Products = new List<Product>()
                        //{
                        //    new Product(){Name = "Product 1",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-1",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 2",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-2",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 3",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-3",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 4",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-4",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 5",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-5",Price = 1000,Status = Status.Active},
                        //}
                    },
                    new ProductCategory() { Name="Women shirt",SeoAlias="women-shirt", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Women shirt", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active ,SortOrder=2,
                        //Products = new List<Product>()
                        //{
                        //    new Product(){Name = "Product 6",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-6",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 7",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-7",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 8",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-8",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 9",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-9",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 10",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-10",Price = 1000,Status = Status.Active},
                        //}},
                    },
                    new ProductCategory() { Name="Men shoes",SeoAlias="men-shoes", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Men shoes", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active ,SortOrder=3,
                        //Products = new List<Product>()
                        //{
                        //    new Product(){Name = "Product 11",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-11",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 12",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-12",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 13",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-13",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 14",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-14",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 15",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-15",Price = 1000,Status = Status.Active},
                        //}},
                    },
                    new ProductCategory() { Name="Woment shoes",SeoAlias="women-shoes", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Woment shoes", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active,SortOrder=4,
                        //Products = new List<Product>()
                        //{
                        //    new Product(){Name = "Product 16",CreatedDate=DateTime.Now, ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-16",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 17",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-17",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 18",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-18",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 19",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-19",Price = 1000,Status = Status.Active},
                        //    new Product(){Name = "Product 20",CreatedDate=DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-20",Price = 1000,Status = Status.Active},
                        //}}
                    }
                };
                _context.ProductCategories.AddRange(listProductCategory);
            }

            if (_context.PostCategories.Count() == 0)
            {
                List<PostCategory> listPostCategory = new List<PostCategory>()
                {
                    new PostCategory() { Name="Chia sẻ",SeoAlias="chia-se", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Chia sẻ", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active,SortOrder=1,
                        Posts = new List<Post>()
                        {
                            new Post(){Name = "Post 1",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-1", SeoPageTitle = "Post 1", IsDeleted = false,Status = Status.Active},
                            new Post(){Name = "Post 2",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-2", SeoPageTitle = "Post 2", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 3",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-3", SeoPageTitle = "Post 3", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 4",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-4", SeoPageTitle = "Post 4", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 5",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-5", SeoPageTitle = "Post 5", IsDeleted = false, Status = Status.Active},
                        }
                    },
                    new PostCategory() { Name="Kinh nghiệm chăm sóc website",SeoAlias="kinh-nghiem-cham-soc-website", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Kinh nghiệm chăm sóc website", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active ,SortOrder=2,
                        Posts = new List<Post>()
                        {
                            new Post(){Name = "Post 6",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-6", SeoPageTitle = "Post 6", IsDeleted = false,Status = Status.Active},
                            new Post(){Name = "Post 7",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-7", SeoPageTitle = "Post 7", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 8",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-8", SeoPageTitle = "Post 8", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 9",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-9", SeoPageTitle = "Post 9", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 10",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-10", SeoPageTitle = "Post 10", IsDeleted = false, Status = Status.Active},
                        }
                    },
                    new PostCategory() { Name="Kiến thức SEO",SeoAlias="kien-thuc-seo", ThumbnailImage="/",ParentId = null, IsDeleted = false, SeoPageTitle = "Kiến thức SEO", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now,Status=Status.Active ,SortOrder=3,
                         Posts = new List<Post>()
                        {
                            new Post(){Name = "Post 11",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-11", SeoPageTitle = "Post 11", IsDeleted = false,Status = Status.Active},
                            new Post(){Name = "Post 12",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-12", SeoPageTitle = "Post 12", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 13",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-13", SeoPageTitle = "Post 13", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 14",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-14", SeoPageTitle = "Post 14", IsDeleted = false, Status = Status.Active},
                            new Post(){Name = "Post 15",CreatedDate=DateTime.Now, ModifiedDate = DateTime.Now,ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "post-15", SeoPageTitle = "Post 15", IsDeleted = false, Status = Status.Active},
                        }
                    }
                };
                _context.PostCategories.AddRange(listPostCategory);
            }

            if (_context.GroupSlides.Count() == 0)
            {
                List<GroupSlide> listGroupSlide = new List<GroupSlide>()
                {
                    new GroupSlide(){Name = "Group 1", Status = Status.Active,
                        Slides = new List<Slide>()
                        {
                            new Slide() {Name="Slide 1",Image="/client-side/images/brand1.png",Url="#",DisplayOrder = 1,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 2",Image="/client-side/images/brand2.png",Url="#",DisplayOrder = 2,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 3",Image="/client-side/images/brand3.png",Url="#",DisplayOrder = 3,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 4",Image="/client-side/images/brand4.png",Url="#",DisplayOrder = 4,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 5",Image="/client-side/images/brand5.png",Url="#",DisplayOrder = 5,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 6",Image="/client-side/images/brand6.png",Url="#",DisplayOrder = 6,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 7",Image="/client-side/images/brand7.png",Url="#",DisplayOrder = 7,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 8",Image="/client-side/images/brand8.png",Url="#",DisplayOrder = 8,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 9",Image="/client-side/images/brand9.png",Url="#",DisplayOrder = 9,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 10",Image="/client-side/images/brand10.png",Url="#",DisplayOrder = 10,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                            new Slide() {Name="Slide 11",Image="/client-side/images/brand11.png",Url="#",DisplayOrder = 11,Status = Status.Active, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        }
                    }
                };
                _context.GroupSlides.AddRange(listGroupSlide);
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = "Tedu Shop home",
                    Status = Status.Active
                });
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "shopping, sales",
                    Status = Status.Active
                });
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home tedu",
                    Status = Status.Active
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}