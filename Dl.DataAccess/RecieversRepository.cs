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
    public class RecieversRepository : IRepository<Reciever>
    {
        private DbConnection _connection;
        
        public RecieversRepository()
        {
            var connectionString = ConfigurationManager
                   .ConnectionStrings["appConnection"].ConnectionString;

            _connection = new SqlConnection(connectionString);
        }

        public void Add(Reciever item)
        {
            var sqlQuery = "insert into Recievers (Id,CreationDate,DeletedDate,FullName,Address) values (@Id,@CreationDate,@DeletedDate,'@FullName','@Address')";
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

        public ICollection<Reciever> GetAll()
        {
            var sqlQuery = "select * from Recievers";
            return _connection.Query<Reciever>(sqlQuery).AsList();
        }

        public void Update(Reciever item)
        {
            throw new NotImplementedException();
        }
    }
}
