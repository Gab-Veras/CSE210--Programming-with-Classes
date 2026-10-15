using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Make a few videos and add comments to each one.
        Video video1 = new Video("How to Make Pancakes", "Cooking with Sam", 420);
        video1.AddComment(new Comment("Alex", "These look delicious!"));
        video1.AddComment(new Comment("Maria", "I made these for breakfast."));
        video1.AddComment(new Comment("Jordan", "The recipe was easy to follow."));

        Video video2 = new Video("Beginner Guitar Lesson", "Music with Lee", 615);
        video2.AddComment(new Comment("Taylor", "This helped me learn my first chords."));
        video2.AddComment(new Comment("Chris", "Could you make another lesson?"));
        video2.AddComment(new Comment("Riley", "Great explanation."));

        Video video3 = new Video("A Walk in the Mountains", "Travel with Ana", 830);
        video3.AddComment(new Comment("Morgan", "The view is beautiful."));
        video3.AddComment(new Comment("Jamie", "I would love to visit there."));
        video3.AddComment(new Comment("Casey", "Thanks for sharing this trip!"));

        // Keep all the videos together so we can display them with one loop.
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comment list:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
