using System.ComponentModel;
using uNote.Interfaces;

namespace uNote.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public ViewModelBase(INoteService service)
    {
        Service = service;
    }

    public INoteService Service { get; set; }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}