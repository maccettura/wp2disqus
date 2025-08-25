using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

public class Author
{
    [XmlElement(ElementName = "name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "email")]
    public string Email { get; set; }

    [XmlElement(
        ElementName = "link")]
    public string? Link { get; set; }

    [XmlElement(
        ElementName = "username")]
    public string? Username { get; set; }

    [XmlElement(ElementName = "isAnonymous")]
    public bool IsAnonymous { get; set; }

    public bool ShouldSerializeLink()
    {
        return !string.IsNullOrWhiteSpace(Link);
    }
}
