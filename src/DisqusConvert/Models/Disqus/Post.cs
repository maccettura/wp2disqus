using System.Xml;
using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

public class Post
{
    [XmlAttribute("id",
        Namespace = "http://disqus.com/disqus-internals")]
    public int PostId { get; set; }

    [XmlElement(ElementName = "id")]
    public int? Id { get; set; }

    [XmlElement(ElementName = "message")]
    public XmlCDataSection Message
    {
        get => new XmlDocument().CreateCDataSection(MessageInternal); 
        set => MessageInternal = value?.Value;
    }

    [XmlIgnore]
    public string? MessageInternal { get; set; }

    [XmlElement(ElementName = "thread")]
    public required ThreadStub Thread { get; set; } //req

    [XmlElement(ElementName = "parent")]
    public ParentStub? Parent { get; set; } 

    [XmlElement(ElementName = "ipAddress")]
    public string? IpAddress { get; set; }

    [XmlElement(ElementName = "createdAt")]
    public DateTime CreatedAt { get; set; } // req

    [XmlElement(ElementName = "isDeleted")]
    public bool IsDeleted { get; set; }

    [XmlElement(ElementName = "isApproved")]
    public bool IsApproved { get; set; }

    [XmlElement(ElementName = "isFlagged")]
    public bool IsFlagged { get; set; }

    [XmlElement(ElementName = "isSpam")]
    public bool IsSpam { get; set; }

    [XmlElement(ElementName = "isHighlighted")]
    public bool IsHighlighted { get; set; }

    [XmlElement(ElementName = "author")]
    public Author? Author { get; set; }
}
