namespace BlazorApp;

public class LocalizationOptions
{
    [Required]
    public Dictionary<string, string> SupportedCultures { get; set; }
}
