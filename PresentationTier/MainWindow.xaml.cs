using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTier;
using LogicTier;
using Microsoft.Win32;

namespace PresentationTier;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public partial class MainWindow : Window
{
    private Университет университет;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btn_open_file_Click(object sender, RoutedEventArgs e)
    {
        List<Преподаватель> преподаватели = ВсеПреподаватели.ПолучитьВсеПреподавателиИзФайла();

        if (преподаватели == null || преподаватели.Count == 0)
        {
            MessageBox.Show("Не удалось загрузить данные или файл пуст!", "Ошибка",
                          MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        университет = new Университет(преподаватели);
        this.DataContext = университет;

        // Заполняем ListView для групп
        GroupsListView.ItemsSource = университет.СуммарныеЗадолженностиПоГруппам()
            .Select(x => new { Key = x.Key, Value = x.Value })
            .ToList();

        // Заполняем ListView для курсов
        CoursesListView.ItemsSource = университет.СредниеЗадолженностиПоКурсам()
            .Select(x => new { Key = x.Key, Value = x.Value.ToString("F2") }) // Форматируем до 2 знаков после запятой
            .ToList();
    }

    // Добавляем свойство для привязки в XAML
    public int ОбщееКоличествоПреподавателей
    {
        get { return университет?.СписокПреподавателей?.Count ?? 0; }
    }
}


