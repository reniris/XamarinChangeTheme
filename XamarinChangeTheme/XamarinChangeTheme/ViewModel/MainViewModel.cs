using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamarinChangeTheme.View.Themes;

namespace XamarinChangeTheme.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// 選択されているテーマ
        /// </summary>
        #region SelectedTheme変更通知プロパティ
        private ThemeType _SelectedTheme;

        public ThemeType SelectedTheme
        {
            get
            { return _SelectedTheme; }
            set
            {
                if (_SelectedTheme == value)
                    return;
                _SelectedTheme = value;
                RaisePropertyChanged(nameof(SelectedTheme));

                (Application.Current as App)?.ChangeTheme(value);
            }
        }
        #endregion

        /// <summary>
        /// テーマ名リスト
        /// </summary>
        public List<string> Themes { get; } = Enum.GetNames(typeof(ThemeType)).ToList();

        public MainViewModel()
        {
            //(Application.Current as App)?.ChangeTheme(SelectedTheme);

        }
    }
}
