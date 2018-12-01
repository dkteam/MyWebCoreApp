using MyWebCoreApp.Data.Enums;

namespace MyWebCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}