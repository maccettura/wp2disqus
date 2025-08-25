using DisqusConvert.Models.WordPress;
using System.Xml;
using System.Xml.Serialization;

namespace DisqusConvert.Services;

public class FromWpService
{
    /// <summary>
    /// Takes WP format XML file and deserializes into a workable object.
    /// </summary>
    /// <param name="xmlContent">XML string in WP format</param>
    /// <returns>A `RootWordPress` object</returns>
    public static RootWordPress? Deserialize(string xmlContent)
    {
        if(string.IsNullOrWhiteSpace(xmlContent))
        {
            return null;
        }

        RootWordPress? root;
        XmlSerializer serializer = new(typeof(RootWordPress));
        using XmlReader xmlReader = XmlReader.Create(new StringReader(xmlContent));

        root = serializer?.Deserialize(xmlReader) as RootWordPress;
        Console.WriteLine("Word Press Serialized!");
        return root;
    }
}
