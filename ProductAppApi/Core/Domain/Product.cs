using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Core.Domain
{
    /// <summary>
    /// this is the Product Model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// this is the unique identifier 
        /// that is used for multiple uses (find,update and delete)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// this is the name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// this is the price of the product
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// this is the company name that manufactured the product
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// this is the image url for the product view
        /// </summary>
        public string ImgUrl { get; set; }
    }
}
