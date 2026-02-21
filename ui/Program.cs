using Gdk;

var application = Adw.Application.New("com.antevere.Gtk4DotNetSample", Gio.ApplicationFlags.FlagsNone);

application.OnActivate += async (sender, args) =>
{
    var application = (Adw.Application)sender;
    
    // Uncomment to apply custom theme.
    //ApplyCSS();

    var uiPath = System.IO.Path.Combine(AppContext.BaseDirectory, "main.ui");
    var ui = Gtk.Builder.NewFromFile(uiPath);

    var window = ui.GetObject("window") as Gtk.Window;
    application.AddWindow(window!);    

    var listBox = ui.GetObject("list") as Gtk.ListBox;

    var items = new List<string>();

    for (var i = 0; i < 10000; i++)
    {
        items.Add($"List Box Item {i}");
    }

    var listStore = Gio.ListStore.New(Gtk.Label.GetGType());

    foreach (var t in items)
    {
        listStore.Append(Gtk.Label.New(t));
    }

    listBox!.BindModel(listStore, (item) =>
    {
        return item as Gtk.Widget ?? Gtk.Label.New("");
    });

    window!.Show();
};

return application.RunWithSynchronizationContext(null);

static void ApplyCSS()
{
    var customCss = Gtk.CssProvider.New();

    customCss.LoadFromString("window {background: unset;}");

    Gtk.StyleContext.AddProviderForDisplay(
        Display.GetDefault()!,
        customCss,
        1000
    );
}