using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Core.Model
{

    public class Result
    {
        public List<BooksModel> Data { get; set; }
    }
    public class BooksModel
    {
        public string Id { get; set; }

        public string DblId { get; set; }

        public string RelatedDbl { get; set; }

        public string Name { get; set; }

        public string NameLocal { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }

        public string DescriptionLocal { get; set; }

        public Language Language { get; set; }

        public List<Countries> Countries { get; set; }

        public string Type { get; set; }
    }
}
