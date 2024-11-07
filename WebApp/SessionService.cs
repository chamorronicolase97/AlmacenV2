public class SessionService
{
    private bool isLoggedIn = false;

    // Evento para notificar los cambios en el estado de la sesión
    public event Action OnChange;

    public bool IsLoggedIn
    {
        get { return isLoggedIn; }
        set
        {
            if (isLoggedIn != value)
            {
                isLoggedIn = value;
                NotifyStateChanged(); // Notificar el cambio
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
