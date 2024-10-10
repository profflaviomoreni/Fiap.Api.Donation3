using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.Donation3.Models
{
    public class CategoriaModel
    {

        public int CategoriaId { get; set; }

        [Required]
        public string NomeCategoria { get; set; }


    }
}
