using Autofac;
using AutoMapper;
using DataAccess.AutoMapper;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ClassroomRepository>().As<IClassroomRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HumanResourcesRepository>().As<IHumanResourcesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);

        }
    }
}
