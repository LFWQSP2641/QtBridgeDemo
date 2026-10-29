using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Qt.Quick;
using System.Security.Cryptography;

namespace QtBridgeDemo;

[QmlElement(Name = "Counter", Singleton = true)]
public partial class CounterService : ObservableObject
{
    [ObservableProperty]
    public partial int Clicks { get; set; }

    public readonly StringListModel Items = new();
    //public readonly ObservableCollection<string> Items = [];

    public void AddRandomItem()
    {
        var item = $"Item {RandomNumberGenerator.GetInt32(1, 100)}";
        Items.Add(item);
    }
}

public class StringListModel : Qt.Bridge.Models.ListModel<string>
{
    private readonly List<string> _items = [];

    public override int ItemCount()
    {
        return _items.Count;
    }

    public override string Data(int index)
    {
        return _items[index];
    }

    public void Add(string item)
    {
        Insert(_items.Count, item);
    }

    public void Insert(int index, string item)
    {
        BeginInsertItems(index, index);
        _items.Insert(index, item);
        EndInsertItems();
    }

    public void Remove(int index)
    {
        BeginRemoveItems(index, index);
        _items.RemoveAt(index);
        EndRemoveItems();
    }

    public void Clear()
    {
        BeginRemoveItems(0, _items.Count - 1);
        _items.Clear();
        EndRemoveItems();
    }
}

public class Program
{
    internal static void Main(string[] args)
    {
        Qml.LoadFromRootModule("Main");
        Qml.WaitForExit();
    }
}
