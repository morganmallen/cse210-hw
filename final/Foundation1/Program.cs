using System;
class Program
{
    static void Main()
    {
        var video1 = new Video("Building My Snow Cone Truck Business#", "Jacob Johnson", 600);
        var video2 = new Video("How to Sing", "Freddie Mercury", 300);
        var video3 = new Video("Travel Vlog: Japan", "Makoto Fujita", 1200);

        video1.AddComment(new Comment("Marcus", "Great video!"));
        video1.AddComment(new Comment("Braden", "Very informative."));
        video1.AddComment(new Comment("Morgan", "Thanks for sharing."));

        video2.AddComment(new Comment("Paul", "Brilliant voice!"));
        video2.AddComment(new Comment("John", "Moving lyrics."));
        video2.AddComment(new Comment("Ringo", "You're off tempo."));

        video3.AddComment(new Comment("Brandon", "Amazing journey!"));
        video3.AddComment(new Comment("Christian", "Beautiful scenery."));
        video3.AddComment(new Comment("Alissa", "I want to visit Japan now."));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
