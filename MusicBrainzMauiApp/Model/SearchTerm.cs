using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMauiApp.Model
{
    public class SearchQuery
    {
        public string SearchTermExpr { get; set; }
        public int limit { get; set; }
        public int Offset { get; set; }
    }
}
