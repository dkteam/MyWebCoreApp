using System;

namespace MyWebCoreApp.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime CreatedDate { set; get; }
        DateTime ModifiedDate { set; get; }
    }
}