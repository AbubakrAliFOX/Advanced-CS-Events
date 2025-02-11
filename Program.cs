namespace Advanced_C__Events
{
    public delegate void VideoUpload(string videoTitle);

    internal class Program
    {
        static void Main(string[] args)
        {
            YoutubeChannel programmingAdvices = new();

            Subscriber ahmad = new("ahmad");
            Subscriber khaled = new("khaled");
            Subscriber abdullah = new("abdullah");

            ahmad.SubscribeToChannel(programmingAdvices);
            khaled.SubscribeToChannel(programmingAdvices);
            abdullah.SubscribeToChannel(programmingAdvices);

            while (true)
            {
                string? videoTitle = Console.ReadLine();

                if (!string.IsNullOrEmpty(videoTitle))
                {
                    programmingAdvices.UploadVideo(videoTitle);
                }
            }
        }

        class YoutubeChannel
        {
            public event VideoUpload videoUpload;

            public void UploadVideo(string videoTitle)
            {
                Console.WriteLine($"New video uploaded: {videoTitle}");
                videoUpload(videoTitle);
            }
        }

        class Subscriber
        {
            public string Name { get; set; }

            public Subscriber(string name)
            {
                Name = name;
            }

            public void SubscribeToChannel(YoutubeChannel channel)
            {
                channel.videoUpload += WatchVideo;
            }

            public void WatchVideo(string videoTitle)
            {
                Console.WriteLine($"{Name} is watching {videoTitle}");
            }
        }
    }
}
