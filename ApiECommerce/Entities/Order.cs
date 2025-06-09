using ApiECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int Id { get; set; }                      
    public string CustomerName { get; set; }          
    public DateTime OrderDate { get; set; }       
    public List<BasketItem> Items { get; set; }       
    public string Status { get; set; }

    public int UserId { get; set; }


    public decimal TotalAmount
    {
        get { return Items.Sum(item => item.TotalPrice); }
    }

  
    public Order(string customerName)
    {
        CustomerName = customerName;
        OrderDate = DateTime.Now;
        Items = new List<BasketItem>();
        Status = "Pendente";
    }

    
    public void AddItem(BasketItem item)
    {
        Items.Add(item);
    }

    
    public void RemoveItem(int productId)
    {
        var itemToRemove = Items.FirstOrDefault(i => i.ProductId == productId);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
        }
    }

   
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }
}
