using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnuncioDeVeiculo.ViewModels
{
    public class AnuncioViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "MarcaId")]
        public int MarcaId { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Display(Name = "ModeloId")]
        public int ModeloId { get; set; }
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Display(Name = "VersaoId")]
        public int VersaoId { get; set; }
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