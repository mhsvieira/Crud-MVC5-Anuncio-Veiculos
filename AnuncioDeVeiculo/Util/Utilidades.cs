using AnuncioDeVeiculo.API;
using AnuncioDeVeiculo.Models;
using AnuncioDeVeiculo.ViewModels;
using System.Linq;

namespace AnuncioDeVeiculo.Util
{
    public class Utilidades
    {
        public Anuncio ConverteParaAnuncio(AnuncioViewModel anuncioViewModel)
        {
            anuncioViewModel.Marca = GetMarcaById(anuncioViewModel.MarcaId);

            anuncioViewModel.Modelo = GetModeloById(anuncioViewModel.MarcaId, anuncioViewModel.ModeloId);

            anuncioViewModel.Versao = GetVersaoById(anuncioViewModel.ModeloId, anuncioViewModel.VersaoId);

            var anuncio = new Anuncio()
            {
                Id = anuncioViewModel.Id,
                Marca = anuncioViewModel.Marca,
                Modelo = anuncioViewModel.Modelo,
                Versao = anuncioViewModel.Versao,
                Ano = anuncioViewModel.Ano,
                Quilometragem = anuncioViewModel.Quilometragem,
                Observacao = anuncioViewModel.Observacao
            };

            return anuncio;
        }

        public AnuncioViewModel ConverteParaAnuncioViewModel(Anuncio anuncio)
        {
            var apiAcess = new APIAccess();

            var marca = apiAcess.GetMarcas().FirstOrDefault(x => x.Name == anuncio.Marca);

            int marcaId = marca != null ? marca.ID : 0;

            var modelo = apiAcess.GetModelos(marcaId).FirstOrDefault(x => x.Name == anuncio.Modelo);

            var modeloId = modelo != null ? modelo.ID : 0;

            var versao = apiAcess.GetVersoes(modeloId).FirstOrDefault(x => x.Name == anuncio.Versao);

            var versaoId = versao != null ? versao.ID : 0;


            var anuncioViewModel = new AnuncioViewModel()
            {
                Id = anuncio.Id,
                MarcaId = marcaId,
                Marca = anuncio.Marca,
                ModeloId = modeloId,
                Modelo = anuncio.Modelo,
                VersaoId = versaoId,
                Versao = anuncio.Versao,
                Ano = anuncio.Ano,
                Quilometragem = anuncio.Quilometragem,
                Observacao = anuncio.Observacao
            };

            return anuncioViewModel;
        }

        public string GetMarcaById(int MarcaId)
        {
            var apiAcess = new APIAccess();

            var marca = apiAcess.GetMarcas().FirstOrDefault(x => x.ID == MarcaId);

            return marca != null ? marca.Name : string.Empty;
        }

        public string GetModeloById(int MarcaId, int ModeloId)
        {
            var apiAcess = new APIAccess();

            var modelo = apiAcess.GetModelos(MarcaId).FirstOrDefault(x => x.ID == ModeloId);

            return modelo != null ? modelo.Name : string.Empty;
        }

        public string GetVersaoById(int ModeloId, int VersaoId)
        {
            var apiAcess = new APIAccess();

            var versao = apiAcess.GetVersoes(ModeloId).FirstOrDefault(x => x.ID == VersaoId);

            return versao != null ? versao.Name : string.Empty;
        }
    }
}