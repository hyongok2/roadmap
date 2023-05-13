using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MonkeyFinder.Model
{
    public class TestMessage : ValueChangedMessage<string>
    {
        public TestMessage(string value) : base(value)
        {
        }
    }
}
