using Dapper;
using LatihanDapper.DbContext;
using LatihanDapper.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanDapper.Repository
{
    internal class SupplierRepository : RepositoryBase<Supplier>
    {
        public SupplierRepository(DapperDbContext Context, AdoDbContext adoDbContext) : base(Context, adoDbContext)
        {
        }

        public override void Delete(Supplier Entity)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Suppliers WHERE SupplierId=@custId AND CompanyName=@companyName AND ContactName=@contactName AND ContactTitle=@contactTitle;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@custId",
                        DataType = DbType.String,
                        Value =Entity.SupplierId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value =Entity.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value =Entity.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value =Entity.ContactTitle
                    }
                }
            };

            _context.ExecuteNonQuery(model);
            _context.Dispose();

            Console.WriteLine("Data Berhasil Dihapus");
        }

        public override IEnumerable<Supplier> FindAll()
        {

            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select SupplierId,CompanyName,ContactName,ContactTitle from suppliers",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            var dataSet = _adoDbContext.ExecuteReader<Supplier>(model);


            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                var item = dataSet.Current;
                yield return item;
            }


            _context.Dispose();
        }

        public override IEnumerable<Supplier> FindById(dynamic id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select SupplierId,CompanyName, ContactName,ContactTitle from Suppliers where SupplierId = @suppId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@suppId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = _adoDbContext.ExecuteReader<Supplier>(model);


            //selalu gunakan iterator tuk dapatkan value dari IEnumerator
            while (dataSet.MoveNext())
            {
                var employee = dataSet.Current;
                yield return employee;
            }


            _context.Dispose();

        }

    

        public override Supplier Save(Supplier Entity)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "insert into Suppliers (CompanyName,ContactName,ContactTitle) values (@companyName,@contactName,@contactTitle);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@supId",
                        DataType = DbType.Int32,
                        Value = Entity.SupplierId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = Entity.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = Entity.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = Entity.ContactTitle
                    }
                }
            };
            _context.ExecuteNonQuery(model);
            _context.Dispose();

            return Entity;

        }

        public override Supplier Update(Supplier Entity)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Suppliers SET CompanyName=@companyName, ContactName=@contactName, ContactTitle = @contactTitle WHERE SupplierId= @suppId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@suppId",
                        DataType = DbType.Int32,
                        Value = Entity.SupplierId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@companyName",
                        DataType = DbType.String,
                        Value = Entity.CompanyName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactName",
                        DataType = DbType.String,
                        Value = Entity.ContactName
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@contactTitle",
                        DataType = DbType.String,
                        Value = Entity.ContactTitle
                    }
                }
            };

            _context.ExecuteNonQuery(model);
            _context.Dispose();
            return Entity;
        }
    }
}
