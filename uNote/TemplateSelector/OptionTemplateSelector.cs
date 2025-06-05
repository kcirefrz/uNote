using uNote.Models;

namespace uNote.TemplateSelector;

public class OptionTemplateSelector : DataTemplateSelector
{
    public DataTemplate SimpleMenuItemTemplate { get; set; }

    public DataTemplate TitleMenuItemTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item != null && item is OptionItem optionItem)
        {
            if (optionItem.IsTitle)
            {
                return TitleMenuItemTemplate;
            }
        }
        return SimpleMenuItemTemplate;
    }
}