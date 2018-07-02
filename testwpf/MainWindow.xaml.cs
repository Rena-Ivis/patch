using System;
using System.Windows.Forms; // !!!!! Лиза, wpf 
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel; // для ObservableCollection

using testwpf.whiskas;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace testwpf
{
    public partial class MainWindow
    {
        static public ObservableCollection<Product> listProduct = new ObservableCollection<Product>();
        static Dictionary<string, string> ID = new Dictionary<string, string>(16);

        public MainWindow()
        {

            InitializeComponent();

            // заполнение таблицы
            DataGrid1.ItemsSource = listProduct;
            getID.Go(CB, ID);
            // пурсер
            // через раз парсит, хз почему

            // иконка в трее
            IconTray.InitializeNotifyIcon(this, "tree.ico", new ToolStripItem[] { });

            // пример добавления в таблицу: listProduct.Add(new Product("kek1", "kek2", "kek3"));

            // BackgroundMode.Start( Purser.Start() , ... , ... , SendMail.Send); // TODO

            //...



            // events
        }
        void OnStateChanged(object sender, EventArgs args)
        {
            IconTray.ev(args);
        }

        private void CB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listProduct = new ObservableCollection<Product>(Purser.Start(ID[CB.SelectedValue.ToString()], Prod.Text));
        }
    }
}
