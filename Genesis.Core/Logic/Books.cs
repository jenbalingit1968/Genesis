using Genesis.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Genesis.Core.Logic
{
    public class Books
    {
        private readonly string CachedTextFilePath;
        private readonly Api.Books books;
        public Books()
        {
            CachedTextFilePath = $"{Environment.CurrentDirectory}\\Cahed.txt";
            books = new Api.Books();
        }

        public async Task<bool> CachedBookToTextFile()
        {
            if (!File.Exists(CachedTextFilePath))
            {
                using (var tw = new StreamWriter(CachedTextFilePath, true))
                {
                    var get = await books.GetAllBooks();
                    tw.WriteLine(get);
                }
            }
            else {
                File.Delete(CachedTextFilePath);
                using (var tw = new StreamWriter(CachedTextFilePath, true))
                {
                    var get = await books.GetAllBooks();
                    tw.WriteLine(get);
                }
            }
            return true;
        }

        public List<BooksModel> ReadCahedBooks
        {
            get
            {

                string text = File.ReadAllText(CachedTextFilePath);

                return JsonConvert.DeserializeObject<List<BooksModel>>(text);
            }
        }
    }
}
