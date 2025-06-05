using Microsoft.Maui.Controls.Shapes;

namespace uNote.Models;

public class OptionItem
{
    public OptionItem(string optionName, bool isTitle, Geometry? optionIcon, Image? optionImage)
    {
        OptionName = optionName;
        IsTitle = isTitle;
        OptionIcon = optionIcon;
        OptionImage = optionImage;
    }

    public string OptionName { get; set; }

    public bool IsTitle { get; set; }

    public Geometry? OptionIcon { get; set; }

    public Image? OptionImage { get; set; }
}