using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace KnowledgeAccountingSystem
{
    public class DependencyResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IUserRepository>().To<UserRepository>();

            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectRepository>().To<ProjectRepository>();

            Bind<IKnowledgeFormService>().To<KnowledgeFormService>();
            Bind<IKnowledgeFormRepository>().To<KnowledgeFormRepository>();

            Bind<IReportRepository>().To<ReportRepository>();
            Bind<IReportService>().To<ReportService>();
        }
    }
}