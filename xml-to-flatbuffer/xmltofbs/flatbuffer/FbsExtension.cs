namespace flatbuffer
{

    static internal class FbsExtension
    {
        public static void FillFromXmlBible(this Bible fbsBible, xmltofbs.Bible source)
        {
            fbsBible.Title = source.Title;
            fbsBible.Books = new List<Book>();
            foreach (var sourceBook in source.Books)
            {
                var targetBook = new Book();
                targetBook.Order = (short)sourceBook.Order;
                fbsBible.Books.Add(targetBook);
                targetBook.Chapters = new List<Chapter>();

                if (sourceBook.Chapters == null) continue;
                foreach (var sourceChapter in sourceBook.Chapters)
                {
                    var targetChapter = new Chapter
                    {
                        Order = (short)sourceChapter.Order
                    };
                    targetBook.Chapters.Add(targetChapter);
                    targetChapter.Verses = new List<Verse>();

                    if (sourceChapter.Verses == null) continue;
                    foreach (var sourceVerse in sourceChapter.Verses)
                    {
                        var targetVerse = new Verse
                        {
                            Order = (short)sourceVerse.Order,
                            Text = sourceVerse.Text
                        };
                        targetChapter.Verses.Add(targetVerse);
                    }
                }
            }
        }
    }
}