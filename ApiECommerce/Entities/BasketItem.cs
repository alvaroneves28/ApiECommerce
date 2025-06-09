namespace ApiECommerce.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }                
        public int ProductId { get; set; }     
        
        public string? ProductName { get; set; }    
        public int Quantity { get; set; }           
        public decimal UnitPrice { get; set; }

        public int UserId { get; set; }


        public decimal TotalPrice { get; set; }
        

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
     

    }
}
