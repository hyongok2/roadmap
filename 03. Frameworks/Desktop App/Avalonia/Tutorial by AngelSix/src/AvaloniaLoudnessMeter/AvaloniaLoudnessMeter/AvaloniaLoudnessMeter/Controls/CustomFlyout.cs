using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using Avalonia.Styling;

namespace AvaloniaLoudnessMeter
{
    public class CustomFlyout : PopupFlyoutBase
    {
        /// <summary>
        /// Defines the <see cref="Content"/> property
        /// </summary>
        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<CustomFlyout, object>(nameof(Content));

        private Classes? _classes;

        /// <summary>
        /// Gets the Classes collection to apply to the FlyoutPresenter this Flyout is hosting
        /// </summary>
        public Classes FlyoutPresenterClasses => _classes ??= new Classes();

        /// <summary>
        /// Defines the <see cref="FlyoutPresenterTheme"/> property.
        /// </summary>
        public static readonly StyledProperty<ControlTheme?> FlyoutPresenterThemeProperty =
            AvaloniaProperty.Register<CustomFlyout, ControlTheme?>(nameof(FlyoutPresenterTheme));
        
        /// <summary>
        /// Gets or sets the <see cref="ControlTheme"/> that is applied to the container element generated for the flyout presenter.
        /// </summary>
        public ControlTheme? FlyoutPresenterTheme
        {
            get => GetValue(FlyoutPresenterThemeProperty); 
            set => SetValue(FlyoutPresenterThemeProperty, value);
        }
        
        /// <summary>
        /// Gets or sets the content to display in this flyout
        /// </summary>
        [Content]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        protected override Control CreatePresenter()
        {
            return new FlyoutPresenter
            {
                [!ContentControl.ContentProperty] = this[!ContentProperty]
            };
        }

        protected override void OnOpening(CancelEventArgs args)
        {
            if (_classes != null)
            {
                var presenter = Popup.Child;
                //Force vertical offset ###### 중요 체크 #####
                Popup.HorizontalOffset = 200;
                
                if(presenter is null)
                {
                    return;
                }
                //Remove any classes no longer in use, ignoring pseudo classes
                for (var i = presenter.Classes.Count - 1; i >= 0; i--)
                {
                    if (!FlyoutPresenterClasses.Contains(presenter.Classes[i]) &&
                        !presenter.Classes[i].Contains(':'))
                    {
                        presenter.Classes.RemoveAt(i);
                    }
                }

                //Add new classes
                presenter.Classes.AddRange(FlyoutPresenterClasses);
                
                if (FlyoutPresenterTheme is { } theme)
                {
                    presenter.SetValue(Control.ThemeProperty, theme);
                }
            }

            base.OnOpening(args);
        }
    }
}
