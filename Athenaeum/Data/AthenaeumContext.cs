using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Data
{
    public class AthenaeumContext : DbContext
    {
        public AthenaeumContext(DbContextOptions<AthenaeumContext> options)
            :base (options)
        {

        }

    }
}
