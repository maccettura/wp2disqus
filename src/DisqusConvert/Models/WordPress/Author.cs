using System.Xml.Serialization;

namespace DisqusConvert.Models.WordPress;

public class Author
{
    [XmlElement(ElementName = "author_id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "author_login")]
    public string Login { get; set; }

    [XmlElement(ElementName = "author_email")]
    public string Email { get; set; }

    [XmlElement(ElementName = "author_display_name")]
    public string DisplayName { get; set; }

    [XmlElement(ElementName = "author_first_name")]
    public string FirstName { get; set; }

    [XmlElement(ElementName = "author_last_name")]
    public string LastName { get; set; }
}
