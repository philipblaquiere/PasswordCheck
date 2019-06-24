namespace HaveIBeenPND.Entities
{
    public class HaveIBeenPwndRangeResponse
    {
        public HaveIBeenPwndRangeResponse(string response)
        {
            Content = response;
        }

        public string Content { get; }
    }
}
