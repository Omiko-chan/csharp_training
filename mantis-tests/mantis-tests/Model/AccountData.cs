using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_user_table")]
    public class AccountData
    {
        [Column(Name ="id")]
        public int Id { get; set; }
        [Column(Name= "username")]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public static List<AccountData> GetAll()
        {
            using (BugtrackerDB db = new BugtrackerDB())
            {
                return (from a in db.Accounts select a).ToList();
            }
        }


    }
}
