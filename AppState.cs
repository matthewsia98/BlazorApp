namespace BlazorApp;

public class AppState
{
    public string Message { get; private set; }

    public event Action? OnMessageChanged;

    public void SetMessage(string message)
    {
        Message = message;
        OnMessageChanged?.Invoke();
    }
}
