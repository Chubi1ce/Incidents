using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsService
{
    public class AllInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string is_active { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
    public class UserInfo
    {
        public List<AllInfo> AllInfo { get; set; }
    }
}
