namespace _02.Articles
{
    internal class Program
    {

        class Article
        {
            public Article (string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }
 
            string Title { get; set; }
            string Content { get; set; }
            string Author { get; set; }

            public void Edit(string newContent)
            {
                Content = newContent;
            }
            public void ChangeAuthor (string newAuthor)
            {
                Author = newAuthor;
            }
            public void Rename (string newTitle)
            {
                Title = newTitle;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }


        static void Main(string[] args)
        {
            

            string[] articleString = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Article article = new Article(articleString[0], articleString[1], articleString[2]);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ")
                    .ToArray();

                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;
                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());

        }
    }
}