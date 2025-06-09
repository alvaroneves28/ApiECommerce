using ApiECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

public class Order
{
    public int Id { get; set; }                      
    public string? CustomerName { get; set; }          
    public DateTime OrderDate { get; set; }

    [JsonIgnore]
    public List<BasketItem>? Items { get; set; }       
    public string? Status { get; set; }

    public int UserId { get; set; }

    public string? Address {  get; set; }
    public decimal TotalAmount
    {
        get { return Items?.Sum(item => item.TotalPrice) ?? 0; }
    }



}
