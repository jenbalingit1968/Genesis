using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Core.Model
{
    public class ChapterModel
    {
        public string id { get; set; }
        public string bibleId { get; set; }
        public string bookId { get; set; }
        public string number { get; set; }
        public int position { get; set; }
    }
}
