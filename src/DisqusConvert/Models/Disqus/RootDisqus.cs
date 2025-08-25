using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

[XmlRoot("disqus", Namespace = "http://disqus.com",
IsNullable = false)]
public class RootDisqus
{
    [XmlElement(ElementName = "category")]
    public Category[] Category { get; set; }

    [XmlElement(ElementName = "thread")]
    public DisqusThread[] Thread { get; set; }

    [XmlElement(ElementName = "post")]
    public Post[] Post { get; set; }

    [XmlAttribute("schemaLocation", 
        AttributeName = "schemaLocation",
        Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string SchemaLocation = "http://disqus.com/api/schemas/1.0/disqus.xsd http://disqus.com/api/schemas/1.0/disqus-internals.xsd";
}
