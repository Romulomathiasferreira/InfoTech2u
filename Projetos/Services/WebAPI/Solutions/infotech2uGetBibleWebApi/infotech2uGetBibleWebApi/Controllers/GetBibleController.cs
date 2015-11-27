using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using infotech2uGetBibleWebApi.Models;
using HtmlAgilityPack;

namespace infotech2uGetBibleWebApi.Controllers
{
    public class GetBibleController : ApiController
    {
        public HttpResponseMessage Get(string idBook, string initialsBook, string amountChapterBook, string amountVerseBook, string idVersionBook)
        {
            try
            {
                List<Verse> listVerse = new List<Verse>();
                Verse verse;

                int count = 0;
                if (!String.IsNullOrWhiteSpace(amountChapterBook))
                {
                    for (int countAmountChapterBook = 1; countAmountChapterBook <= Convert.ToInt32(amountChapterBook); countAmountChapterBook++)
                    {
                        int countAmountVerseBook = 0;
                        string xpath = "";
                        HtmlWeb web = new HtmlWeb();
                        HtmlDocument doc = web.Load("https://www.bibliaonline.com.br/nvi/" + initialsBook + "/" + countAmountChapterBook);
                        var output = doc.DocumentNode.SelectNodes("//div[@id='ChapterView']//span");
                        HtmlWeb web2 = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument htmldoc = web2.Load("https://www.bibliaonline.com.br/nvi/" + initialsBook + "/" + countAmountChapterBook);
                        htmldoc.OptionFixNestedTags = true;
                        var navigator = (HtmlNodeNavigator)htmldoc.CreateNavigator();

                        foreach (var item in output)
                        {
                            verse = new Verse();
                            count++;
                            countAmountVerseBook++;
                            xpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/article[1]/div[1]/p[" + countAmountVerseBook + "]/span[1]";
                            verse.Id = count;
                            verse.IdBook = Convert.ToInt32(idBook);
                            verse.IdChapter = countAmountChapterBook;
                            verse.IdVerse = countAmountVerseBook;
                            verse.TextVerse = navigator.SelectSingleNode(xpath).Value;
                            listVerse.Add(verse);
                        }
                        countAmountVerseBook = 0;
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, listVerse); ;
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possível Capturar o livro: " + initialsBook);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }
}
