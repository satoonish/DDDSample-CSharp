using DDDSample.Wpf.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Wpf.ViewModels
{
    public class MainWindowViewModel
    {
        public ReactiveCollection<TodoModel> TodoModels { get; set; } = [];
    }
}
