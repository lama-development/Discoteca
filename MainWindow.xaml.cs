using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Pila_Discoteca
{
    public partial class MainWindow : Window
    {
        int AscoltiHipHop = 0;
        int AscoltiLatino = 0;
        int AscoltiRock = 0;
        int AscoltiTotali = 0;
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                // all'avvio del programma, tutte le ComboBox e i bottoni sono disabilitati
                HipHopComboBox.IsEnabled = false;
                HipHopButton.IsEnabled = false;

                LatinoComboBox.IsEnabled = false;
                LatinoButton.IsEnabled = false;

                RockComboBox.IsEnabled = false;
                RockButton.IsEnabled = false;

                // creazione delle pile di tipo string
                Stack<string> PilaHipHop = new Stack<string>();
                Stack<string> PilaLatino = new Stack<string>();
                Stack<string> PilaRock = new Stack<string>();

                // aggiunta alle pile dei titoli delle canzoni
                PilaHipHop.Push("Rapper's Delight");
                PilaHipHop.Push("The Message");
                PilaHipHop.Push("Fight the Power");
                PilaHipHop.Push("Tha Crossroads");
                PilaHipHop.Push("Juicy");
                PilaHipHop.Push("Get Low");
                PilaHipHop.Push("Paper Planes");
                PilaHipHop.Push("Empire State of Mind");
                PilaHipHop.Push("Slow Down");

                PilaLatino.Push("Bonito y Sabroso");
                PilaLatino.Push("Mas Que Nada");
                PilaLatino.Push("Oye Como Va");
                PilaLatino.Push("El Periódico de Ayer");
                PilaLatino.Push("Plástico");
                PilaLatino.Push("La Negra Tomasa");
                PilaLatino.Push("Querida");
                PilaLatino.Push("La Incondicional");

                PilaRock.Push("What A Fool Believes");
                PilaRock.Push("Lonely Is the Night");
                PilaRock.Push("I Don't Care Anymore");
                PilaRock.Push("Heartbeat");
                PilaRock.Push("Peace of Mind");
                PilaRock.Push("Burning Heart");
                PilaRock.Push("Fortunate Son");
                PilaRock.Push("We Built This City");
                PilaRock.Push("Carry On Wayward Son");
                PilaRock.Push("Radio Ga Ga");

                // scorro le pile e aggiungo alla rispettiva ComboBox il titolo della canzone
                // METODO TIPO
                foreach (string elemento in PilaHipHop)
                    HipHopComboBox.Items.Add(elemento);

                // METODO OBJECT
                foreach (object o in PilaLatino)
                    LatinoComboBox.Items.Add(o);

                // METODO ENUMERATOR
                IEnumerator e = PilaRock.GetEnumerator();
                while (e.MoveNext())
                    RockComboBox.Items.Add(e.Current);

                // Calcolo del numero delle canzoni presenti nelle pila di ogni genere
                CanzoniHipHopLabel.Content = PilaHipHop.Count;
                CanzoniLatinoLabel.Content = PilaLatino.Count;
                CanzoniRockLabel.Content = PilaRock.Count;
                // Calcolo del numero delle canzoni totali
                CanzoniTotaliLabel.Content = PilaHipHop.Count + PilaLatino.Count + PilaRock.Count;

                // Inserisco di default nella ComboBox la prima canzone nella lista di ciascun genere
                HipHopComboBox.SelectedItem = PilaHipHop.Peek();
                LatinoComboBox.SelectedItem = PilaLatino.Peek();
                RockComboBox.SelectedItem = PilaRock.Peek();
            }
            catch
            {
                MessageBox.Show("Si è verificato un errore nel programma.", "Discoteca", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HipHop_Checked(object sender, RoutedEventArgs e)
        {
            // La ComboBox e il bottone del genere interessato si abiliteranno
            HipHopComboBox.IsEnabled = true;
            HipHopButton.IsEnabled = true;

            // Mentre quelle degli altri 2 generi saranno disabilitate
            LatinoComboBox.IsEnabled = false;
            LatinoButton.IsEnabled = false;

            RockComboBox.IsEnabled = false;
            RockButton.IsEnabled = false;

        }
        private void Latino_Checked(object sender, RoutedEventArgs e)
        {
            // La ComboBox e il bottone del genere interessato si abiliteranno
            LatinoComboBox.IsEnabled = true;
            LatinoButton.IsEnabled = true;

            // Mentre quelle degli altri 2 generi saranno disabilitate
            HipHopComboBox.IsEnabled = false;
            HipHopButton.IsEnabled = false;

            RockComboBox.IsEnabled = false;
            RockButton.IsEnabled = false;
        }
        private void Rock_Checked(object sender, RoutedEventArgs e)
        {
            // La ComboBox e il bottone del genere interessato si abiliteranno
            RockComboBox.IsEnabled = true;
            RockButton.IsEnabled = true;

            // Mentre quelle degli altri 2 generi saranno disabilitate
            HipHopComboBox.IsEnabled = false;
            HipHopButton.IsEnabled = false;

            LatinoComboBox.IsEnabled = false;
            LatinoButton.IsEnabled = false;
        }

        private void HipHopComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void LatinoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void RockComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void HipHopButton_Click(object sender, RoutedEventArgs e)
        {
            // Al click del bottone, aumento il numero degli ascolti del genere e quelli totali
            AscoltiHipHop++;
            AscoltiTotali++;

            // Aggiorno le label con i valori appena calcolati
            AscoltiHipHopLabel.Content = AscoltiHipHop;
            AscoltiTotaliLabel.Content = AscoltiTotali;

            // Se al click del bottone supero il contatore degli ascolti degli altri due generi...
            if (AscoltiHipHop > AscoltiLatino && AscoltiHipHop > AscoltiRock)
            {
                // ...aggiorno la label del genere preferito con il genere corrente
                GenerePreferitoLabel.Content = "Hip Hop";
            }

        }
        private void LatinoButton_Click(object sender, RoutedEventArgs e)
        {
            // Al click del bottone, aumento il numero degli ascolti del genere e quelli totali
            AscoltiLatino++;
            AscoltiTotali++;

            // Aggiorno le label con i valori appena calcolati
            AscoltiLatinoLabel.Content = AscoltiLatino;     
            AscoltiTotaliLabel.Content = AscoltiTotali;

            // Se al click del bottone supero il contatore degli ascolti degli altri due generi...
            if (AscoltiLatino > AscoltiHipHop && AscoltiLatino > AscoltiRock)
            {
                // ...aggiorno la label del genere preferito con il genere corrente
                GenerePreferitoLabel.Content = "Latino";
            }
        }

        private void RockButton_Click(object sender, RoutedEventArgs e)
        {
            // Al click del bottone, aumento il numero degli ascolti del genere e quelli totali
            AscoltiRock++;
            AscoltiTotali++;

            // Aggiorno le label con i valori appena calcolati
            AscoltiRockLabel.Content = AscoltiRock;
            AscoltiTotaliLabel.Content = AscoltiTotali;

            // Se al click del bottone supero il contatore degli ascolti degli altri due generi...
            if (AscoltiRock > AscoltiHipHop && AscoltiRock > AscoltiLatino)
            {
                // ...aggiorno la label del genere preferito con il genere corrente
                GenerePreferitoLabel.Content = "Rock";
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}