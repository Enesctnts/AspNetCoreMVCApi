using AspNetCoreMVCApi_EL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMVCApi_DAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }
        //Tablolara ait sanal dbsetler
        public virtual DbSet<Assignment> Assignments { get; set; }
    }



}
