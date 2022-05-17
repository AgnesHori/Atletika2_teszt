using Atletika2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;


namespace Atletika2
{
    public partial class MainWindow : Window
    {
        private AppDbContext _appDbContext;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            using(_appDbContext = new AppDbContext())
            {
                cbHelyszin.ItemsSource = _appDbContext.Helyszinek.ToList();
                cbVersenyzo.ItemsSource = _appDbContext.Versenyzok.ToList();
            }
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            Eredmenyek data = (Eredmenyek) DataContext;

            try
            {
                using (_appDbContext = new AppDbContext())
                {
                    Eredmenyek record = _appDbContext.Eredmenyek.Single(x => x.VersId == data.VersId && x.HelyId == data.HelyId);

                    record.Versenyszam = data.Versenyszam;

                    _appDbContext.SaveChanges();

                    MessageBox.Show("Sikeres módosítás", "", MessageBoxButton.OK);

                    data.Versenyszam = string.Empty;
                    cbHelyszin.SelectedIndex = -1;
                    cbVersenyzo.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem volt sikeres a módosítás", "", MessageBoxButton.OK);
            }
        }

        private void OnExportClick(object sender, RoutedEventArgs e)
        {
            List<Eredmenyek> eredmenyek = null;

            using (_appDbContext = new AppDbContext())
            {
                eredmenyek = _appDbContext.Eredmenyek
                                          .Include(x => x.Helyszin)
                                          .Include(x => x.Versenyzo)
                                          .ToList();
            }

            List<string> kimenet = new List<string>();
            string sor = string.Empty;

            foreach (Eredmenyek eredmeny in eredmenyek)
            {
                sor = $" {eredmeny.Versenyzo.Nev}\t {eredmeny.Helyszin.Ev}\t {eredmeny.Helyszin.Orszag}\t {eredmeny.Helyszin.Varos}\t{eredmeny.Versenyszam}\t{(eredmeny.Helyezes.HasValue ? eredmeny.Helyezes : 0)}";

                kimenet.Add(sor);
            }

            File.WriteAllLines("eredmenyek.txt", kimenet);
            MessageBox.Show("Sikeres export", "", MessageBoxButton.OK);
        }
    }

}
