namespace CfxUtils.Wrappers.Chat
{
    public static class ColorExtensions
    {
        public static string ToHex(this System.Drawing.Color color)
        {
            return $"#{color.ToArgb() & 0x00FFFFFF:X6}";
        }
    }
}