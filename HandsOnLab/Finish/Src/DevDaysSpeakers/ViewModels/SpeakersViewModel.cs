﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using DevDaysSpeakers.Shared.Models;
using DevDaysSpeakers.Services;

//using Xamarin.Forms;

namespace DevDaysSpeakers.ViewModel
{
    public class SpeakersViewModel : INotifyPropertyChanged
    {
        bool isBusy;

        public SpeakersViewModel()
        {
            GetSpeakersCommand = new Command(async () => await GetSpeakers(), () => !IsBusy);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command GetSpeakersCommand { get; }

        public ObservableCollection<Speaker> Speakers { get; } = new ObservableCollection<Speaker>();

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();

                GetSpeakersCommand.ChangeCanExecute();
            }
        }

        async Task GetSpeakers()
        {
            try
            {
                IsBusy = true;

                var items = await AzureService.GetSpeakers();

                Speakers.Clear();

                foreach (var item in items)
                {
                    Speakers.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}