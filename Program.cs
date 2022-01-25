using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int timer = 50;

            await PrintSkippableMessage.Print("Ala ma kota a Ania ma psa fajnego jakiegoś...\n", timer);
            await PrintSkippableMessage.Print("Niestety kot Ali i pies Ani nie lubią się...\n", timer);
            await PrintSkippableMessage.Print("Dlatego ciągle ze sobą walczą...\n", timer);
        }

        
    }
}