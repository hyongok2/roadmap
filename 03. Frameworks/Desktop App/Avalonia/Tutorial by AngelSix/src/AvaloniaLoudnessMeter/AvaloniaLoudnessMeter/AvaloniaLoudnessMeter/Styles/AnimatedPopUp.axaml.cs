using System;
using System.Timers;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Threading;

namespace AvaloniaLoudnessMeter;

public class AnimatedPopUp : ContentControl
{
    #region Private Members

    /// <summary>
    /// Store the controls desired size
    /// </summary>
    private Size _desiredSize;

    /// <summary>
    /// A flag for when we are animating
    /// </summary>
    private bool _animating;

    private DispatcherTimer _animationTimer;
    private int _animationCurrentTick = 0;
 
    #endregion

    #region Constructor
    public AnimatedPopUp()
    {
        //Get a 60 FPS timespan
        var framerate = TimeSpan.FromSeconds(1 / 60.0);

        //Make a new dispatch timer
        _animationTimer = new DispatcherTimer
        {
            Interval = framerate
        };

        var animationTime = TimeSpan.FromSeconds(1);
        var totalTicks = (int)(animationTime.TotalSeconds / framerate.TotalSeconds);

        _animationTimer.Tick += (sender, args) =>
        {
            _animationCurrentTick++;

            _animating = true;

            if (_animationCurrentTick >= totalTicks)
            {
                _animationTimer.Stop();
                _animating = false;
                return;
            }

            var percentageAnimated = (double)_animationCurrentTick / totalTicks;

            //Make an animation easing
            var easing = new QuadraticEaseIn();
            var easingValue = easing.Ease(percentageAnimated);
            Width = _desiredSize.Width * easingValue;
            Height = _desiredSize.Height * easingValue;
        };
    }

    #endregion

    public override void Render(DrawingContext context)
    {
        //If we are not animating
        if (_animating == false)
        {
            _desiredSize = DesiredSize;// - Margin;//Update the size
            _animationCurrentTick = 0;
            _animationTimer.Start();
        }
        
        base.Render(context);
    }
}