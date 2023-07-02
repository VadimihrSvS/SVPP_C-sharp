﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SVPP_Lab9.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Func<object, bool> canExecute;
        private Action<object> executeMethod;

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecute)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }   

        public RelayCommand(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            executeMethod(parameter);
        }
    }
}
