using System;
using System.Linq;
using System.Threading.Channels;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using F12XA6_HFT_2022231.Repository;

namespace F12XA5_HFT_2022231.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameDbContext ctx = new GameDbContext();
            ctx.Games.ToList().ForEach(t => Console.WriteLine(t.GameTitle +"\t"+ t.PublisherStudioId +"\t"+ t.Id));
            //ctx.Developers.ToList().ForEach(t => Console.WriteLine(t.Company +"\t"+t.DevName));

            DevStudioRepository studiorepo = new DevStudioRepository(ctx);
            DeveloperRepository deverepo = new DeveloperRepository(ctx);

            GameRepository gamerepo = new GameRepository(ctx); 
            GameLogic logic = new GameLogic(gamerepo);
           var a = logic.GameCountByStudio();
            ;
        }
    }
}
