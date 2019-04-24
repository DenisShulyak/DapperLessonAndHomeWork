using Dl.DataAccessAbstract;
using Dl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;


namespace Dl.DataAccess
{
  public class MailsRepository : IRepository<Mail>
    {
        private DbConnection _connection;

        public MailsRepository()
        {
            var connectionString = ConfigurationManager
                   .ConnectionStrings["appConnection"].ConnectionString;

            _connection = new SqlConnection(connectionString);
        }

        public void Add(Mail item)
        {
            var sqlQuery = "insert into Mails (Id,CreationDate,DeletedDate,Thems,Text,RecieverId,SenderId) values (@Id,@CreationDate,@DeletedDate,'@Thems','@Text',@RecieverId,@SenderId)";
            var result = _connection.Execute(sqlQuery, item);
            if (result < 1) throw new Exception("Запись не вставлена");
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public ICollection<Mail> GetAll()
        {
            var sqlQuery = "select * from Mails";
            return _connection.Query<Mail>(sqlQuery).AsList();
        }

        public void Update(Mail item)
        {
            throw new NotImplementedException();
        }
    }
}
