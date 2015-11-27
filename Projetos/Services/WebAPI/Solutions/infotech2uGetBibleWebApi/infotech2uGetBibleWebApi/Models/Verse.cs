using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infotech2uGetBibleWebApi.Models
{
    public class Verse
    {
        private int id;
        private int idVerse;
        private int idChapter;
        private int idBook;
        private string textVerse;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int IdVerse
        {
            get
            {
                return idVerse;
            }

            set
            {
                idVerse = value;
            }
        }

        public int IdChapter
        {
            get
            {
                return idChapter;
            }

            set
            {
                idChapter = value;
            }
        }

        public int IdBook
        {
            get
            {
                return idBook;
            }

            set
            {
                idBook = value;
            }
        }

        public string TextVerse
        {
            get
            {
                return textVerse;
            }

            set
            {
                textVerse = value;
            }
        }
    }
}
