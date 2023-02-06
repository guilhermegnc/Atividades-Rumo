using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


        //PEGA A COTAÇÃO ATUAR DE EURO PARA REAL, JÁ QUE O SITE ONDE ESTÁ SENDO FEITO O SCRAPPING O PREÇO DOS PRODUTOS
        //ESTA EM EURO. A COTAÇÃO É PEGA DE UMA API QUE ACHEI NA INTERNET

namespace Robo.Service
{
    public static class CotacaoAtual
    {
        public static decimal Consulta()
        {
            var json = new HttpClient().GetStringAsync("https://economia.awesomeapi.com.br/last/EUR-BRL").Result;

            var data = (JObject)JsonConvert.DeserializeObject(json);
            var address = data.SelectToken(
               "EURBRL.ask").Value<string>();

            return Convert.ToDecimal(address, new CultureInfo("en-US"));
        }
    }
}
