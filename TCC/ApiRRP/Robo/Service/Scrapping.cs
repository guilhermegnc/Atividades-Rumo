using HtmlAgilityPack;
using Robo.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


        // NO CÓDIGO ABAIXO É PEGO OS TITULOS E PRECOS DE LIVROS, ACABEI POR INICIALMENTE FAZER UMA COLETA DE DADOS DE 
        // TODAS AS CATEGORIAS DE LIVRO POR TODO O SITE, PORÉM O TEMPO DE PROCESSAMENTO ERA UM POUCO ALTO, ENTÃO 
        // ACABEI POR PEGAR APENAS UMA CATEGORIA QUE FOI A DE FANTASIA, QUE HAVIA UMA QUANTIDADE BOA DE LIVROS,
        // POREM DEIXEI TAMBEM A IMPLEMENTACAO PARA FAZER O SCRAPPING POR TODO O SITE, BASTA COLOCAR A VARIAVEL
        //BOLEANA NA CLASSE ABAIXO PARA TRUE


namespace Robo.Service
{
    public class Scrapping
    {
        static public List<Livros> ScrappingService()
        {
            var linksTiposDeLivros = GetTiposDeLivros("http://books.toscrape.com/index.html");

            bool ConsultarSiteTodo = false;

            List<string> linksLivros = new List<string>();

            if (ConsultarSiteTodo)
            {
                foreach (var urls in linksTiposDeLivros)
                {
                    var links = GetTiposDeLivros(urls, true);
                    foreach (var link in links)
                    {
                        linksLivros.Add(link);
                    }
                }
            }

            else
            {

                linksLivros = GetTiposDeLivros(linksTiposDeLivros[17], true);
            }



            var books = GetDetalhesLivros(linksLivros);
            return books;
        }
        
        static private HtmlDocument GetDocumento(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }

        static private HtmlNode Paginas(string url, HtmlDocument doc)
        {
            var proximaPagina = doc.DocumentNode.SelectSingleNode(".//ul/li[@class=\"next\"]/a");
            return proximaPagina;
        }

        static private List<string> GetTiposDeLivros(string url, bool ReadBookLinks = false)
        {
            var linksLivros = new List<string>();
            HtmlNodeCollection linkNodes;

            while (true)
            {
                HtmlDocument doc = GetDocumento(url);
                if (ReadBookLinks)
                {
                    linkNodes = doc.DocumentNode.SelectNodes("//h3/a");
                }

                else
                    linkNodes = doc.DocumentNode.SelectNodes("//ul/li/ul/li/a");

                var baseUri = new Uri(url);
                foreach (var link in linkNodes)
                {
                    string href = link.Attributes["href"].Value;
                    linksLivros.Add(new Uri(baseUri, href).AbsoluteUri);
                }

                if (ReadBookLinks)
                {
                    var proximaPagina = Paginas(url, doc);
                    if (proximaPagina == null) break;
                    else
                    {
                        // Para passar para próxima página, troca o final da url
                        var startPoint = url.LastIndexOf('/');
                        StringBuilder myStringBuilder = new StringBuilder(url);
                        myStringBuilder.Replace(url.Substring(startPoint + 1), proximaPagina.Attributes["href"].Value);
                        url = myStringBuilder.ToString();
                    }
                }
                else break;


            }

            return linksLivros;
        }

        static private List<Livros> GetDetalhesLivros(List<string> urls)
        {
            var livros = new List<Livros>();
            foreach (var url in urls)
            {
                HtmlDocument document = GetDocumento(url);
                var tituloXPath = "//h1";
                var precoXPath = "//div[contains(@class,\"product_main\")]/p[@class=\"price_color\"]";
                var livro = new Livros();

                livro.Titulo = HtmlEntity.DeEntitize(document.DocumentNode.SelectSingleNode(tituloXPath).InnerText);
                var Preco = HtmlEntity.DeEntitize(document.DocumentNode.SelectSingleNode(precoXPath).InnerText.Replace("£", ""));
                livro.Preco = Convert.ToDecimal(Preco.Remove(0, 1), new CultureInfo("en-US")) * CotacaoAtual.Consulta();

                if (livro.Titulo.Contains("Full Moon over "))
                    livro.Titulo = "Full Moon over Noah's Ark: An Odyssey to Mount Ararat and Beyond";

                livros.Add(livro);
            }
            return livros;
        }
    }
}
