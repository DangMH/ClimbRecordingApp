namespace ClimbRecordingApp.BusinessLayer.Contracts
{
    /// <summary>
    /// Interface defining the primary key entry for an SQLiteConnection table entry.
    /// </summary>
    /// <remarks>Based on Open Source: https://github.com/xamarin/mobile-samples/tree/master/Tasky</remarks>
    public interface IBusinessEntity
    {
        int ID { get; set; }
    }
}
