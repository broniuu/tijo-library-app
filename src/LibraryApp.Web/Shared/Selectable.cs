using System.Text.Json.Serialization;

namespace LibraryApp.Web.Shared;

public interface ISelectable
{
    [JsonIgnore]
    bool IsSelected { get; set; } 
}