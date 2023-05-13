using MonkeyFinder.Model;
using MonkeyFinder.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Helper
{
    public class MonkeySearchHandler : SearchHandler
    {
        public static readonly BindableProperty MonkeyListProperty = BindableProperty.Create(nameof(MonkeyList), typeof(IList<Monkey>), typeof(MonkeySearchHandler), null);

        public IList<Monkey> MonkeyList
        {
            get => (IList<Monkey>)GetValue(MonkeySearchHandler.MonkeyListProperty);
            set => SetValue(MonkeySearchHandler.MonkeyListProperty, value);
        }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (MonkeyList == null) return;

           
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = MonkeyList
                    .Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList<Monkey>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation complete
            await Task.Delay(1000);

            // The following route works because route names are unique in this app.
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
                new Dictionary<string, object>
                {
                {"Monkey",(Monkey)item }
                });
        }

        string GetNavigationTarget()
        {
            return nameof(DetailsPage);
        }
    }
}
