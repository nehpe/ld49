using System.Reflection;

namespace Ccc
{
    public static class CccSettings
    {
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 720;

        public static string VERSION => Assembly.GetEntryAssembly().GetName().Version.ToString();
    }
}
