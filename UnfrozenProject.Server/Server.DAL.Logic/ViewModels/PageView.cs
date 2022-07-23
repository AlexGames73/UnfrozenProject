namespace Server.DAL.Logic.ViewModels;

public class PageView<T>
{
    public IList<T> Elements { get; set; }
    public int TotalCount { get; set; }
}
