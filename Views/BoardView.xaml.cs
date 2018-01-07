using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessRPG.Views
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        public BoardView()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    Task.Factory.StartNew(new Action(() =>
            //    {
            //        Thread.Sleep(500);
            //        App.Current.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            if (e.LeftButton == MouseButtonState.Pressed)
            //            {
            //                var data = new DataObject();
            //                data.SetData("Source", (sender as Button).Content);
            //                DragDrop.DoDragDrop(sender as DependencyObject, data, DragDropEffects.Move);
            //                e.Handled = true;
            //            }
            //        }), null);
            //    }), CancellationToken.None);
            //}
        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            //var source = e.Data.GetData("Source") as string;
            //if (source != null)
            //{
            //    int newIndex = listview.Items.IndexOf((sender as Button).Content);
            //    var list = listview.ItemsSource as ObservableCollection<string>;
            //    list.RemoveAt(list.IndexOf(source));
            //    list.Insert(newIndex, source);
            //}
        }
    }
}
