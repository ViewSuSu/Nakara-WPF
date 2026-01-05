using System.IO;
using System.Resources;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NarakaBladepoint.Resources
{
    public static class ResourceImageReader
    {
        private static readonly List<ImageSource> _heroImages = new();

        static ResourceImageReader()
        {
            var assembly = typeof(ResourceImageReader).Assembly;
            var resourceName = assembly.GetName().Name + ".g.resources";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                return;

            using var reader = new ResourceReader(stream);

            foreach (var entry in reader.Cast<System.Collections.DictionaryEntry>())
            {
                var key = entry.Key as string;
                if (key == null)
                    continue;

                // ⚠️ WPF Resource 路径是小写的
                if (!key.StartsWith("image/hero/") || !key.EndsWith(".png"))
                    continue;

                var uri = new Uri(
                    $"pack://application:,,,/{assembly.GetName().Name};component/{key}",
                    UriKind.Absolute
                );

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();

                _heroImages.Add(bitmap);
            }
        }

        public static ImageSource GetHeroImage(int index)
        {
            return index >= 0 && index < _heroImages.Count ? _heroImages[index] : null;
        }
    }
}
