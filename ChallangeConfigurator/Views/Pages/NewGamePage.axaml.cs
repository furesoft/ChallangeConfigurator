using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.ReactiveUI;
using ChallangeConfigurator.ViewModels.Pages;
using ReactiveUI;

namespace ChallangeConfigurator.Views.Pages;

public partial class NewGamePage : ReactiveUserControl<NewGamePageViewModel>
{
    public NewGamePage()
    {
        this.WhenActivated(disposables => { });

        InitializeComponent();
        
        AddHandler(DragDrop.DropEvent, Drop);
        AddHandler(DragDrop.DragOverEvent, DragOver);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void DragOver(object sender, DragEventArgs e)
    {
        // Only allow Copy or Link as Drop Operations.
        e.DragEffects &= (DragDropEffects.Copy | DragDropEffects.Link);

        // Only allow if the dragged data contains text or filenames.
        if (!e.Data.Contains(DataFormats.Text)
            && !e.Data.Contains(DataFormats.FileNames))
        {
            e.DragEffects = DragDropEffects.None;
        }
    }

    private void Drop(object sender, DragEventArgs e)
    {
        if (e.Data.Contains(DataFormats.FileNames))
        {
            var filename = e.Data.GetFileNames().First();

            ViewModel.Game.ImageFilename = filename;
            ViewModel.Image = new Bitmap(filename);
            ViewModel.HasImageSet = true;
        }
    }
}