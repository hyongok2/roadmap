using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using AvaloniaLoudnessMeter.ViewModels;

namespace AvaloniaLoudnessMeter.Views
{
    public partial class MainView : UserControl
    {
        #region Private Member

        private readonly Control _channelConfigPopUp;
        private readonly Control _channelConfigButton;
        private readonly Control _mainGrid;
        private readonly Control _volumeArrowContainer;

        private Timer _sizingTimer;

        #endregion
        public MainView()
        {
            InitializeComponent();
            // DataContext = new MainViewModel();
            
            _sizingTimer = new Timer(t =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    UpdateSizes();
                });
            });

            _channelConfigButton = this.FindControl<Control>("ChannelConfigurationButton") ?? throw new Exception("Cannot find Channel Configuration Button by name");
            _channelConfigPopUp = this.FindControl<Control>("ChannelConfigurationPopUp") ?? throw new Exception("Cannot find Channel Configuration Popup by name");
            _mainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");
            _volumeArrowContainer= this.FindControl<Control>("VolumeArrowContainer") ?? throw new Exception("Cannot find Volume Arrow Container by name");
        }

        private void UpdateSizes()
        {
            ((MainViewModel)DataContext).VolumeContainerSize = _volumeArrowContainer.Bounds.Height;
        }

        protected override async void OnLoaded()
        {
            await ((MainViewModel)DataContext).LoadSettingsCommand.ExecuteAsync(null);
            base.OnLoaded();
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            _sizingTimer.Change(100, int.MaxValue);
          
            // Main Gird 기준 버튼의 상대 위치를 가져옴.
            var position = _channelConfigButton.TranslatePoint(new Point(), _mainGrid) ??
                           throw new Exception("Cannot get TranslatePoint from Configuration Button");

            Dispatcher.UIThread.InvokeAsync(()=>
            {
                _channelConfigPopUp.Margin = new Thickness(position.X, 0, 0,
                    _mainGrid.Bounds.Height - position.Y - _channelConfigButton.Bounds.Height);
                
            });
        }

    }
}