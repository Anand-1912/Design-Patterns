using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsoleDay2
{
    internal class WordDocument
    {
        private string[] pages = null!;

        private WordDocument(int no_of_pages)
        {
            pages = new string[no_of_pages];
        }

        public static WordDocument CreateDocument(int withNoOfPages)
        {
            return new WordDocument(no_of_pages: withNoOfPages);
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < pages.Length)
                {
                    return pages[index];
                }
                else
                {
                    return "Invalid page number";
                }
            }
            set
            {
                if (index >= 0 && index < pages.Length)
                {
                    pages[index] = value;
                }
                else
                {
                    Console.WriteLine("Invalid page number");
                }
            }
        }

        public void ShowDocument()
        {
            for (int i = 0; i < pages.Length; i++)
            {
                Console.WriteLine(pages[i]);
            }
        }


    }
}
