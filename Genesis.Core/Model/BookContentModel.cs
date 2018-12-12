using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Core.Model
{
    public class BookContentResult
    {
        public List<BookContentModel> Data { get; set; }
    }

    public class BookContentModel
    {

        public string id { get; set; }
        public string bibleId { get; set; }
        public string abbreviation { get; set; }
        public string name { get; set; }
        public string nameLong { get; set; }

        public List<ChapterModel> chapters { get; set; }
    }
}
