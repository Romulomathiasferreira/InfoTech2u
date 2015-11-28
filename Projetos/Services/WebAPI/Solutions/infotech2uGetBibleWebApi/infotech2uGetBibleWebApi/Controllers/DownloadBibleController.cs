using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using infotech2uGetBibleWebApi.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace infotech2uGetBibleWebApi.Controllers
{
    public class DownloadBibleController : ApiController
    {
        public HttpResponseMessage Get(string idBook, string initialsBook, string amountChapterBook, string amountVerseBook, string idVersionBook, string nameFile, string versionDownload)
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
                        HtmlDocument doc = web.Load("https://www.bibliaonline.com.br/"+ versionDownload + "/" + initialsBook + "/" + countAmountChapterBook);
                        var output = doc.DocumentNode.SelectNodes("//div[@id='ChapterView']//span");
                        HtmlWeb web2 = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument htmldoc = web2.Load("https://www.bibliaonline.com.br/" + versionDownload + "/" + initialsBook + "/" + countAmountChapterBook);
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

                var json = JsonConvert.SerializeObject(listVerse);
                var result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StringContent(json, Encoding.UTF8, "application/json");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = initialsBook+nameFile+".json"
                };

                return result;
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
