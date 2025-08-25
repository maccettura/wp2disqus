using System.Xml.Serialization;

namespace DisqusConvert.Models.WordPress;

public class Item
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "link")]
    public string Link { get; set; }

    [XmlElement(ElementName = "pubDate")]
    public string PubDate { get; set; }

    [XmlElement(
        ElementName = "creator",
        Namespace = "http://purl.org/dc/elements/1.1/")]
    public string Creator { get; set; }

    [XmlElement(ElementName = "guid")]
    public string Guid { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(
        ElementName = "encoded",
        Namespace = "http://purl.org/rss/1.0/modules/content/")]
    public string ContentEncoded { get; set; }

    [XmlElement(
        ElementName = "encoded",
        Namespace = "http://wordpress.org/export/1.2/excerpt/")]
    public string ExerptEncoded { get; set; }

    [XmlElement(
        ElementName = "post_id",
        Namespace = "http://wordpress.org/export/1.2/")]
    public int PostId { get; set; }

    [XmlElement(
        ElementName = "post_date",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostDate { get; set; }

    [XmlElement(
        ElementName = "post_date_gmt",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostDateGmt { get; set; }

    [XmlElement(
        ElementName = "post_modified",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostModified { get; set; }

    [XmlElement(
        ElementName = "post_modified_gmt",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostModifiedGmt { get; set; }

    [XmlElement(
        ElementName = "comment_status",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string CommentStatus { get; set; }

    [XmlElement(
        ElementName = "ping_status",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PingStatus { get; set; }

    [XmlElement(
        ElementName = "post_name",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostName { get; set; }

    [XmlElement(
        ElementName = "status",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string Status { get; set; }

    [XmlElement(
        ElementName = "post_parent",
        Namespace = "http://wordpress.org/export/1.2/")]
    public int PostParent { get; set; }

    [XmlElement(
        ElementName = "menu_order",
        Namespace = "http://wordpress.org/export/1.2/")]
    public int MenuOrder { get; set; }

    [XmlElement(
        ElementName = "post_type",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostType { get; set; }

    [XmlElement(
        ElementName = "post_password",
        Namespace = "http://wordpress.org/export/1.2/")]
    public string PostPassword { get; set; }

    [XmlElement(
        ElementName = "is_sticky",
        Namespace = "http://wordpress.org/export/1.2/")]
    public int IsSticky { get; set; }

    [XmlElement(
        ElementName = "comment",
        Namespace = "http://wordpress.org/export/1.2/")]
    public Comment[] Comments { get; set; }    
}