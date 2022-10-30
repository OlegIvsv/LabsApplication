using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.AdoNet
{
    public abstract class BaseRepositoryAdo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly string connectionString;
        protected SqlConnection connection;



        public BaseRepositoryAdo(string connectionString) 
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(connectionString);
        }

        protected int Execute(string text, SqlParameter[]? parameters = null)
        {
            connection.Open();

            var command = new SqlCommand(text, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        protected IEnumerable<TEntity> ExecuteRead(string text, Func<IDataRecord, TEntity> converter, 
                                                                    SqlParameter[]? parameters = null)
        {
            connection.Open();

            var command = new SqlCommand(text, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            var result = new List<TEntity>();
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TEntity item = converter(reader);
                    result.Add(item);
                }
            }

            connection.Close();
            return result;
        }

        protected IEnumerable<TEntity> ExecuteRead(string text, Func<IDataRecord, TEntity> converter, 
                                     Func<TEntity, bool> predicate, SqlParameter[]? parameters = null)
        {
            connection.Open();

            var command = new SqlCommand(text, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            var result = new List<TEntity>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TEntity item = converter(reader);
                    if(predicate(item))
                        result.Add(item);
                }
            }

            connection.Close();
            return result;
        }

        public abstract void Delete(TEntity entity);

        public abstract void Delete(int id);

        public abstract TEntity Get(int id); 

        public abstract void Insert(TEntity entity);

        public abstract IList<TEntity> List();

        public abstract IList<TEntity> List(Func<TEntity, bool> expression);

        public abstract void Update(TEntity entity);
    }
}
