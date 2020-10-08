using Autofac;
using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.service.Interfaces;
using System.Data.Entity;

namespace bd.vienkiemsoat.web.service
{
    public class ServiceModule : Module
    {
        string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ApplicationIdentityContext(this._connectionString)).As<DbContext>().InstancePerRequest();
            builder.RegisterModule(new data.DataModule(_connectionString));
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterType<CosoService>().As<ICosoService>();
            builder.RegisterType<ReportCrystalService>().As<IReportService>();
            

            base.Load(builder);
        }
    }
}
