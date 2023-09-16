using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using PS4.Models;

namespace PS4.DAL
{
    public class ShopCartDB
    {
        private List<Product> productsInCart;
        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                productsInCart = Product.GetProducts();
            }
            else
            {
                // productsInCart = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                productsInCart = JsonSerializer.Deserialize<List<Product>>(jsonProducts);
            }
        }
        public ShopCartDB()
        {
            productsInCart = new List<Product>();
        }
        public void AddToCart(Product p)
        {
            productsInCart.Add(p);
        }
        public void Clear()
        {
            productsInCart.Clear();
        }
        public string Save()
        {
            //return JsonConvert.SerializeObject(productsInCart);
            return JsonSerializer.Serialize(productsInCart);
        }
        public List<Product> GetProductsList
        {
            get
            {
                return productsInCart;
            }
        }
    }
}
