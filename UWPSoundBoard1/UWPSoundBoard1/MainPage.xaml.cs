using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSoundBoard1.Model;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSoundBoard1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<MenuItems> menuitems;

        public MainPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
            menuitems = new List<MenuItems>();
            //load pane
            menuitems.Add(new MenuItems {
                IconFile = "Assets/Icons/animals.png",
                Category = SoundCategory.Animals
            });

            menuitems.Add(new MenuItems
            {
                IconFile = "Assets/Icons/cartoon.png",
                Category = SoundCategory.Cartoons
            });

            menuitems.Add(new MenuItems
            {
                IconFile = "Assets/Icons/taunt.png",
                Category = SoundCategory.Taunts
            });

            menuitems.Add(new MenuItems
            {
                IconFile = "Assets/Icons/warning.png",
                Category = SoundCategory.Warnings
            });

           
        }

          
        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var memuItem = (MenuItems)e.ClickedItem;
            CategoryTextBlock.Text = memuItem.Category.ToString();
            SoundManager.GetSoundsByCategory(sounds, memuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }
        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.audioFile);

        }
        private void BackButton_Click(object sender, ItemClickEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
