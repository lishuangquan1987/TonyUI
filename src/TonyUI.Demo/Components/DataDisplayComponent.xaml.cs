using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace TonyUI.Demo.Components;

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string City { get; set; } = string.Empty;
}

public partial class DataDisplayComponent : UserControl
{
    public DataDisplayComponent()
    {
        InitializeComponent();
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        var sampleData = new ObservableCollection<Person>
        {
            new Person { Name = "John Doe", Age = 30, City = "New York" },
            new Person { Name = "Jane Smith", Age = 25, City = "Los Angeles" },
            new Person { Name = "Bob Johnson", Age = 35, City = "Chicago" },
            new Person { Name = "Alice Williams", Age = 28, City = "Houston" },
            new Person { Name = "Charlie Brown", Age = 32, City = "Phoenix" }
        };

        sampleDataGrid.ItemsSource = sampleData;
    }
}