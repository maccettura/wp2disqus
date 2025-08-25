using System.Xml.Serialization;

namespace DisqusConvert.Models.Disqus;

public class ParentStub
{
    [XmlAttribute("id",
        Namespace = "http://disqus.com/disqus-internals")]
    public int Id { get; set; }
}
