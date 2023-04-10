﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Lab_5_10333
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Shape shape;

        public MainWindow()
        {
            InitializeComponent();
            CommandBinding commandBindingHelp = new CommandBinding();
            commandBindingHelp.Command = ApplicationCommands.Help;
            commandBindingHelp.Executed += Help;
            menuItemHelp.CommandBindings.Add(commandBindingHelp);
            iconHelp.CommandBindings.Add(commandBindingHelp);

            CommandBinding commandBindingSave = new CommandBinding();
            commandBindingSave.Command = ApplicationCommands.Save;
            commandBindingSave.Executed += Save;
            commandBindingSave.CanExecute += Save_CanExecute;
            menuItemSave.CommandBindings.Add(commandBindingSave);

            CommandBinding commandBindingOpen = new CommandBinding();
            commandBindingOpen.Command = ApplicationCommands.Open;
            commandBindingOpen.Executed += Open;
            menuItemLoad.CommandBindings.Add(commandBindingOpen);

            CommandBinding commandBindingExit = new CommandBinding();
            commandBindingExit.Command = ApplicationCommands.Close;   
            commandBindingExit.Executed += Close;
            menuItemClose.CommandBindings.Add(commandBindingExit);
            iconClose.CommandBindings.Add(commandBindingExit);
        }


        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (shape != null);
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (shape == null) return;
            shape.Save();
        }

        private void Open(object sender, ExecutedRoutedEventArgs e)
        {
            
            shape = Shape.Load();
        }

        private void Help(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Справка о приложении!");
        }

        private void Close(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void MenuItemShape_Click(object sender, RoutedEventArgs e)
        {
            WindowShape windowShape = new WindowShape();
            if (windowShape.ShowDialog() == false) return;
            shape = windowShape.getShape();
            // MessageBox.Show(shape.ToString());
            
            
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (shape == null) return;
            shape.draw(canvas, e.GetPosition(canvas));
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            textBlockCursorPosition.Text = $"X = {e.GetPosition(canvas).X} Y = {e.GetPosition(canvas).Y}";
        }

    }
}
