using DDDSample.Domain.Models.Todo.Entities;
using DDDSample.Domain.Models.Todo.Interfaces;
using DDDSample.Domain.Models.Todo.ValueObjects;
using DDDSample.Infrastructure.Todo;
using DDDSample.Wpf.Models;
using Microsoft.VisualBasic;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSample.Wpf.ViewModels
{
    public class MainWindowViewModel : IDisposable
    {
        private CompositeDisposable _disposables = [];

        private ITodoRepository _todoRepository;

        public MainWindowViewModel()
        {
            RegisterCommand.Subscribe(ExeRegisterCommand).AddTo(_disposables);
            _todoRepository = TodoFactory.CreateTodoRepository();
        }

        public ReactivePropertySlim<string> Title { get; } = new();
        public ReactivePropertySlim<string> Description { get; } = new();
        public ReactivePropertySlim<DateTime> Deadline { get; } = new();

        public ReactiveCollection<TodoModel> TodoModels { get; } = [];

        public ReactiveCommandSlim RegisterCommand { get; } = new();

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void ExeRegisterCommand()
        {
            var id = new TodoID();
            var title = new TodoTitle(Title.Value);
            var description = new TodoDescription(Description.Value);
            var deadline = new TodoDeadline(Deadline.Value);
            var status = new TodoStatus("1", "Normal");

            var entity = new TodoEntity(
                id,
                title,
                description,
                deadline,
                status);
            _todoRepository.Save(entity);

            var todoModel = new TodoModel
            {
                ID = id.Value.ToString(),
                Title = title.Value,
                Description = description.Value,
                Deadline = $"{deadline.Year}/{deadline.Month}/{deadline.Day}",
                Status = status.Name
            };

            TodoModels.Add(todoModel);
        }
    }
}
