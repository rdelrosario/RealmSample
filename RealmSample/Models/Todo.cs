using System;
using Realms;

namespace RealmSample.Models
{
    public class Todo: RealmObject
    {
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }

    }
}
