namespace Advanced_C__Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YoutubeChannel programmingAdvices = new("Programming Advices");
            YoutubeChannel elzero = new("Elzero");

            Subscriber ahmad = new("ahmad");
            Subscriber khaled = new("khaled");
            Subscriber abdullah = new("abdullah");

            ahmad.SubscribeToChannel(programmingAdvices);
            khaled.SubscribeToChannel(programmingAdvices);
            abdullah.SubscribeToChannel(programmingAdvices);

            abdullah.SubscribeToChannel(elzero);
            // ahmad.UnsubscribeToChannel(programmingAdvices);

            programmingAdvices.UploadVideo("Strings", 6);
            elzero.UploadVideo("css", 10);
        }

        class YoutubeChannel(string name)
        {
            public event EventHandler<VideoInfoEventArgs> videoUpload;

            public string Name { get; set; } = name;

            public void UploadVideo(string videoTitle, int videoDuration)
            {
                Console.WriteLine($"New video uploaded: {videoTitle}");
                videoUpload?.Invoke(this, new() { Title = videoTitle, Duration = videoDuration, });
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

            public void UnsubscribeToChannel(YoutubeChannel channel)
            {
                channel.videoUpload -= WatchVideo;
            }

            public void WatchVideo(object sender, VideoInfoEventArgs videoInfo)
            {
                YoutubeChannel channel = (YoutubeChannel)sender;
                Console.WriteLine(
                    $"{Name} is watching {videoInfo.Title}, which is {videoInfo.Duration} long, from {channel.Name}"
                );
            }
        }

        public class VideoInfoEventArgs : EventArgs
        {
            public string Title { get; set; } = null!;
            public int Duration { get; set; }
        }
    }
}
