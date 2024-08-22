using System;

namespace SwapiMaui.Model;

public class ListItem
{
    public String Headline { get; set; }

    public String Subtitle { get; set; }

    public Film? Film { get; set; }

    public Person? Person { get; set; }

}
