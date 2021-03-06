﻿namespace Orchestra.Modules.TextEditorModule.Views
{
    using Catel.Windows;

    using ViewModels;

    /// <summary>
    /// Interaction logic for PropertiesView.xaml.
    /// </summary>
    public partial class MapWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapWindow"/> class.
        /// </summary>
        public MapWindow()
            : base(DataWindowMode.OkCancel, null, DataWindowDefaultButton.OK, true, InfoBarMessageControlGenerationMode.Inline)
        {
            InitializeComponent();
        }
    }
}
