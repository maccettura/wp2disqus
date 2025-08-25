using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

public class DisqusThread
{
    [XmlAttribute("id", 
        Namespace = "http://disqus.com/disqus-internals")]
    public int ThreadId { get; set; }

    [XmlElement(ElementName = "id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "forum")]
    public string Forum { get; set; } // req

    [XmlElement(ElementName = "category")]
    public CategoryStub Category { get; set; } //req

    [XmlElement(ElementName = "link")]
    public string Link { get; set; } //URI req

    [XmlElement(ElementName = "title")]
    public string Title { get; set; } //req

    [XmlElement(ElementName = "message")]
    public string Message { get; set; }

    [XmlElement(ElementName = "ipAddress")]
    public string IpAddress { get; set; }

    [XmlElement(ElementName = "author")]
    public Author Author { get; set; }

    [XmlElement(ElementName = "createdAt")]
    public DateTime CreatedAt { get; set; } // req

    [XmlElement(ElementName = "isClosed")]
    public bool IsClosed { get; set; }

    [XmlElement(ElementName = "isDeleted")]
    public bool IsDeleted { get; set; }
}
