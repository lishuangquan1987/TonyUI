# TonyUI

TonyUI is a modern WPF control library that implements the popular shadcn/ui design system for .NET applications. It provides beautiful, accessible, and customizable UI components that follow the shadcn/ui design principles.

## Features

- 🎨 **Beautiful Design**: Modern shadcn/ui-inspired components with consistent styling
- 🌈 **Theme Support**: Runtime theme switching with multiple built-in themes (Zinc, Slate, Stone, Gray, Neutral, and more)
- 🔧 **Customizable**: Highly customizable components with easy styling
- 📱 **Responsive**: Adapts to different screen sizes and resolutions
- 🛠️ **Accessible**: Built with accessibility in mind
- 🚀 **Performance**: Optimized for smooth performance
- 🔌 **Framework Support**: Compatible with .NET Framework 4.7.2+, .NET Core 3.1+, .NET 5+, .NET 6, .NET 7, and .NET 8

## Getting Started

### Prerequisites

- .NET Framework 4.7.2 or higher, or .NET Core 3.1 or higher
- Visual Studio 2019 or higher (recommended)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/TonyUI.git
   ```

2. Build the solution:
   ```bash
   cd TonyUI
   dotnet build
   ```

### Using the Demo

The project includes a comprehensive demo application that showcases all available components:

1. Navigate to the demo directory:
   ```bash
   cd src/TonyUI.Demo
   ```

2. Run the demo:
   ```bash
   dotnet run
   ```

The demo includes:
- Sidebar navigation with categorized components
- Live theme switching capabilities
- Interactive examples for each component type

## Architecture

### Project Structure

```
TonyUI/
├── src/
│   ├── TonyUI.Core/          # Core library with styles and components
│   │   ├── Themes/           # XAML theme resources
│   │   │   ├── Colors/       # Color palettes for different themes
│   │   │   ├── Brushes/      # Brush definitions
│   │   │   ├── Styles/       # Component styles
│   │   │   └── ThemeResources.xaml # Main theme resource dictionary
│   │   ├── Helpers/          # Helper classes and attached properties
│   │   └── Managers/         # Utility managers (ThemeManager, etc.)
│   └── TonyUI.Demo/          # Demo application
└── README.MD
```

### Key Components

#### Theme Management
- **ThemeManager**: Singleton manager for runtime theme switching
- **Attached Properties**: ControlHelper provides extension properties for enhanced functionality
- **Resource Dictionaries**: Organized XAML resources for colors, brushes, and styles

#### Available Themes
- Zinc (default)
- Slate
- Stone
- Gray
- Neutral
- Red
- Rose
- Orange
- Green
- Blue
- Yellow
- Violet

## Usage

### Applying Themes

```csharp
using TonyUI.Managers;

// Initialize theme manager
ThemeManager.Instance.Initialize();

// Apply a specific theme
ThemeManager.Instance.ApplyTheme(ThemeType.Slate);
```

### Using Components

The library provides various components that can be styled using the built-in resource dictionaries. Simply include the theme resources in your application:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="/TonyUI;component/Themes/ThemeResources.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### Custom Styling

All components can be customized using the available styles and brushes:

```xml
<Button Style="{StaticResource PrimaryButtonStyle}">Click Me</Button>
<TextBlock Style="{StaticResource Heading2Style}">Heading</TextBlock>
<Border Style="{StaticResource CardStyle}">Content</Border>
```

## Development

### Building the Project

1. Ensure you have the .NET SDK installed
2. Clone the repository
3. Build the solution:
   ```bash
   dotnet build
   ```

### Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Project Goals

- **Maintainability**: Clean, well-organized code structure
- **Reusability**: Modular components that can be easily reused
- **shadcn/ui Style Restoration**: High fidelity implementation of shadcn/ui design principles
- **Runtime Theme Switching**: Dynamic theme switching capabilities

## Components

The library includes a wide range of components:

- **Buttons**: Primary, secondary, outline, destructive, ghost, link styles
- **Inputs**: TextBox, PasswordBox, ComboBox, CheckBox, RadioButton
- **Navigation**: Menu, TabControl, TreeView, Expander
- **Layout**: Card, GroupBox, ScrollViewer, ProgressBar
- **Data Display**: DataGrid, ListView, Label, TextBlock styles
- **Feedback**: Dialog, Tooltip, ContextMenu
- **Pickers**: DatePicker, Calendar

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Inspired by [shadcn/ui](https://ui.shadcn.com/)
- Built for the .NET community
- Designed with accessibility and usability in mind

## Support

If you encounter any issues or have questions, please file an issue on the GitHub repository.