using SilentAuction.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SilentAuction.Data
{
    public class TestSeedData
    {
        public static void Initialize(AuctionContext context)
        {
            context.Database.EnsureCreated();

            if (context.Auctions.Any())
            {
                return;
            }

            // Auctions
            var auctions = new Auction[]
            {
                new Auction { Name = "Auction of August 2017", StartDate = new DateTime(2017, 7, 10), EndDate = new DateTime(2017, 8, 15)}
            };
            foreach (Auction auction in auctions)
            {
                context.Auctions.Add(auction);
            }
            context.SaveChanges(); //Need to save everytime if using Ids

            // Sponsors
            var sponsors = new Sponsor[]
            {
                // Accommodation
                new Sponsor { Name = "Trisara", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "Le Meridien Phuket Beach Resort", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "Andara Resort & Villas", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "The Surin Phuket", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "Mövenpick Resort, Bangtao Beach Phuket", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},

                // Advertising
                new Sponsor { Name = "Khao Phuket", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "Novosti Phuket", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "The Phuket News TV", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},

                // Dining (+Accomodation +Lifestyle)
                new Sponsor { Name = "Burasari Resort", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
                new Sponsor { Name = "The Siam Supper Club", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},

                // Entertainment
                new Sponsor { Name = "H3 Digital Limited", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},

                // Lifestyle (+Dinning, + Accomodation)
                new Sponsor { Name = "Novotel Phuket Kamala Beach", StartDate = new DateTime(2017, 7, 10), Phone = "5555555555"},
            };
            foreach (Sponsor sponsor in sponsors)
            {
                context.Sponsors.Add(sponsor);
            }
            context.SaveChanges();

            // Catagories
            var accommodationCategory = new Category { Name = "Accommodation" };
            context.Categories.Add(accommodationCategory);

            var advertisingCategory = new Category { Name = "Advertising" };
            context.Categories.Add(advertisingCategory);

            var diningCategory = new Category { Name = "Dining" };
            context.Categories.Add(diningCategory);

            var entertainmentCategory = new Category { Name = "Entertainment" };
            context.Categories.Add(entertainmentCategory);

            var lifestyleCategory = new Category { Name = "Lifestyle" };
            context.Categories.Add(lifestyleCategory);
            context.SaveChanges();

            // Items
            var items = new Item[]
            {
                // Accommodation
                new Item { Name = "2 Nights Accommodation in an Ocean View Pool Villa at Trisara", Description = "Enjoy a two night stay in a spectacular Ocean View Pool Villa at Trisara, inclusive of 2x Trisara spa treatments, daily breakfast and the Trisara Sunday Jazz Brunch for 2.", Category = accommodationCategory, RetailPrice = 100, SponsorId = sponsors[0].Id, Sponsor = sponsors[0], OfferExpires = "May 10, 2018" , Terms = "This certificate is valid from 30 May 17 – 10 May 18; except : 01 – 07 Oct 17, 20 Dec 17 – 20 Jan 18 and subject to availability only. This certificate is neither transferable nor redeemable for cash. At least 7 days advance reservation is required."},
                new Item { Name = "2 Nights Accommodation at Le Meridien Phuket Beach Resort + 2 Dinners", Description = "Enjoy a 3 day 2 night stay for two persons at the Le Meridien Phuket Beach Resort in an Ocean Front Deluxe Suite including daily buffet breakfast and one dinner at Portofino including a bottle of house wine and one dinner at Ariake including a carafe of Sake.", Category = accommodationCategory, RetailPrice = 60, SponsorId = sponsors[1].Id, Sponsor = sponsors[1], OfferExpires = "May 31, 2018", Terms = "Voucher is valid from 1 June 2017 to 31 May 2018. Blackout dates: 21 December 2017 to 28 February 2018. Gift voucher will be issued once the full name of the winner is determined. The original gift voucher will be non-transferable to anyone other than the person’s name stated on the voucher. Presentation of the original gift voucher is required upon check-in to avail the offer. Prior reservation is required and based on space availability."},
                new Item { Name = "1 Night Accommodation at Andara Resort + In-Suite BBQ w/ Champagne", Description = "Enjoy a 1-night stay in a 4-bedroom Pool Suite at Andara Resort & Villas with daily breakfast at SILK Restaurant and a BBQ for 8 persons in your Suite Room with your own private chef accompanied by 2 bottles of Louis Roederer Champagne.", Category = accommodationCategory, RetailPrice = 60, SponsorId = sponsors[2].Id, Sponsor = sponsors[2], OfferExpires = "November 30, 2017", Terms = "Valid for stays between 15 May and 30 November 2017. Maximum 8 people only. Voucher cannot be redeemed for cash and used in conjunction with other promotions. Reservation is required 14 days in advance, subject to space availability Cancellation is 3 days written notice to Andara to prior arrival"},
                new Item { Name = "3 Nights Accommodation at The Surin Phuket", Description = "Enjoy a 3 night stay for two persons at The Surin Phuket in a Beach Deluxe Suite including daily buffet breakfast with signature dinner & spa treatment.", Category = accommodationCategory, RetailPrice = 60, SponsorId = sponsors[3].Id, Sponsor = sponsors[3], OfferExpires = "June 30, 2018", Terms = "Validity dates: 1 June 2017 to 30 June 2018. Blackout dates: 21 December 2017 to 28 February 2018. Signature set dinner is for 2 persons(food only) at any outlets. Spa treatment is for 2 persons(60 minutes). Presentation of the original gift voucher is required upon check -in. Prior reservation is required and based on space availability. Non - redeemable, non - refundable and prize is non - transferable."},
                new Item { Name = "2 Nights Accommodation at Mövenpick Resort, Bangtao Beach Phuket", Description = "Enjoy a 2-night stay in a Seaview Pool Suite 1 Bedroom inclusive of breakfast for two at The Palm Cuisine at the Mövenpick Resort, Bangtao Beach Phuket.", Category = accommodationCategory, RetailPrice = 60, SponsorId = sponsors[4].Id, Sponsor = sponsors[4], OfferExpires = "December 01, 2017", Terms = "Valid for stay from now to 15 December 2017"},

                // Advertising
                new Item { Name = "Half Page Advert in Khao Phuket (The Phuket News in Thai)", Description = "Receive one 1/2 page advertisement — 274mm (w) x 189mm (h) – in Khao Phuket (The Phuket News in Thai), including artwork and translation.", Category = advertisingCategory, RetailPrice = 60, SponsorId = sponsors[5].Id, Sponsor = sponsors[5], OfferExpires = "January 01, 2018"},
                new Item { Name = "Half Page Advert in Novosti Phuket (The Phuket News in Russian)", Description = "Receive one 1/2 page advertisement — 274mm (w) x 189mm (h) – in Novosti Phuket (The Phuket News in Russian), including artwork and translation.", Category = advertisingCategory, RetailPrice = 60, SponsorId = sponsors[6].Id, Sponsor = sponsors[6], OfferExpires = "January 01, 2018"},
                new Item { Name = "TV Advertisement in The Phuket News TV", Description = "Receive a 1 month x 10 second fixed graphic advertisement on The Phuket News TV.", Category = advertisingCategory, RetailPrice = 60, SponsorId = sponsors[7].Id, Sponsor = sponsors[7], OfferExpires = "January 01, 2018"},

                // Dining (+Accomodation +Lifestyle)
                new Item { Name = "Eternity Spa Package (3.5 hrs) and Set Dinner for 2 at Burasari Resort, Phuket", Description = "Enjoy an Eternity Spa Package (lasting three and a half hours) as well as a set dinner for 2 persons at the Burasari Resort in Patong, Phuket.", Category = diningCategory, RetailPrice = 60, SponsorId = sponsors[8].Id, Sponsor = sponsors[8], OfferExpires = "April 30, 2018", Terms = "Voucher is valid from 1 June 2017 – 30 April 2018. Voucher cannot be used with other discount or special promotion. Voucher cannot be exchanged for cash. Original voucher must be presented upon check-in. Advance reservations are required and subject to availability"},
                new Item { Name = "THB 5,000 Voucher for use The Siam Supper Club", Description = "The winning bidder will get to enjoy THB 5,000 during a dining and/or drinking experience at The Siam Supper Club.", Category = diningCategory, RetailPrice = 60, SponsorId = sponsors[9].Id, Sponsor = sponsors[9], OfferExpires = "January 01, 2018", Terms = "Not redeemable for cash."},

                // Entertainment
                new Item { Name = "Nuvo AccentPLUS1 6.5″ In-Ceiling Speakers", Description = "Fill the room with impeccably clean, full sound with this set of Nuvo AccentPLUS1 6.5″ In-Ceiling Speakers.", Category = entertainmentCategory, RetailPrice = 60, SponsorId = sponsors[10].Id, Sponsor = sponsors[10]},

                // Lifestyle (+Dinning, + Accomodation)
                new Item { Name = "2 Nights Accommodation at Novotel Phuket Kamala Beach + Dinner + Spa", Description = "Enjoy a 3 day 2 night stay for two persons at the Novotel Phuket Kamala Beach in a One Bedroom Pool Villa including daily breakfast, a romantic dinner for 2 at On The Roof and a one hour spa treatment for 2.", Category = lifestyleCategory, RetailPrice = 60, SponsorId = sponsors[11].Id, Sponsor = sponsors[11], OfferExpires = "May 13, 2018", Terms = "Voucher is valid from now to 13 May 2018. Blackout dates: 1 November 2017 to 31 March 2018."},
            };
            foreach (Item item in items)
            {
                context.Items.Add(item);
            }
            context.SaveChanges();

            // Listings
            var listings = new Listing[]
            {
                new Listing { MinimumBid = 20, Increment = 5, AuctionId = auctions[0].Id, ItemId = items[0].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[1].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[2].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[3].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[4].Id},

                new Listing { MinimumBid = 20, Increment = 5, AuctionId = auctions[0].Id, ItemId = items[5].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[6].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[7].Id},

                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[8].Id},
                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[9].Id},

                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[10].Id},

                new Listing { MinimumBid = 10, Increment = 2, AuctionId = auctions[0].Id, ItemId = items[11].Id}
            };
            foreach (Listing listing in listings)
            {
                context.Listings.Add(listing);
            }
            context.SaveChanges();

            // User Roles
            var role = new Role { Id = RoleId.User, Name = "User" };
            context.Roles.Add(role);

            role = new Role { Id = RoleId.Administrator, Name = "Administrator" };
            context.Roles.Add(role);

            // Images
            // Found at: https://phab.phukethotelsassociation.com/silent-auction/
            // Media types: https://en.wikipedia.org/wiki/Media_type
            var currentFolderPath = Assembly.GetEntryAssembly().Location;

            var poolVillaTisara1 = new Media
            {
                FileName = "PoolVillaTisara1.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/2017_13_02_TRISARA__1090_FINAL-1900x1267.jpg"))
            };
            context.Media.Add(poolVillaTisara1);

            var poolVillaTisara2 = new Media
            {
                FileName = "poolVillaTisara2.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/H-OPV-10_Bathroom-1900x1501.jpg"))
            };
            context.Media.Add(poolVillaTisara2);

            var andaraResortBBQ = new Media
            {
                FileName = "Andara18.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/Andara18.jpg"))
            };
            context.Media.Add(andaraResortBBQ);

            var leMeridien = new Media
            {
                FileName = "Le-Meridien-Phuket-Beach-Resort-2-Dinners_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/Le-Meridien-Phuket-Beach-Resort-2-Dinners_1900x1267.jpg"))
            };
            context.Media.Add(leMeridien);

            var movenpickResort = new Media
            {
                FileName = "Movenpick-Resort-Bangtao-Beach_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/Movenpick-Resort-Bangtao-Beach_1900x1267.jpg"))
            };
            context.Media.Add(movenpickResort);

            var surinResort = new Media
            {
                FileName = "re_The-Surin-1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/re_The-Surin-1900x1267.jpg"))
            };
            context.Media.Add(surinResort);

            var novotelKamala = new Media
            {
                FileName = "novotel-kamala.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/novotel-kamala.jpg"))
            };
            context.Media.Add(novotelKamala);

            var eternitySpa = new Media
            {
                FileName = "Eternity-Spa-Package_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/Eternity-Spa-Package_1900x1267.jpg"))
            };
            context.Media.Add(eternitySpa);

            var siamSupper = new Media
            {
                FileName = "siam-supper-club_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/siam-supper-club_1900x1267.jpg"))
            };
            context.Media.Add(siamSupper);

            var ceilingSpeaker = new Media
            {
                FileName = "AccentPLUS1-Ceiling-Speaker-AP1C_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/AccentPLUS1-Ceiling-Speaker-AP1C_1900x1267.jpg"))
            };
            context.Media.Add(ceilingSpeaker);

            var adPhuketNewsThai = new Media
            {
                FileName = "KPK_GiftVoucher-ForKhaoPhuket_Oct-27-2017_Lowres_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/KPK_GiftVoucher-ForKhaoPhuket_Oct-27-2017_Lowres_1900x1267.jpg"))
            };
            context.Media.Add(adPhuketNewsThai);

            var adPhuketNewsRussian = new Media
            {
                FileName = "NP_GiftVoucher-Novostia-Phuket_Oct-20-2017_Lowres_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/NP_GiftVoucher-Novostia-Phuket_Oct-20-2017_Lowres_1900x1267.jpg"))
            };
            context.Media.Add(adPhuketNewsRussian);

            var tvAd = new Media
            {
                FileName = "TPN_GiftVoucher-ForPhuketNewsTV_Oct-27-2017_Lowres_1_1900x1267.jpg",
                Type = "image/jpeg",
                Content = File.ReadAllBytes(Path.Combine(currentFolderPath, "../../../../SampleImages/Item1/TPN_GiftVoucher-ForPhuketNewsTV_Oct-27-2017_Lowres_1_1900x1267.jpg"))
            };
            context.Media.Add(tvAd);

            //context.ItemMedia.Add(new ItemMedia { Item = items[0], Media = poolVillaTisara1 });
            context.ItemMedia.Add(new ItemMedia { Item = items[0], Media = poolVillaTisara2 });
            context.ItemMedia.Add(new ItemMedia { Item = items[1], Media = leMeridien });
            context.ItemMedia.Add(new ItemMedia { Item = items[2], Media = andaraResortBBQ });
            context.ItemMedia.Add(new ItemMedia { Item = items[3], Media = surinResort });
            context.ItemMedia.Add(new ItemMedia { Item = items[4], Media = movenpickResort });
            context.ItemMedia.Add(new ItemMedia { Item = items[5], Media = adPhuketNewsThai });
            context.ItemMedia.Add(new ItemMedia { Item = items[6], Media = adPhuketNewsRussian });
            context.ItemMedia.Add(new ItemMedia { Item = items[7], Media = tvAd });
            context.ItemMedia.Add(new ItemMedia { Item = items[8], Media = eternitySpa });
            context.ItemMedia.Add(new ItemMedia { Item = items[9], Media = siamSupper });
            context.ItemMedia.Add(new ItemMedia { Item = items[10], Media = ceilingSpeaker });
            context.ItemMedia.Add(new ItemMedia { Item = items[11], Media = novotelKamala });
            context.SaveChanges();
        }
    }
}
