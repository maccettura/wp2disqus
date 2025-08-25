using System.Xml.Serialization;

namespace DisqusConvert.Models.WordPress;

public class Comment
{
    [XmlElement(ElementName = "comment_id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "comment_author")]
    public string Author { get; set; }

    [XmlElement(ElementName = "comment_author_email")]
    public string AuthorEmail { get; set; }

    [XmlElement(ElementName = "comment_author_url")]
    public string AuthorUrl { get; set; }

    [XmlElement(ElementName = "comment_author_IP")]
    public string AuthorIp { get; set; }

    [XmlElement(ElementName = "comment_date")]
    public string Date { get; set; }

    [XmlElement(ElementName = "comment_date_gmt")]
    public string DateGmt { get; set; }

    [XmlElement(ElementName = "comment_content")]
    public string Content { get; set; }

    [XmlElement(ElementName = "comment_approved")]
    public string Approved { get; set; }

    [XmlElement(ElementName = "comment_type")]
    public string Type { get; set; }

    [XmlElement(ElementName = "comment_parent")]
    public int Parent { get; set; }

    [XmlElement(ElementName = "comment_user_id")]
    public int UserId { get; set; }
}
