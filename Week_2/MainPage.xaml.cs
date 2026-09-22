using System.Collections.ObjectModel;

namespace Week_2
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ToDo> toDoList = new ObservableCollection<ToDo>();
        public MainPage()
        {
            InitializeComponent();
            tasksCollectionView.ItemsSource = toDoList;
        }

        private void addTaskButton_Clicked(object sender, EventArgs e)
        {
            if (titleEntry.Text == string.Empty)
            {
                DisplayAlertAsync("Error", "Please enter a title for the task.", "OK");
                return;
            }

            var toDo = new ToDo
            {
                Title = titleEntry.Text,
                Description = descriptionEntry.Text,
                DueDate = dueDateEntry.Date,
                IsUrgent = urgentSwitch.IsToggled
            };

            toDoList.Add(toDo);
            DisplayAlertAsync("Added", "Object have been added.", "OK");

            titleEntry.Text = string.Empty;
            descriptionEntry.Text = string.Empty;
            dueDateEntry.Date = DateTime.Now;
            urgentSwitch.IsToggled = false;
        }

        private void deleteTaskButton_Clicked(object sender, EventArgs e)
        {
            if (tasksCollectionView.SelectedItem == null)
            {
                DisplayAlertAsync("Error", "Please select a task to delete.", "OK");
                return;
            }

            if (tasksCollectionView.SelectedItem is ToDo selectedTask)
            {
                toDoList.Remove(selectedTask);
            }
        }

        private void tasksCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tasksCollectionView.SelectedItem == null)
            {
                deleteTaskButton.IsEnabled = false;
            }
            else
            {
                deleteTaskButton.IsEnabled = true;
            }
        }
    }
}
