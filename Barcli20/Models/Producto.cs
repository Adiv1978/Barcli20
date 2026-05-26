namespace CliBarra.Models
{
    public class Producto
    {
        public int? id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal? precio { get; set; }

        public Producto()
        {
            this.id = null;
            this.codigo = string.Empty;
            this.descripcion = string.Empty;
            this.precio = null;
        }
    }
}
