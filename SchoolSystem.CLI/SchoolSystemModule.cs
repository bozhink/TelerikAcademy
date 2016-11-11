namespace SchoolSystem.Cli
{
    using System;
    using System.IO;
    using System.Reflection;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using Ninject.Modules;
    using SchoolSystem.Cli.Configuration;
    using SchoolSystem.Cli.Interceptors;
    using SchoolSystem.Framework.Core.Commands;
    using SchoolSystem.Framework.Core.Commands.Contracts;
    using SchoolSystem.Framework.Core.Contracts;
    using SchoolSystem.Framework.Core.Providers;
    using SchoolSystem.Framework.Data;
    using SchoolSystem.Framework.Data.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Data.Repositories;

    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = nameof(CreateStudentCommand);
        private const string CreateTeacherCommandName = nameof(CreateTeacherCommand);
        private const string RemoveStudentCommandName = nameof(RemoveStudentCommand);
        private const string RemoveTeacherCommandName = nameof(RemoveTeacherCommand);
        private const string StudentListMarksCommandName = nameof(StudentListMarksCommand);
        private const string TeacherAddMarkCommandName = nameof(TeacherAddMarkCommand);

        public override void Load()
        {
            this.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommandName);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommandName);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommandName);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommandName);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommandName);

            this.Bind<IReader>()
                .To<ConsoleReaderProvider>();

            this.Bind<IWriter>()
                .To<ConsoleWriterProvider>();

            this.Bind<IParser>()
                .To<CommandParserProvider>();

            this.Bind<ISchoolDbContext>()
                .To<SchoolDatabase>()
                .InSingletonScope();

            this.Bind<ITeacherRepository>()
                .To<Teachers>()
                .InSingletonScope();

            this.Bind<IStudentRepository>()
                .To<Students>()
                .InSingletonScope();

            this.Bind<IStudentFactory>()
                .ToFactory()
                .InSingletonScope()
                .Intercept()
                .With<TimerInterceptor>();

            this.Bind<ITeacherFactory>()
                .ToFactory()
                .InSingletonScope();

            this.Bind<IMarkFactory>()
                .ToFactory()
                .InSingletonScope()
                .Intercept()
                .With<TimerInterceptor>();

            this.Bind<ICommandFactory>()
                .To<CommandsFactory>()
                .Intercept()
                .With<TimerInterceptor>();

            this.Bind<Func<Type, ICommand>>()
                .ToMethod(context => t => (ICommand)context.Kernel.Get(t));

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}
