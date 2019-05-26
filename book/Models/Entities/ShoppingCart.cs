using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using book.DAO;

namespace book.Models.Entities
{
    public class ShoppingCart
    {
        public List<Item> lst { get; set; }
        BookDAO bookDao = new BookDAO();

        public ShoppingCart()
        {
            lst = new List<Item>();
        }
        public void InsertItem(int id, string name, double price, int amount)
        {
            bool check = false;
            foreach (var item in lst)
            {
                if (item.id == id)
                {
                    check = true;
                    item.amount+=amount;
                    break;
                }
            }

            if (!check)
            {
                Item item = new Item();
                item.id = id;
                item.price = (decimal)price;
                item.name = name;
                item.amount = amount;
                item.mainImage = bookDao.GetByID(id).MainImage;
                lst.Add(item);
            }
        }

        public void UpdateAmount(int id, int amount)
        {
            
            foreach (var item in lst)
            {
                if (item.id == id)
                {

                    if (amount > 0)
                    {
                        item.amount = amount;
                    }
                    else
                    {
                        lst.Remove(item);
                    }
                    break;
                }
            }
        }

        public void RemoveItem(int id)
        {
            foreach (var item in lst)
            {
                if (item.id == id)
                {
                    lst.Remove(item);
                    break;
                }
            }
        }

        public int GetTotal()
        {
            int total = 0;
            foreach (var item in lst)
            {
                total += item.amount;
            }
            return total;
        }

        public decimal GetTotalMoney()
        {
            decimal total = 0;
            foreach (var item in lst)
            {
                total += item.amount * item.price;
            }
            return total;
        }
    }
}