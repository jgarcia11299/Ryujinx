using Avalonia.Controls;
using Avalonia.Media;
using Ryujinx.UI.Common.Configuration;
using System;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class ContentDialogOverlayWindow : StyleableWindow
    {
        public ContentDialogOverlayWindow()
        {
            InitializeComponent();

            TransparencyLevelHint = new[] { WindowTransparencyLevel.Transparent };
            WindowStartupLocation = WindowStartupLocation.Manual;
            SystemDecorations = SystemDecorations.None;
            ExtendClientAreaTitleBarHeightHint = 0;
            Background = Brushes.Transparent;
            CanResize = false;
        }

         public void ToggleWarning(string warning)
        {
            _ = warning switch
            {
#pragma warning disable IDE0055 // Disable formatting
                "IgnoreKeysWarning"  => ConfigurationState.Instance.IgnoreKeysWarning.Value  = !ConfigurationState.Instance.IgnoreKeysWarning,
                _  => throw new ArgumentOutOfRangeException(warning),
#pragma warning restore IDE0055
            };

            ConfigurationState.Instance.ToFileFormat().SaveConfig(Program.ConfigurationPath);
        }
    }
}
