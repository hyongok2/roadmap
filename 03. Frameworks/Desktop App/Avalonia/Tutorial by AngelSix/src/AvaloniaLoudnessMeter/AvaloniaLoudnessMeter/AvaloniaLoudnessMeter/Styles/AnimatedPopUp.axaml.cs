using System;
using System.Threading;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaLoudnessMeter;

public partial class AnimatedPopUp : ContentControl
{
    #region Private Members

    private bool _firstAnimation = true;

    private double _originalOpacity;
    
    //Get a 60 FPS timespan
    private TimeSpan _framerate = TimeSpan.FromSeconds(1 / 60.0);
    
    private int _totalTicks => (int)(_animationTime.TotalSeconds / _framerate.TotalSeconds);
    
    /// <summary>
    /// Store the controls desired size
    /// </summary>
    private Size _desiredSize;

    /// <summary>
    /// A flag for when we are animating
    /// </summary>
    private bool _animating;

    /// <summary>
    /// Keeps track of if we have found the desired 100% width/height auto size
    /// </summary>
    private bool _sizeFound;

    private DispatcherTimer _animationTimer;

    private Timer _sizingTimer;
    
    private int _animationCurrentTick = 0;
 
    #endregion

    #region Public Properties
    
    /// <summary>
    /// Sets whether the control should be opening or closing
    /// </summary>

    private bool _open;

    public static readonly DirectProperty<AnimatedPopUp, bool> OpenProperty = AvaloniaProperty.RegisterDirect<AnimatedPopUp, bool>(
        nameof(Open), o => o.Open, (o, v) => o.Open = v);

    public bool Open
    {
        get => _open;
        set => SetAndRaise(OpenProperty, ref _open, value);
    }

    public bool IsOpened => _animationCurrentTick >= _totalTicks;
    
    #region Animation Time Property

    private TimeSpan _animationTime = TimeSpan.FromSeconds(2);

    public static readonly DirectProperty<AnimatedPopUp, TimeSpan> AnimationTimeProperty = AvaloniaProperty.RegisterDirect<AnimatedPopUp, TimeSpan>(
        nameof(AnimationTime), o => o.AnimationTime, (o, v) => o.AnimationTime = v);

    public TimeSpan AnimationTime
    {
        get => _animationTime;
        set => SetAndRaise(AnimationTimeProperty, ref _animationTime, value);
    }
    #endregion

    #endregion

    #region Pubic Commands

    [RelayCommand]
    public void BeginOpen()
    {
        Open = true;
        UpdateAimation();
    }
    [RelayCommand]
    public void BeginClose()
    {
        Open = false;
        UpdateAimation();
    }

    #endregion

    #region Constructor
    public AnimatedPopUp()
    {
        _originalOpacity = Opacity;

        Opacity = 0;
        
        //Make a new dispatch timer
        _animationTimer = new DispatcherTimer
        {
            Interval = _framerate
        };

        _sizingTimer = new Timer(t =>
        {
            if(_sizeFound == true)
            {
                return;
            }

            _sizeFound = true;

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                _desiredSize = DesiredSize;
                UpdateAimation();
            });
        });

        _animationTimer.Tick += (s,e) => AnimationTick();
     ;
    }

    #endregion

    #region Private Methods
    
    private void UpdateAimation()
    {
        if (_sizeFound == false)
            return;
        
        _animationTimer.Start();
    }


    private void AnimationTick()
    {
        if (_firstAnimation == true)
        {
            _firstAnimation = false;
            
            _animationTimer.Stop();
            
            Opacity = _originalOpacity;
            
            Width = _open ? _desiredSize.Width : 0;
            Height = _open ? _desiredSize.Height : 0;

            return;
        }

        if ((_open == true && _animationCurrentTick >= _totalTicks)|| 
            (_open == false && _animationCurrentTick == 0))
        {
            _animationTimer.Stop();
            
            Width = _open ? _desiredSize.Width : 0;
            Height = _open ? _desiredSize.Height : 0;
            
            _animating = false;
            return;
        }
        
        _animating = true;
        _animationCurrentTick += _open ? 1 : -1;

        var percentageAnimated = (double)_animationCurrentTick / _totalTicks;

        //Make an animation easing
        var easing = new QuadraticEaseIn();
        var easingValue = easing.Ease(percentageAnimated);
        Width = _desiredSize.Width * easingValue;
        Height = _desiredSize.Height * easingValue;
    }
    

    #endregion

    public override void Render(DrawingContext context)
    {
        //If we are not animating
        // if (_animating == false)
        // {
        //     _desiredSize = DesiredSize;// - Margin;//Update the size
        //     _animationCurrentTick = 0;
        //     _animationTimer.Start();
        // }

        if (_sizeFound == false)
        {
            _sizingTimer.Change(100,int.MaxValue);
        }
        
        base.Render(context);
    }
}