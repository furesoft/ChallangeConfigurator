using System.IO;
using ChallangeConfigurator.Models;
using ChallangeConfigurator.Models.AdditionalInfos;
using LiteDB;
using Splat;

namespace ChallangeConfigurator;

//only to create a database for developement purpose
public class DebugDatabaseBuilder
{
    public static void Build()
    {
        var repository = Locator.Current.GetService<ILiteRepository>();

        foreach (var game in repository.Query<Game>().ToEnumerable())
        {
            game.AdditionalInfos = new();
            game.AdditionalInfos.Add(new LinkAdditionalInfo() { Label = "Youtube", URL = "https://youtube.com/" });

            repository.Update(game);
        }
    }   
}