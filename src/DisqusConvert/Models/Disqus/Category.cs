using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

public class Category
{
    [XmlAttribute("id",
        Namespace = "http://disqus.com/disqus-internals")]
    public int CategoryId { get; set; }

    [XmlElement(ElementName = "forum")]
    public string Forum { get; set; }

    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "order")]
    public int Order { get; set; }

    [XmlElement(ElementName = "isDefault")]
    public bool IsDefault { get; set; }
}
