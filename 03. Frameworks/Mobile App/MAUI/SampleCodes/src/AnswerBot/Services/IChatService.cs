namespace AnswerBot.Services
{
    public interface IChatService
    {
        Task<string> GetAnswer(string question);
    }
}