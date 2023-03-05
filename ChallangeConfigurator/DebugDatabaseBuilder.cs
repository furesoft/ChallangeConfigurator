using System.IO;
using ChallangeConfigurator.Models;
using LiteDB;
using Splat;

namespace ChallangeConfigurator;

//only to create a database for developement purpose
public class DebugDatabaseBuilder
{
    public static void Build()
    {
        var repository = Locator.Current.GetService<LiteRepository>();

        for (int i = 0; i < 5; i++)
        {
            var game = new Challange();
            game._id = ObjectId.NewObjectId();
            game.Name = "Challange " + i;

            repository.Insert(game);
        }
    }   
}