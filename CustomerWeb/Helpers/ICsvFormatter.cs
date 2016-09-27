namespace CustomerWeb.Helpers
{
    internal interface ICsvFormatter<T>
    {
        string GetHeader();

        string FormatItem(T item);
    }
}