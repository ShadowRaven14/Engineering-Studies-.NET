using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PS7.Models;

namespace PS7.DAL
{
    public class ProductXmlDB : IProductDB
    {

        XmlDocument db = new XmlDocument();
        string xmlDB_path;

        public ProductXmlDB(IConfiguration _configuration)
        {
            xmlDB_path = _configuration.GetValue<string>("AppSettings:XmlDB_path");
            LoadDB();
        }

        private void LoadDB()
        {
            db.Load(xmlDB_path);
        }

        private void OpenXmlBase()
        {
            db.Load("DATA/store.xml");
        }

        private void SaveXmlBase()
        {
            db.Save("DATA/store.xml");
        }

        public List<Product> List()
        {
            LoadDB();
            List<Product> productList = new List<Product>();
            XmlNodeList productXmlNodeList = db.SelectNodes("/store/product");

            foreach (XmlNode productXmlNode in productXmlNodeList)
            {
                productList.Add(XmlNodeProduct2Product(productXmlNode));
            }
            return productList;
        }
        private Product XmlNodeProduct2Product(XmlNode node)
        {
            Product p = new Product();
            p.id = int.Parse(node.Attributes["id"].Value);
            p.name = node["name"].InnerText;
            p.price = decimal.Parse(node["price"].InnerText);
            return p;
        }

        private XmlNode XmlNodeProductGet(int _id)
        {
            XmlNode node = null;
            XmlNodeList list = db.SelectNodes("/store/product[@id=" + _id.ToString() + "]");
            node = list[0];
            return node;
        }


        public int GetID()
        {
            List<Product> productList = List();
            int lastID = 0;
            foreach (var p in productList)
            {
                lastID = p.id;
            }
            int newID = ++lastID;
            return newID;
        }


        public Product Get(int _id)
        {
            OpenXmlBase();
            XmlNode node = XmlNodeProductGet(_id);
            return XmlNodeProduct2Product(node);
        }


        public void Update(Product _product, int _id)
        {
            OpenXmlBase();
            XmlNode node = XmlNodeProductGet(_id);
            node["name"].InnerText = _product.name;
            node["price"].InnerText = _product.price.ToString();
            SaveXmlBase();
        }


        public void Delete(int _id)
        {
            OpenXmlBase();
            XmlNode node = XmlNodeProductGet(_id);
            node.ParentNode.RemoveChild(node);
            SaveXmlBase();
        }


        public void Add(Product _product)
        {

            _product.id = GetID();
            OpenXmlBase();

            XmlNode store = db.SelectSingleNode("store");

            XmlNode product = db.CreateNode(XmlNodeType.Element, "product", null);
            XmlAttribute id = db.CreateAttribute("id");
            id.Value = Convert.ToString(_product.id);
            product.Attributes.Append(id);
            store.AppendChild(product);

            XmlNode name = db.CreateNode(XmlNodeType.Element, "name", null);
            name.InnerText = _product.name;
            product.AppendChild(name);

            XmlNode price = db.CreateNode(XmlNodeType.Element, "price", null);
            price.InnerText = Convert.ToString(_product.price); ;
            product.AppendChild(price);

            SaveXmlBase();
        }

    }
}