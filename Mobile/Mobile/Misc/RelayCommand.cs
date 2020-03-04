using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GoldDigger.Mobile.Misc
{
    //public class RelayCommand : ICommand
    //{
    //    public delegate void CallbackHandler(object parameter = null);
    //    public event CallbackHandler Callback;

    //    public Predicate<object> Enable { get; set; }

    //    public RelayCommand()
    //    {
    //        Callback += RelayCommand_Callback;
    //    }

    //    private void RelayCommand_Callback(object parameter = null)
    //    {
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return Enable == null ? true : Enable(parameter);
    //    }

    //    public void Execute(object parameter = null)
    //    {
    //        Callback(parameter);
    //    }
    //}

    //public class RelayCommand<T> : ICommand
    //{
    //    public delegate void CallbackHandler(T parameter);
    //    public event CallbackHandler Callback;

    //    public Predicate<object> Enable { get; set; }

    //    public RelayCommand()
    //    {
    //        Callback += RelayCommand_Callback;
    //    }

    //    private void RelayCommand_Callback(T parameter)
    //    {
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return Enable == null ? true : Enable(parameter);
    //    }

    //    public void Execute(object parameter)
    //    {
    //        Callback((T)parameter);
    //    }
    //}
}
