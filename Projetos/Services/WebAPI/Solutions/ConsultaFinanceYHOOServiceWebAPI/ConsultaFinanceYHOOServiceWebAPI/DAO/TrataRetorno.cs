using ConsultaFinanceYHOOServiceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace ConsultaFinanceYHOOServiceWebAPI.DAO
{
    public class TrataRetorno
    {
        public Indice TratarRetorno(XPathDocument doc)
        {
            DataSet ds = new DataSet();
            List<Indice> Indices = new List<Indice>();
            Indice indice;
            XPathNavigator navigator = doc.CreateNavigator();

            XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);
            ns.AddNamespace("finance", "http://finance.yahoo.com");
            XPathNodeIterator nodes = navigator.Select("/list/resources/resource/field", ns);

            indice = new Indice();
            while (nodes.MoveNext())
            {
                XPathNavigator node = nodes.Current;


                switch (node.GetAttribute("name", ns.DefaultNamespace))
                {
                    case "change":
                        indice.change = node.Value;
                        break;
                    case "chg_percent":
                        indice.chg_percent = node.Value;
                        break;
                    case "day_high":
                        indice.day_high = node.Value;
                        break;
                    case "day_low":
                        indice.day_low = node.Value;
                        break;
                    case "issuer_name":
                        indice.issuer_name = node.Value;
                        break;
                    case "issuer_name_lang":
                        indice.issuer_name_lang = node.Value;
                        break;
                    case "name":
                        indice.name = node.Value;
                        break;
                    case "price":
                        indice.price = node.Value;
                        break;
                    case "symbol":
                        indice.symbol = node.Value;
                        break;
                    case "ts":
                        indice.ts = node.Value;
                        break;
                    case "type":
                        indice.type = node.Value;
                        break;
                    case "utctime":
                        indice.utctime = node.Value;
                        break;
                    case "volume":
                        indice.volume = node.Value;
                        break;
                    case "year_high":
                        indice.year_high = node.Value;
                        break;
                    case "year_low":
                        indice.year_low = node.Value;
                        break;
                }
            }
            Indices.Add(indice);

            return indice;
        }
    }
}