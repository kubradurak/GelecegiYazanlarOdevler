﻿using Microsoft.EntityFrameworkCore;
using ProductFormApp.Data;
using ProductFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductFormApp.Controllers
{
    public class ProductControl
    {
        FormDbContext db = new FormDbContext();

        public int AddProduct(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges();
        }
        public int UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;

            return db.SaveChanges();
        }
        public int DeleteProduct(int _id)
        {
            var deletedProduct = db.Products.Find(_id);
            if (deletedProduct.Id == _id)
            {
                db.Products.Remove(deletedProduct);
            }
            else
            {
                MessageBox.Show("Başarısız");
            }

            return db.SaveChanges();
        }

        public Product GetProductById(int _selectedProductId)
        {
            return db.Products.Find(_selectedProductId);
        }
        public Product GetProductByName(string _selectedProductName)
        {
            return db.Products.FirstOrDefault(c => c.Name == _selectedProductName);
        }
       
        public Category GetCategoryById(int selectedValue)
        {
            return db.Categories.FirstOrDefault(c => c.Id == selectedValue);
        }
        public void AddStockByName(Product _product)
        {
            var product = db.Products.FirstOrDefault(c => c.Name == _product.Name);
            int productStockValue = Convert.ToInt32(product.Stock.ToString());
            int newStocktValue = Convert.ToInt32(_product.Stock.ToString());
            int sumStock = productStockValue + newStocktValue;
            product.Stock = sumStock;
             MessageBox.Show($"Stok eklendi yapıldı. Yeni stock kaydı {product.Stock}");
        }
        public bool CheckProduct(Product _product)
        {
            bool IsSavedProduct = false;
            foreach (var product in db.Products)
            {
                if (product.Name == _product.Name)
                {
                    IsSavedProduct = true;
                }
            }
            return IsSavedProduct;
        }
    }
}
