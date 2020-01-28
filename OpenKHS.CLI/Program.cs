using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var factory = startup.Kernel.Get<IDbContextFactory>();
            using (var context = factory.Create())
            {
                var tmp = new LocalCongregationMember
                {
                    Name = "test name"
                };
                context.Add(tmp);
                context.SaveChanges();
            }
        }
    }
}
