using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using bd.vienkiemsoat.web.data.Interfaces;

namespace bd.vienkiemsoat.web.data
{
    public class DataModule:Autofac.Module
    {
        string _connectionString;
        public DataModule(string connectionString) {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.Register(c => new ApplicationIdentityContext(this._connectionString)).As<DbContext>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
