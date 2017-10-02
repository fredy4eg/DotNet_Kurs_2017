using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace UserManager
{
    public class MainViewModel : DependencyObject
    {
        public ICollectionView UserList
        {
            get { return (ICollectionView)GetValue(UserListProperty); }
            set { SetValue(UserListProperty, value); }
        }

        public static readonly DependencyProperty UserListProperty =
            DependencyProperty.Register(
                "UserList", typeof(ICollectionView),
                typeof(MainViewModel), new PropertyMetadata(null));



        public string FilterString
        {
            get { return (string)GetValue(FilterStringProperty); }
            set { SetValue(FilterStringProperty, value); }
        }

        public static readonly DependencyProperty FilterStringProperty =
            DependencyProperty.Register(
                "FilterString", typeof(string),
                typeof(MainViewModel), new PropertyMetadata("", OnFiltreStringChange));

        public string FilterString1
        {
            get { return (string)GetValue(FilterStringProperty1); }
            set { SetValue(FilterStringProperty1, value); }
        }

        public static readonly DependencyProperty FilterStringProperty1 =
            DependencyProperty.Register(
                "FilterString1", typeof(string),
                typeof(MainViewModel), new PropertyMetadata("", OnFiltreStringChange1));
        public string FilterString2
        {
            get { return (string)GetValue(FilterStringProperty2); }
            set { SetValue(FilterStringProperty2, value); }
        }

        public static readonly DependencyProperty FilterStringProperty2 =
            DependencyProperty.Register(
                "FilterString2", typeof(string),
                typeof(MainViewModel), new PropertyMetadata("", OnFiltreStringChange2));
        public static void OnFiltreStringChange(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            ((MainViewModel)d).UserList.Refresh();
        }
        public static void OnFiltreStringChange1(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            ((MainViewModel)d).UserList.Refresh();
        }
        public static void OnFiltreStringChange2(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            ((MainViewModel)d).UserList.Refresh();
        }
        public SimpleCommand CreateUserCommand { get; set; }
        public SimpleCommand LoadUsersCommand { get; set; }

        public void CreateUser()
        {
            var obs_ls = UserList.SourceCollection as ObservableCollection<User>;
            obs_ls.Add(new User() { Name = "New User" });
        }

        public void LoadUsers()
        {
            var ls = new ObservableCollection<User>(User.GetUsers());
            UserList = CollectionViewSource.GetDefaultView(ls);
            UserList.Filter += FiltreUser;
        }

        public MainViewModel()
        {
            var ls = new ObservableCollection<User>();
            UserList = CollectionViewSource.GetDefaultView(ls);
            UserList.Filter += FiltreUser;
            CreateUserCommand = new SimpleCommand(CreateUser);
            LoadUsersCommand = new SimpleCommand(LoadUsers);
        }

        private bool FiltreUser(object obj)
        {
            var user = obj as User;
            
            if(user == null)
            {
                return false;
            }

            if (!(string.IsNullOrEmpty(FilterString) || user.Name.Contains(FilterString)))
            {
                return false;
            }

            if (!(string.IsNullOrEmpty(FilterString1) || user.Phone.Contains(FilterString1)))
            {
                return false;
            }
            if (!(string.IsNullOrEmpty(FilterString2) || user.Email.Contains(FilterString2)))
            {
                return false;
            }
            return true;
        }

        /*private bool FiltrePhone(object obj)
        {
            var phone = obj as User;

            if (phone == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(FilterString1) || phone.Phone.Contains(FilterString1))
            {
                return true;
            }

            return false;
        }
        private bool FiltreMail(object obj)
        {
            var mail = obj as User;

            if (mail == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(FilterString2) || mail.Email.Contains(FilterString2))
            {
                return true;
            }

            return false;
        }*/
    }
}