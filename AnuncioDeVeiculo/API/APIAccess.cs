using AnuncioDeVeiculo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AnuncioDeVeiculo.API
{
    public class APIAccess
    {
        public readonly string baseURL = "http://desafioonline.webmotors.com.br/api/OnlineChallenge";

      
        public List<Marca> GetMarcas()
        {
            var listaMarcas = new List<Marca>();

            
            // acessa a API
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(baseURL + "/Make").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(" - Erro: Não foi possível recuperar as marcas de veículos do serviço.");
                }

                string resultJSON = response.Content.ReadAsStringAsync().Result;

                listaMarcas.AddRange(JsonConvert.DeserializeObject<Marca[]>(resultJSON).ToList());

                return listaMarcas;
            }
        }

        public List<Modelo> GetModelos(int MakeID)
        {
            var listaModelos = new List<Modelo>();

            if (MakeID == 0)
                return listaModelos;


            // acessa a API
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(baseURL + string.Format("/Model?MakeID={0}", MakeID)).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(" - Erro: Não foi possível recuperar os modelos dos veículos do serviço.");
                }

                string resultJSON = response.Content.ReadAsStringAsync().Result;

                listaModelos.AddRange(JsonConvert.DeserializeObject<Modelo[]>(resultJSON).ToList()); 

                return listaModelos;
            }
        }


        public List<Versao> GetVersoes(int ModelID)
        {
            var listaVersoes = new List<Versao>();

            if (ModelID == 0)
                return listaVersoes;


            // acessa a API
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(baseURL + string.Format("/Version?ModelID={0}", ModelID)).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(" - Erro: Não foi possível recuperar as versões dos veículos do serviço.");
                }

                string resultJSON = response.Content.ReadAsStringAsync().Result;

                listaVersoes.AddRange(JsonConvert.DeserializeObject<Versao[]>(resultJSON).ToList());

                return listaVersoes;
            }
        }
    }
}