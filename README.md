# How-to-Manage-Chip-Overflow-with-Auto-Sizing-in-SfChipGroup-Using-FlexLayout-in-.NET-MAUI
This repository contains a sample explaining How to Manage Chip Overflow with Auto-Sizing in SfChipGroup Using FlexLayout in .NET MAUI

To achieve Auto-Sizing in SfChipGroup, the FlexLayout is used as the ChipLayout, and each chip is placed inside a `HorizontalStackLayout` within the [ItemTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Core.SfChipGroup.html#Syncfusion_Maui_Core_SfChipGroup_ItemTemplate), which helps maintain individual widths for the chips.

**Step 1: Define ChipGroup with FlexLayout and Wrap Property**

The ChipGroup uses a `FlexLayout` to arrange the chips. Set the Wrap property of the FlexLayout to "Wrap" to ensure chips are wrapped correctly and maintain their individual size.

**XAML:**

```
<chip:SfChipGroup ItemsSource="{Binding Employees}">
    <chip:SfChipGroup.ChipLayout>
        <FlexLayout Wrap="Wrap"/>
    </chip:SfChipGroup.ChipLayout>
    <chip:SfChipGroup.ItemTemplate>
        <DataTemplate>
            <HorizontalStackLayout>
                <chip:SfChip Text="{Binding Name}" />
            </HorizontalStackLayout>
        </DataTemplate>
    </chip:SfChipGroup.ItemTemplate>
</chip:SfChipGroup>
```

- **FlexLayout:** The Wrap="Wrap" property ensures that when the screen width is full, chips will wrap to the next line, preventing overflow.
- **HorizontalStackLayout:** Each SfChip is placed inside a HorizontalStackLayout to maintain auto-sizing behavior based on the text length.

**Step 2: Add Items to ChipGroup**

The [ItemsSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Core.SfChipGroup.html#Syncfusion_Maui_Core_SfChipGroup_ItemsSource){target="_blank"} property is bound to the collection (in this case, Employees), which provides the list of chips to display. The Text property of each SfChip is set to the Name property of each Employee object.

**C#:**

```
public class ViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Person> employees;

    public ObservableCollection<Person> Employees
    {
        get { return employees; }
        set { employees = value; OnPropertyChanged("Employees"); }
    }

    public ViewModel()
    {
        employees = new ObservableCollection<Person>();
        employees.Add(new Person() { Name = "Johnathan Alexander" });
        employees.Add(new Person() { Name = "Jameson William" });
        employees.Add(new Person() { Name = "Linda-Marie Johnson" });
        employees.Add(new Person() { Name = "Rosemary Thompson" });
        employees.Add(new Person() { Name = "Jameson Michael" });
        employees.Add(new Person() { Name = "Jameson Lee" });
        employees.Add(new Person() { Name = "Jameson Carter" });
        employees.Add(new Person() { Name = "Jameson Thomas" });
        employees.Add(new Person() { Name = "Markus Theodore" });
        employees.Add(new Person() { Name = "Elizabeth Grace" });
    }
}
```

**Step 3: Test the Chip Overflow Behavior**

As you add more items to the ItemsSource, the chips should maintain their `auto-sizing` behavior and wrap to the next line once they reach the edge of the parent container.

**Output:**

![Screenshot_20250228_081424.jpg](https://support.bolddesk.com/kb/agent/attachment/article/19413/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjM5MjgyIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5ib2xkZGVzay5jb20ifQ.pb5qFfY3noczdblj3fZfuDC1wGg3oKf41QHtRWVcX9Q)
