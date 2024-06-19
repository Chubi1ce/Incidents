using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsService
{
    public class Tokens
    {
        public Access access { get; set; }
        public refresh refresh { get; set; }
    }
    public class Access
    {
        public string token { get; set; }
        public string expired_at { get; set; }
    }
    public class refresh
    {
        public string token { get; set; }
        public string expired_at { get; set; }
    }
    public class RootTokens
    {
        public List<Tokens> Tokens { get; set; }
    }
}
