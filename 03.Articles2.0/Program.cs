internal class Program
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        string Title { get; set; }
        string Content { get; set; }
        string Author { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }


    static void Main()
    {
        List<Article> articles = new List<Article>();

        int commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandCount; i++)
        {
                string[] articleString = Console.ReadLine()
                    .Split(", ")
                    .ToArray();

            Article article = new Article(articleString[0], articleString[1], articleString[2]);

            articles.Add(article);
        }

        foreach (Article article in articles)
        {
            Console.WriteLine(article.ToString());
        }

    }
}
