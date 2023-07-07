using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        {
            // Create videos
            List<Video> videos = new List<Video>();

            Video video1 = new Video("Video 1", "Author 1", 120);
            video1.AddComment("User 1", "Comment 1");
            video1.AddComment("User 2", "Comment 2");
            video1.AddComment("User 3", "Comment 3");
            videos.Add(video1);

            Video video2 = new Video("Video 2", "Author 2", 180);
            video2.AddComment("User 4", "Comment 4");
            video2.AddComment("User 5", "Comment 5");
            videos.Add(video2);

            Video video3 = new Video("Video 3", "Author 3", 150);
            video3.AddComment("User 6", "Comment 6");
            videos.Add(video3);

            // Display video information
            foreach (Video video in videos)
            {
                Console.WriteLine("Title: " + video.Title);
                Console.WriteLine("Author: " + video.Author);
                Console.WriteLine("Length: " + video.Length + " seconds");
                Console.WriteLine("Number of comments: " + video.GetNumberOfComments());

                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine("Commenter: " + comment.Commenter);
                    Console.WriteLine("Text: " + comment.Text);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
    class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int Length { get; }
        public List<Comment> Comments { get; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(string commenter, string text)
        {
            Comment comment = new Comment(commenter, text);
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    class Comment
    {
        public string Commenter { get; }
        public string Text { get; }

        public Comment(string commenter, string text)
        {
            Commenter = commenter;
            Text = text;
        }
    }
}
