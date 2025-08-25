using System.Xml.Serialization;

namespace DisqusConvert.Models.WordPress;

public class Channel
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "link")]
    public string Link { get; set; }

    [XmlElement(ElementName = "description")]
    public string Descrition { get; set; }

    [XmlElement(ElementName = "pubDate")]
    public string PubDate { get; set; }

    [XmlElement(ElementName = "language")]
    public string Language { get; set; }

    [XmlElement(
        ElementName = "wxr_version",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string WxrVersion { get; set; }

    [XmlElement(
        ElementName = "base_site_url",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string BaseSiteUrl { get; set; }

    [XmlElement(
        ElementName = "base_blog_url",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string BaseBlogUrl { get; set; }

    [XmlElement(
        ElementName = "author",
        Namespace = "http://wordpress.org/export/1.2/")]
    public Author[] Authors { get; set; }

    [XmlElement(ElementName = "generator")]
    public string Generator { get; set; }

    [XmlElement(ElementName = "item")]
    public Item[] Items { get; set; }
}