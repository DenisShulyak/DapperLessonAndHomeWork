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
    public class SendersRepository : IRepository<Sender>
    {
        private DbConnection _connection;
        public SendersRepository()
        {
            var connectionString = ConfigurationManager
                  .ConnectionStrings["appConnection"].ConnectionString;

            _connection = new SqlConnection(connectionString);
        }

        public void Add(Sender item)
        {
            var sqlQuery = "insert into Senders (Id,CreationDate,DeletedDate,FullName,Address) values (@Id,@CreationDate,@DeletedDate,'@FullName','@Address')";
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

        public ICollection<Sender> GetAll()
        {
            var sqlQuery = "select * from Senders";
            return _connection.Query<Sender>(sqlQuery).AsList();
        }

        public void Update(Sender item)
        {
            throw new NotImplementedException();
        }
    }
}
