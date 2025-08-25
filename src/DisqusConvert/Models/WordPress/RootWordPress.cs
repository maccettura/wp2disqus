using System.Xml.Serialization;

namespace DisqusConvert.Models.WordPress;

[XmlRoot("rss",
    IsNullable = false)]
public class RootWordPress
{
    [XmlElement(ElementName = "channel")]
    public Channel Channel { get; set; }
}
