using CommunityToolkit.Mvvm.ComponentModel;
using Qt.Quick;

namespace QtBridgeDemo;

[QmlElement(Name = "Counter", Singleton = true)]
public partial class CounterService : ObservableObject
{
    [ObservableProperty]
    public partial int Clicks { get; set; }
}

public class Program
{
    internal static void Main(string[] args)
    {
        Qml.LoadFromRootModule("Main");
        Qml.WaitForExit();
    }
}
