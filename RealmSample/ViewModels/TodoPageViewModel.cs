using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using Realms;
using RealmSample.Models;
using Xamarin.Forms;

namespace RealmSample.ViewModels
{
    public class TodoPageViewModel
    {
        public ICommand DeleteTodoCommand { get; set; }
        public ICommand AddTodoCommand { get; set; }
        public ICommand UpdateTodoCommand { get; set; }

        Realm _realm;
        public IEnumerable<Todo> Todos { get; private set; }

        public TodoPageViewModel()
        {
            _realm = Realm.GetInstance();
            Todos = _realm.All<Todo>();

            AddTodoCommand = new Command(async()=>
            {
                var result= await UserDialogs.Instance.PromptAsync("Insert text", "Todo");
                if(result.Ok && !string.IsNullOrEmpty(result.Text)){
                    _realm.Write(() =>
                    {
                        var entry = new Todo { Date = DateTimeOffset.Now, Text =result.Text };
                        _realm.Add(entry);
                    });
                }
               
            });

            DeleteTodoCommand = new Command<Todo>((param) =>
            {
                using (var trans = _realm.BeginWrite())  
                {  
                    _realm.Remove(param);
                    trans.Commit();  
                }  


            });

            UpdateTodoCommand= new Command<Todo>(async(param) =>
            {
                var result = await UserDialogs.Instance.PromptAsync("Insert text", "Todo");
                if (result.Ok && !string.IsNullOrEmpty(result.Text))
                {
                    _realm.Write(() =>
                    {
                        param.Text = result.Text;
                        _realm.Add(param);
                    });
                }
               
            });

        }
    }
}
