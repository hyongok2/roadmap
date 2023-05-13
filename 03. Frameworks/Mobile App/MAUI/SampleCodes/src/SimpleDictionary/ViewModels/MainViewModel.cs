using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using SimpleDictionary.Models;
using SimpleDictionary.Pages;
using SimpleDictionary.Services;
using System.Collections.ObjectModel;
using System.Net;

namespace SimpleDictionary.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<DictionaryModel> DictionaryModels { get; set; } = new();

    [ObservableProperty]
    int count;

    [ObservableProperty]
    string inputText;

    IDictionaryService dictionaryService;
    IAudioManager audioManager;
    public MainViewModel(IDictionaryService dictionaryService, IAudioManager audioManager)
    {
        this.dictionaryService = dictionaryService;
        this.audioManager = audioManager;
    }

    [RelayCommand]
    async Task GetMeaningOfWord()
    {
        if (IsBusy) return;

        IsBusy = true;

        DictionaryModels.Clear();

        try
        {
            var recieveData = await dictionaryService.GetInformation(inputText);

            if (recieveData == null)
            {
                await Shell.Current.DisplayAlert("No Data", "There is no data!", "OK");
                return;
            }

            foreach (var item in recieveData)
            {
                DictionaryModels.Add(item);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToLink(string url)
    {
        await Shell.Current.GoToAsync($"{nameof(WebViewPage)}",true,
            new Dictionary<string,object>
            {
                { "Param1", url }
            });
    }

    [RelayCommand]
    async Task Listen(string word)
    {
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

        SpeechOptions options = new SpeechOptions()
        {
            Pitch = 1.5f,   // 0.0 - 2.0
            Volume = 0.75f, // 0.0 - 1.0
            Locale = locales.FirstOrDefault()
        };

        await TextToSpeech.Default.SpeakAsync(word, options);
    }

    [RelayCommand]
    async Task LinkListen(string url)
    {
        if (url == String.Empty) return;

        //if (IsBusy) return;

        //IsBusy = true;

        try
        {
            Stream stream = await dictionaryService.GetAudioStream(url);

            if (stream == null) return;

            var player = audioManager.CreatePlayer(stream);
            player.Play();
            
            player.PlaybackEnded += (sender, e) => { if(player!=null && player.IsPlaying != false) player.Dispose(); };
        }
        finally
        {
            //IsBusy = false;
        }

    }


}
