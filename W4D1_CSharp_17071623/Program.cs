using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using W4D1_CSharp_17071623.Data;
using W4D1_CSharp_17071623.Model;

namespace W4D1_CSharp_17071623
{       

    class Program
    {

        /**
         * 1. Laad Artiest met instrument en popgroep
         * 2. Print op console
         */
       
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                
                DbSeeder.SeedDatabase(context);

                //Queries.ShowArtiest(context);
                //Queries.ShowPopgroep(context, "Popgroep1");
                //Queries.ShowWieInstrumentSpeelt(context, "Gitaar");
                //Queries.ShowGroteBands(context);
                Queries.ShowBandsMetSaxofoonSpeler(context);

                //Queries.Test(context);
            }
        }
    }
}
