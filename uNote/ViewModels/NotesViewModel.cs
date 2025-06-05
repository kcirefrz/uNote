using System.Collections.ObjectModel;
using System.ComponentModel;
using uNote.Models;

namespace uNote;

public class NoteViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Note> notes;
    private ObservableCollection<OptionItem> optionItems;

    public NoteViewModel()
    {
        Notes = new ObservableCollection<Note>
        {
            new (0, "Estudar MAUI dia #01", "Estou criando as classes", new DateTime(), null),
            new (1, "Teste sem Description", string.Empty, new DateTime(), null),
        };

        OptionItems = new ObservableCollection<OptionItem>
        {
            new ("Private", true, null, null),
            new ("Option Example 01", false, null, null),
        };
        // TEST PRA PEGAR DE ENUM (GetValues<TipoSerial>().ToList())
    }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

    public ObservableCollection<Note> Notes
    {
        get => notes;
        set
        {
            if (notes == value)
            {
                return;
                OnPropertyChanged(nameof(Notes));
            }
        }
    }

    public ObservableCollection<OptionItem> OptionItems
    {
        get => optionItems;
        set
        {
            if (optionItems == value)
            {
                return;
                OnPropertyChanged(nameof(OptionItems));
            }
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}