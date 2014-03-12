using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ef6.Recipe1
{
    class Class1
    {
        public static void Run()
        {
            using (var context = new EF6RecipesEntities1())
            {
                var poet = new Poet { FirstName = "nisar", LastName = "khan" };
                var poem = new Poem { Title = "sky paradise" };
                var meter = new Meter { MeterName = "Isamic bar" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);
                poem = new Poem {Title ="Pradise Regain" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                poet = new Poet { FirstName="Lewis",LastName="Carrol" };
                poem = new Poem { Title="The Hunting of the shark"};
                meter = new Meter { MeterName="Anapestic Terameter" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                poet = new Poet { FirstName="Lord",LastName="Byron" };
                poem = new Poem { Title="Don Juan"};
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                context.SaveChanges();
            }

            using (var context = new EF6RecipesEntities1())
            {
                var poets = context.Poets;
                foreach(var poet in poets)
                {
                    Console.WriteLine("{0} {1}", poet.FirstName, poet.LastName);
                    foreach (var poem in poet.Poems)
                    {
                        Console.WriteLine("\t{0} ({1})",poem.Title,poem.Meter.MeterName);
                    }
                }
            }
            Console.WriteLine("-------------------------------------------------------");
            //using vwlibry
            using (var context = new EF6RecipesEntities1())
            {
                var items = context.vwLibraries;
                foreach (var item in items)
                {
                    Console.WriteLine("{0} {1}",item.FirstName,item.LastName);
                    Console.WriteLine("\t{0} ({1})",item.Title,item.MeterName);
                }
            }
        }
    }
}
