﻿using System.IO;
using Avalonia.Media.Imaging;
using LiteDB;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace ChallangeConfigurator.Core;

public class NamedImageModel : BaseNameModel
{
    [BsonIgnore]
    public Bitmap Image { get; set; }

    public void LoadImage()
    {
        var ms = new MemoryStream();
        var databaseFileStorage = Locator.Current.GetService<ILiteRepository>().Database.FileStorage;

        if (Image != null || !databaseFileStorage.Exists(_id.ToString()))
        {
            return;
        }
        
        databaseFileStorage.Download(_id.ToString(), ms);

        ms.Seek(0, SeekOrigin.Begin);
        Image = new Bitmap(ms);
    }
}