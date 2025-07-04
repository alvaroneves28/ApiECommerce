﻿using ApiECommerce.Entities;

public class OrderDetail
{
  
    public int Id { get; set; }                  
    public int OrderId { get; set; }             
    public int ProductId { get; set; }     
    public string? ProductName { get; set; }     
    public int Quantity { get; set; }           
    public decimal UnitPrice { get; set; }       
    public decimal TotalPrice { get; set; }

    public Product Product { get; set; }

}
