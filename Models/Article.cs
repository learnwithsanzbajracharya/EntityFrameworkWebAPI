﻿namespace BlogArticleProject.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Desc { get; set; }    
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
    }
}
