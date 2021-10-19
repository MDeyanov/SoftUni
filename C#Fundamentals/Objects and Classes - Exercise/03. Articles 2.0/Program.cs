using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Autor { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }
        public void ChangeAutor(string newAutor)
        {
            Autor = newAutor;
        }
        public void Rename(string newTitel)
        {
            Title = newTitel;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Autor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine().Split(", ");
                Article article = new Article()
                {
                    Title = articleData[0],
                    Content = articleData[1],
                    Autor = articleData[2]
                };
                articles.Add(article);
            }

            string sortingCriteria = Console.ReadLine();
            List<Article> sorted = new List<Article>();
            if (sortingCriteria == "title")
            {
                sorted = articles.OrderBy(x => x.Title).ToList();
            }
            else if (sortingCriteria == "content")
            {
                sorted = articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                sorted = articles.OrderBy(x => x.Autor).ToList();
            }
            foreach (var article in sorted)
            {
                Console.WriteLine(article);
            }
        }
    }
}
