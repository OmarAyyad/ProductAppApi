using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAppApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Persistance.EntityConfiguration
{
    /// <summary>
    /// This is the configuration of entity Product that would be mapped to DB
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// this is the configure method that take entity builder for product entity 
        /// so that we can use fluent api to configure how the product entity look like in database
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ///<summary>
            ///change the name of table
            /// </summary>
            builder.ToTable("products");

            ///<summary>
            ///Specifying the id of the table
            /// </summary>
            builder.HasKey(p => p.Id);

            ///<summary>
            ///Mapping the Name property to the PName Column 
            ///Specifying the length with the column type 
            ///making it required
            ///NOTE (of course it has a 'has max length' extension but it does some problems 
            ///like making it's length to 1 in the migrations so that worked like a charm)
            /// </summary>
            builder.Property(p => p.Name)
                .HasColumnName("PName")
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            ///<summary>
            ///Mapping the Image property to the ImageUrl Column
            ///Specifying the type and length
            ///making it required
            ///</summary>
            builder.Property(p => p.ImgUrl)
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            ///<summary>
            ///Mapping the Price property to the Price Column
            ///making it required
            ///</summary>
            builder.Property(p => p.Price)
                .HasColumnType("float")
                .IsRequired();

            ///<summary>
            ///Mapping the CompanyName property to the PCompanyName Column
            ///Specifying the type and max length
            ///making it required
            ///</summary>
            builder.Property(p => p.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("nvarchar(50)")
                .IsRequired();


            ///<summary>
            ///this is the way of including some data with the migration 
            ///but unfortunately the migration wouldn't accept it without a value for id
            ///and the database wouldn't accept it with a value for id (so it's stuck there)
            ///</summary>

            #region inserting some data

            

            //builder.HasData(
            //         new 
            //         {
            //             Name = "Nikon D5600 DSLR Camera",
            //             Price = 14450,
            //             CompanyName = "Nikon",
            //             ImgUrl = "https://www.bhphotovideo.com/images/images1500x1500/nikon_d5600_dslr_camera_with_1308820.jpg"
            //         },
            //         new  
            //         {
            //             Name = "Nikon EN-EL14a Rechargeable Lithium-Ion Battery",
            //             Price = 680,
            //             CompanyName = "Nikon",
            //             ImgUrl = "https://www.bhphotovideo.com/images/images2500x2500/nikon_27126_en_el14a_rechargeable_li_ion_battery_1010384.jpg"
            //         },
            //         new  
            //         {
            //             Name = "Nikon AF-S DX NIKKOR 35mm f/1.8G Lens",
            //             Price = 3060,
            //             CompanyName = "Nikon",
            //             ImgUrl = "https://www.bhphotovideo.com/images/images2500x2500/Nikon_2183_AF_S_Nikkor_35mm_f_1_8G_606792.jpg"
            //         },
            //         new  
            //         {
            //             Name = "Nikon SB-700 AF Speedlight",
            //             Price = 5700,
            //             CompanyName = "Nikon",
            //             ImgUrl = "https://www.bhphotovideo.com/images/images1000x1000/Nikon_4808_SB_700_Speedlight_Shoe_Mount_734997.jpg"
            //         },
            //         new  
            //         {
            //             Name = "SanDisk 32GB Extreme UHS-I SDHC Memory Card",
            //             Price = 180,
            //             CompanyName = "SanDisk",
            //             ImgUrl = "https://www.bhphotovideo.com/images/images1500x1500/sandisk_sdsdxve_032g_gncin_extreme_sdhc_32gb_1275608.jpg"
            //         },
            //         new  
            //         {
            //             Name = "IPhone X",
            //             Price = 16000,
            //             CompanyName = "Apple",
            //             ImgUrl = "https://eg.jumia.is/GNQEGvGzkb3VEyYmGgMZ4jp0RpM=/fit-in/680x680/filters:fill(white)/product/97/46349/1.jpg?9365"
            //         },
            //         new  
            //         {
            //             Name = "IPhone XS Max",
            //             Price = 32000,
            //             CompanyName = "Apple",
            //             ImgUrl = "https://eg.jumia.is/RjB5QdvxlbjkUAFvNpcblRC9xKw=/fit-in/680x680/filters:fill(white)/product/84/15488/1.jpg?5561"
            //         },
            //         new  
            //         {
            //             Name = "Cooling & Heating Series 7 Inverter",
            //             Price = 15000,
            //             CompanyName = "Samsung",
            //             ImgUrl = "https://eg.jumia.is/ahqdn4JmC5WZvfOWEcwPx4zGb50=/fit-in/680x680/filters:fill(white)/product/49/76239/1.jpg?5083"
            //         },
            //         new  
            //         {
            //             Name = "Cooling&Heating Inverter Air Conditioner",
            //             Price = 20000,
            //             CompanyName = "Samsung",
            //             ImgUrl = "https://eg.jumia.is/1m-hLs_rM136JluPYr0NNMzR1xg=/fit-in/680x680/filters:fill(white)/product/28/81591/1.jpg?5648"
            //         },
            //         new  
            //         {
            //             Name = "LG OLED55C8PVA - 55-inch UHD 4K OLED Smart TV with ThinQ AI",
            //             Price = 43000,
            //             CompanyName = "LG",
            //             ImgUrl = "https://eg.jumia.is/cwBV5TMz7joJtP3_hqk3nnQgPUE=/fit-in/680x680/filters:fill(white)/product/56/88389/1.jpg?5268"
            //         }

            //    );

            #endregion

        }
    }
}
