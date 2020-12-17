namespace TaskAssistant
{
    using System.Windows;
    using DBTaskAssistant;
    using DBTaskAssistant.ViewModels;
    using TaskAssistantForms;

    /// <summary>
    /// Class that adds logic to Main View.
    /// </summary>
    public partial class MainView : Window
    {
        private User currentUser = new User();
        private MainVM viewmodel;

        public MainView(User loggedUser)
        {
            InitializeComponent();
            currentUser = loggedUser;
            DataContext = new MainVM(loggedUser);
            viewmodel = (MainVM)DataContext;
        }

        private void AddButt_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            this.Effect = objBlur;
            AddTask addTask = new AddTask(currentUser, viewmodel.Tasks);
            addTask.ShowDialog();
            this.Effect = null;
        }

        private void DeleteButt_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.Delete();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserEdit_Click(object sender, RoutedEventArgs e)
        {
            Ed_Account ed_Account = new Ed_Account(currentUser);
            this.Close();
            ed_Account.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            this.Effect = objBlur;
            AddTask addTask = new AddTask(currentUser, viewmodel.Tasks,viewmodel.CurrTask);
            addTask.ShowDialog();
            this.Effect = null;
        }

        private void SortBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (SortBox.SelectedIndex)
            {
                case 0:
                    viewmodel.SortByPriority();
                    break;
                case 1:
                    viewmodel.SortByTime();
                    break;
                default:
                    break;
            }
        }
    }
}
