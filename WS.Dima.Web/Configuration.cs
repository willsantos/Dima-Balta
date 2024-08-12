﻿using MudBlazor;
using MudBlazor.Utilities;

namespace WS.Dima.Web;

public static class Configuration
{
    public static MudTheme Theme = new MudTheme()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Ralway", "sans-serif"]
            }
        },
        Palette = new PaletteLight
        {
            //Usei diferentes meios de definir as cores para registrar as possibilidades
            Primary = new MudColor("#1EFA2D"),
            Secondary  = Colors.LightGreen.Darken3,
            Background = Colors.Grey.Lighten4,
            AppbarBackground = "#1EFA2D",
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightGreen.Lighten4
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.LightGreen.Accent3,
            Secondary = Colors.LightGreen.Accent3,
            AppbarBackground =  Colors.LightGreen.Accent3,
            AppbarText = Colors.Shades.Black
        }
    };
}