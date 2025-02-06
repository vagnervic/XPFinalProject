using System.Text.Json.Serialization;

namespace XPFinalProject.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }

        [JsonIgnore]
        public ICollection<PedidoModel>? Pedidos { get; set; }


    }
}
