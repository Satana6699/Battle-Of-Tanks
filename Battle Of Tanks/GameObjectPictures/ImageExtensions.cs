using System.Drawing;

public static class ImageExtensions
{
    public static Image Resize(this Image originalImage, int newWidth, int newHeight)
    {
        Bitmap resizedImage = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
        }
        return resizedImage;
    }
}
