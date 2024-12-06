using DDDSample.Domain.Models.Todo.Entities;
using DDDSample.Domain.Models.Todo.Interfaces;
using DDDSample.Domain.Models.Todo.ValueObjects;
using DDDSample.Infrastructure.Todo;
using DDDSample.Wpf.Models;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

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
            UnregisterCommand.Subscribe(ExeUnregisterCommand).AddTo(_disposables);
        }

        public ReactivePropertySlim<string> Title { get; } = new();
        public ReactivePropertySlim<string> Description { get; } = new();
        public ReactivePropertySlim<DateTime> Deadline { get; } = new();

        public ReactiveCollection<TodoModel> TodoModels { get; } = [];
        public ReactivePropertySlim<TodoModel> SelectedItem { get; } = new();

        public ReactiveCommandSlim RegisterCommand { get; } = new();
        public ReactiveCommandSlim UnregisterCommand { get; } = new();

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

        private void ExeUnregisterCommand()
        {
            if (SelectedItem.Value == null) { return; }

            var id = new TodoID(SelectedItem.Value.ID);
            _todoRepository.DeleteByID(id);

            var model = TodoModels.FirstOrDefault(x => x.ID == SelectedItem.Value.ID);
            TodoModels.Remove(model);
        }
    }
}
