using CarpathianFurniture.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture
{
    public class DBObjects
    {
        public static void Initial (ApplicationContext context)
        {
            
            if (!context.Furnitures.Any())
            {
                context.AddRange(
                    //sofa
                     new Furniture
                     {
                         Title = "Sofa",
                         Price = 10000,
                         Description = "Furniture from Carpathian",
                         ImagePath = "/images/carpathian_sofa.jpg",

                     },
                    new Furniture
                    {
                        Title = "Sofa",
                        Price = 60000,
                        Description = "Soft corner sofa",
                        ImagePath = "/images/corner_sofa.jpg",
                       
                    },
                    new Furniture
                    {
                        Title = "Sofa",
                        Price = 5000,
                        Description = "Cheap and comfortable sofa",
                        ImagePath = "/images/cheap_and_comfortable_sofa.jpg",
                        
                    },
                    new Furniture
                    {
                        Title = "Sofa",
                        Price = 27000,
                        Description = "Three-seater sofa",
                        ImagePath = "/images/three-seater_sofa.jpg",
                       
                    },
                    new Furniture
                    {
                        Title = "Sofa",
                        Price = 8000,
                        Description = "Straight sofa",
                        ImagePath = "/images/straight_sofa.jpg",
                       
                    },
                    //wardrodes

                     new Furniture
                     {
                         Title = "Wardrode",
                         Price = 7900,
                         Description = "Sliding wardrobe",
                         ImagePath = "/images/wardrode_1.jpg",

                     },

                      new Furniture
                      {
                          Title = "Wardrode",
                          Price = 5500,
                          Description = "Wardrode Everest",
                          ImagePath = "/images/wardrode_2.png",

                      },

                       new Furniture
                       {
                           Title = "Wardrode",
                           Price = 4000,
                           Description = "Wardrode for clothes",
                           ImagePath = "/images/wardrode_3.png",

                       },

                        new Furniture
                        {
                            Title = "Wardrode",
                            Price = 4200,
                            Description = "Sliding wardrobe doros",
                            ImagePath = "/images/wardrode_doros.png",

                        },

                         new Furniture
                         {
                             Title = "Wardrode",
                             Price = 3000,
                             Description = "Wardrode hagendrup",
                             ImagePath = "/images/wardrode_hagend.png",

                         },

                          //desks

                          new Furniture
                          {
                              Title = "Desk",
                              Price = 4900,
                              Description = "Desk barsky universal",
                              ImagePath = "/images/desk_barsky_universal.png",

                          },

                          new Furniture
                          {
                              Title = "Desk",
                              Price = 2000,
                              Description = "Desk ferrum-decor",
                              ImagePath = "/images/desk_1.png",

                          },

                          new Furniture
                          {
                              Title = "Desk",
                              Price = 1100,
                              Description = "Computer desk",
                              ImagePath = "/images/computer_desk.jpg",

                          },

                          new Furniture
                          {
                              Title = "Desk",
                              Price = 4000,
                              Description = "Dining desk",
                              ImagePath = "/images/desk_exen_intarsio.jpg",

                          },



                          //chairs
                          new Furniture
                          {
                              Title = "Chair",
                              Price = 1250,
                              Description = "Chair gt racer",
                              ImagePath = "/images/chair_gt_racer.png",

                          },

                          new Furniture
                          {
                              Title = "Chair",
                              Price = 600,
                              Description = "Chair sicily",
                              ImagePath = "/images/chair_sicily.png",

                          },

                          new Furniture
                          {
                              Title = "Chair",
                              Price = 1000,
                              Description = "Bag chair",
                              ImagePath = "/images/bag_chair.png",

                          },

                          new Furniture
                          {
                              Title = "Chair",
                              Price = 4000,
                              Description = "Gaming chair",
                              ImagePath = "/images/gaming_chair_1.png",

                          },

                            new Furniture
                            {
                                Title = "Chair",
                                Price = 3500,
                                Description = "Gaming chair",
                                ImagePath = "/images/gaming_chair_2.png",

                            },

                          new Furniture
                          {
                              Title = "Chair",
                              Price = 1500,
                              Description = "Office chair",
                              ImagePath = "/images/jysk_office_chair.png",

                          },

                            //commode

                            new Furniture
                            {
                                Title = "Commode",
                                Price = 1100,
                                Description = "Commode Kim",
                                ImagePath = "/images/commode_1.jpg",

                            },

                             new Furniture
                             {
                                 Title = "Commode",
                                 Price = 600,
                                 Description = "Commode Sonya",
                                 ImagePath = "/images/commode_2.jpg",

                             },

                              new Furniture
                              {
                                  Title = "Commode",
                                  Price = 4100,
                                  Description = "Commode",
                                  ImagePath = "/images/commode_3.jpg",

                              },

                               new Furniture
                               {
                                   Title = "Commode",
                                   Price = 3000,
                                   Description = "Commode Vivian",
                                   ImagePath = "/images/commode_4.jpg",

                               }


                    );
            }


            context.SaveChanges();


        }

    }
}
