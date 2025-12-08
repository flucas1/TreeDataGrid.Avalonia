using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using TreeDataGridDemo.Utils;

namespace TreeDataGridDemo.Models
{
    internal class OnThisDay
    {
        public OnThisDayEvent[]? Selected { get; set; }
    }

    internal class OnThisDayEvent
    {
        public string? Text { get; set; }
        public int Year { get; set; }
        public OnThisDayArticle[]? Pages { get; set; }
    }

    internal class OnThisDayArticle
    {
        private Bitmap? _image;

        public string? Type { get; set; }
        public OnThisDayTitles? Titles { get; set; }
        public OnThisDayImage? Thumbnail { get; set; }
        public string? Description { get; set; }
        public string? Extract { get; set; }

        [JsonIgnore]
        public Task<Bitmap?> Image => GetImageAsync();

        private async Task<Bitmap?> GetImageAsync() => _image ??= await LoadImageAsync();

        private async Task<Bitmap?> LoadImageAsync()
        {
            if (Thumbnail?.Source is null)
                return null;

            // Load the image from the url.
            var client = new HttpClientEx();
            var bytes = await client.GetByteArrayAsync(Thumbnail!.Source);
            var stream = new MemoryStream(bytes);

            return new Bitmap(stream);
        }
    }

    internal class OnThisDayTitles
    {
        public string? Normalized { get; set; }
    }

    internal class OnThisDayImage
    {
        public string? Source { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
