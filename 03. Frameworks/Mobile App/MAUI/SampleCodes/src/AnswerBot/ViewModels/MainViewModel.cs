
using AnswerBot.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Threading;

namespace AnswerBot.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IChatService _chatService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    string enterQuestionString;

    [ObservableProperty]
    string userQuestionString;

    [ObservableProperty]
    string answerString;

    CancellationTokenSource _cts;

    public MainViewModel(IChatService chatGPTService)
    {
        _chatService = chatGPTService;
    }

    [RelayCommand]
    async void GetAnswer()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            
            UserQuestionString = EnterQuestionString;
            EnterQuestionString = "";

            AnswerString = await _chatService.GetAnswer(UserQuestionString);
            AnswerString = AnswerString.Replace("\n\n", "");

            IsBusy = false;

            _cts = new CancellationTokenSource();
            await TextToSpeech.SpeakAsync(AnswerString, _cts.Token);
        }
        finally
        {
            IsBusy = false;
        }

    }

    [RelayCommand]
    void StopSpeak()
    {
        _cts?.Cancel();
    }

}
