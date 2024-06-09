using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalBuilderPattern
{
    public class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(subject =>
            {
                action(subject);
                return subject;
            });

            return (TSelf) this;
        }

        public TSubject Build() => actions.Aggregate(new TSubject(), (subject, fuction) => fuction(subject));
    }
}
