using AssignmentApp.Application.Interfaces;
using AssignmentApp.Core;
using AssignmentApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IMatchOddsRepository, MatchOddsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer("data source=DESKTOP-BK67UTD\\SQLEXPRESS; initial catalog=AssignmentApp; Integrated Security=true;MultipleActiveResultSets=True; App = EntityFramework"));

            return services;
        }
    }
}
