using System.Collections.ObjectModel;
using System.ComponentModel;

namespace uNote;

public class SimpleNoteViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Note> notes = new ObservableCollection<Note>();

    public SimpleNoteViewModel()
    {
        Notes = new ObservableCollection<Note>
        {
            new (0, "Estudar MAUI dia #01", "Estou criando as classes", new DateTime(), null),
            new (1, "Teste sem Description", string.Empty, new DateTime(), null),
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
            }
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}