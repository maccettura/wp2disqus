using DisqusConvert.Extensions;
using DisqusConvert.Models.Disqus;
using DisqusConvert.Models.WordPress;
using DisqusConvert.Utility;
using System.Xml.Serialization;

namespace DisqusConvert.Services;

public class ToDisqusService
{
    /// <summary>
    /// Serializes a RootDisqus object to string
    /// </summary>
    /// <param name="rootDisqus">The object to serialize</param>
    /// <returns>A serialized string representation of the input object</returns>
    public static string Serialize(RootDisqus rootDisqus)
    {        
        XmlSerializerNamespaces namespaces = new();
        namespaces.Add("dsq", "http://disqus.com/disqus-internals");
        namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

        XmlSerializer serializer = new(typeof(RootDisqus));
        using StringWriter textWriter = new();
        serializer.Serialize(textWriter, rootDisqus, namespaces);
        Console.WriteLine("Serialized to Disqus!");
        return textWriter.ToString();
    }

    /// <summary>
    /// Converts a RootWordPress object to a RootDisqus object.
    /// </summary>
    /// <param name="rootWordPress">The RootWordPress object to convert</param>
    /// <param name="channelId">A 32bit integer that represents the root channel ID</param>
    /// <returns>A RootDisqus object converted from input RootWordPress object</returns>
    public static RootDisqus Convert(RootWordPress rootWordPress, int channelId)
    {
        RootDisqus rootDisqus = new()
        {
            Category = [new Category()
            {
                CategoryId = channelId,
                Forum = rootWordPress.Channel.Title,
                IsDefault = true,
                Title = rootWordPress.Channel.Title,
            }]
        };

        var threads = new List<DisqusThread>();

        var posts = new List<Post>();

        foreach(var item in rootWordPress.Channel.Items)
        {
            var threadCreateDate = item.PubDate.FromCdata().ToDateTime();

            string status = item.Status.FromCdata();
            if(status.Equals(Constants.WordPressStatus.PublishStatus, StringComparison.OrdinalIgnoreCase) &&
                !threadCreateDate.HasValue)
            {
                Console.WriteLine("This should never happen");
            }

            if (status.Equals(Constants.WordPressStatus.PrivateStatus, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Item is private");
                continue;
            }

            if (status.Equals(Constants.WordPressStatus.DraftStatus, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Item is Draft");
                continue;
            }

            if (!threadCreateDate.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(item.PubDate))
                {
                    Console.WriteLine($"Bad Item Date: {item.PubDate}");
                }                
                continue;
            }

            threads.Add(new DisqusThread()
            {
                CreatedAt = threadCreateDate.Value,
                Forum = rootWordPress.Channel.Title,
                Author = new Models.Disqus.Author()
                {
                    Name = item.Creator,
                },
                Category = new CategoryStub() { Id = channelId },
                IsDeleted = false,
                ThreadId = item.PostId,
                Title = item.Title,
                IsClosed = false,
                Link = item.Link,
            });

            if(item.Comments == null || !item.Comments.Any())
            {
                continue;
            }

            foreach(var comment in item.Comments)
            {
                if(!comment.Approved.CDataBool())
                {
                    continue;
                }

                var commentDate = comment.Date.FromCdata().ToDateTime();
                if (!commentDate.HasValue)
                {
                    if(!string.IsNullOrWhiteSpace(comment.Date))
                    {
                        Console.WriteLine($"Bad Comment Date: {comment.Date}");
                    }                    
                    continue;
                }

                posts.Add(new Post()
                {
                    Author = new Models.Disqus.Author()
                    {
                        Name = comment.Author,
                        Email = comment.AuthorEmail,
                        Link = comment.AuthorUrl
                    },
                    CreatedAt = commentDate.Value,
                    PostId = comment.Id,
                    Parent = comment.Parent == 0 ? null : new ParentStub() { Id = comment.Parent },
                    IsApproved = true,
                    MessageInternal = comment.Content,
                    IsDeleted = false,
                    Thread = new ThreadStub() { Id = item.PostId },
                    IsSpam = false
                });
            }
        }

        rootDisqus.Thread = [.. threads];
        rootDisqus.Post = [.. posts];

        return rootDisqus;
    }
}
