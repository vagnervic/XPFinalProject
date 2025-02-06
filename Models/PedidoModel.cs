namespace XPFinalProject.Models
{
    public class PedidoModel
    {
        public int id { get; set; } 
        public string? Codigo { get; set; }

        public ClienteModel? cliente { get; set; }
    }
}
