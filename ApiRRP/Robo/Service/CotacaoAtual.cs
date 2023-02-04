using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
