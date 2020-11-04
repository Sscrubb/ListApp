using ListApp.Models;
using ListApp.Services;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ListApp.Views
{
    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\ListAppModels.json";
        private BindingList<ListAppModels> _listAppModels;
        private FileIOService _fileIOService;
        public NotesView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _listAppModels = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            dgListApp.ItemsSource = _listAppModels;
            _listAppModels.ListChanged += _listAppModels_ListChanged;
        }

        private void _listAppModels_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }
    }
}
