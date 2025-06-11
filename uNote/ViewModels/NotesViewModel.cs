using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using uNote.Interfaces;
using uNote.Models;

namespace uNote.ViewModels;

public class NotesViewModel : INotifyPropertyChanged
{
    private readonly INoteService noteService;
    private readonly IUserService userService;
    private ObservableCollection<NoteItem> notes;
    private ObservableCollection<User> users;
    private NoteItem selectedNote;
    private User selectedUser;

    public NotesViewModel(INoteService noteService, IUserService userService)
    {
        this.noteService = noteService;
        this.userService = userService;

        Notes = new ObservableCollection<NoteItem>();
        Users = new ObservableCollection<User>();

        // SE NAO TIVER NADA NAS TABELAS, DEIXA COMENTADO PARA NAO ESTOURAR EXCEÇÃO
        // NAO EH BOM FICAR LENDO TODOS OS DADOS DEPENDENDO DA QUANTIDADE DE DADOS
        // TaskLoadNotes();
        // TaskLoadUsers();
    }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

    public ICommand NewPage { get; set; }

    public ICommand RenamePageTitle { get; set; }

    public ICommand DeletePage { get; set; }

    public ObservableCollection<NoteItem> Notes
    {
        get => notes;
        set
        {
            if (notes == value)
            {
                return;
            }

            notes = value;
            OnPropertyChanged(nameof(Notes));
        }
    }

    public ObservableCollection<User> Users
    {
        get => users;
        set
        {
            if (users == value)
            {
                return;
            }

            users = value;
            OnPropertyChanged(nameof(Users));
        }
    }

    public NoteItem SelectedNote
    {
        get => selectedNote;
        set
        {
            if (selectedNote == value)
            {
                return;
            }

            selectedNote = value;
            OnPropertyChanged(nameof(SelectedNote));
        }
    }

    public User SelectedUser
    {
        get => selectedUser;
        set
        {
            if (selectedUser == value)
            {
                return;
            }

            selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async Task TaskLoadNotes(INoteService noteService)
    {
        var dbNotes = await noteService.GetAllNotesAsync();
        Notes = new ObservableCollection<NoteItem>(dbNotes);
    }

    private async Task TaskLoadUsers(IUserService userService)
    {
        var dbUsers = await userService.GetAllUsersAsync();
        Users = new ObservableCollection<User>(dbUsers);
    }

    private async Task TaskNewPage(object? sender, EventArgs e)
    {
        // if (string.IsNullOrWhiteSpace())
        // {

        // }

        // await database.SaveItemAsync()
    }

    private async Task SaveNote()
    {
        if (SelectedNote == null) return;

        await noteService.SaveNoteAsync(SelectedNote);
        TaskLoadNotes(noteService);
        SelectedNote = null;
    }

    private async Task SaveUser()
    {
        if (SelectedUser == null) return;

        await userService.SaveUserAsync(SelectedUser);
        TaskLoadUsers(userService);
        SelectedUser = null;
    }

    private async Task DeleteNote()
    {
        await noteService.Initialize();
        if (SelectedNote == null) return;

        var response = await App.Current.MainPage.DisplayAlert("Alert!", "Confirm delete?", "Yes", "No");

        if (response)
            await noteService.DeleteNoteAsync(SelectedNote);

        await TaskLoadNotes(noteService);

        Notes.Remove(SelectedNote);
        SelectedNote = null;
    }

    private async Task DeleteUser()
    {
        await userService.Initialize();
        if (SelectedUser == null) return;

        var response = await App.Current.MainPage.DisplayAlert("Alert!", "Confirm delete?", "Yes", "No");

        if (response)
            await userService.DeleteUserAsync(SelectedUser);

        await TaskLoadUsers(userService);

        Users.Remove(SelectedUser);
        SelectedUser = null;
    }
}