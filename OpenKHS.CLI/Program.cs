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
            startup.Main.Load();
        }
    }
}
