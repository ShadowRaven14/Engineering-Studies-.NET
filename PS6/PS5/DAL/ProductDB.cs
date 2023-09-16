using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using PS5.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PS5.DAL
{
    public class ProductDB
    {
        public ProductDB()
        {
        }

        private readonly ILogger<ProductDB> _logger;
        public IConfiguration _configuration { get; }

        public ProductDB(IConfiguration configuration, ILogger<ProductDB> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Create(Product p)
        {
        }

        public void Delete(int id)
        {
            Product product = null;
        }

        public void SetProduct(Product p)
        {
        }


        /*
        private List<Product> products;

        private int GetNextId()
        {
            int lastID = products[products.Count - 1].id;
            int newID = lastID++;
            return newID;
        }

        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                products = Product.GetProducts();
            }
            else
            {
                // products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                products = JsonSerializer.Deserialize<List<Product>>(jsonProducts);
            }
        }

        public string Save()
        {

            //return JsonConvert.SerializeObject(products);
            return JsonSerializer.Serialize(products);
        }

        public void Create(Product p)
        {
            p.id = GetNextId() + 1;
            products.Add(p);
        }

        public void Edit(int id, Product p)
        {
            products[id - 1].name = p.name;
            products[id - 1].price = p.price;
        }

        public void Delete(int id)
        {
            foreach (Product p in products)
            {
                if (p.id == id)
                {
                    products.Remove(p);
                    break;
                }
            }
        }

        public Product lookforID(int id)
        {
            foreach (Product p in products)
            {
                if (p.id == id) return p;
            }
            return null;
        }

        public List<Product> List()
        {
            return products;
        }
        */
    }
}
