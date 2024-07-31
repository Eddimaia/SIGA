using MudBlazor;
using MudBlazor.Utilities;

namespace SIGA.Web.Themes;

/// <summary>
/// <seealso cref="https://coolors.co/palette/353535-3c6e71-ffffff-d9d9d9-284b63"/> Default Light Theme Palette
/// </summary>

public static class ThemeProvider
{
    public static MudTheme Default => new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = new MudColor("#ECECEC"),
            PrimaryContrastText = new MudColor("#ffffff"),
            Secondary = new MudColor("#284b63"),
            Background = new MudColor("#F6F6F6"),
            AppbarBackground = new MudColor("#284b63"),
            AppbarText = Colors.Shades.White,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = new MudColor("#8A9CA8")
        },
        PaletteDark = new PaletteDark
        {
            Primary = new MudColor("#ECECEC"),
            Secondary = Colors.Gray.Darken2,
            Background = new MudColor("#363939"),
            AppbarBackground = new MudColor("#363939"),
            AppbarText = Colors.Shades.White,
            TextPrimary = Colors.Shades.White,
            DrawerText = Colors.Gray.Lighten1,
            PrimaryContrastText = new MudColor("#000000"),
            DrawerBackground = new MudColor("#284b63"),
            Surface = new MudColor("#3E4444")
        }
    };
}
