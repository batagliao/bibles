using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xmltofbs
{
    [XmlRoot(ElementName = "v")]
    public class Verse
    {
        [XmlAttribute(AttributeName = "n")]
        public int Order { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "c")]
    public class Chapter
    {

        [XmlElement(ElementName = "v")]
        public List<Verse> Verses { get; set; }

        [XmlAttribute(AttributeName = "n")]
        public int Order { get; set; }        
    }

    [XmlRoot(ElementName = "b")]
    public class Book
    {

        [XmlElement(ElementName = "c")]
        public List<Chapter> Chapters { get; set; }

        [XmlAttribute(AttributeName = "o")]
        public int Order { get; set; }
    }

    [XmlRoot(ElementName = "bible")]
    public class Bible
    {

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "b")]
        public List<Book> Books { get; set; }
    }
}
