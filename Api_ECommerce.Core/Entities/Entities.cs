using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_ECommerce.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }
    }
}
