using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnuncioDeVeiculo.Models
{
    public class Anuncio
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Display(Name = "Versão")]
        public string Versao { get; set; }
        [Display(Name = "Ano")]
        public int Ano { get; set; }
        [Display(Name = "Quilometragem")]
        public int Quilometragem { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}