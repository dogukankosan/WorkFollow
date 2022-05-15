using System;
using System.Drawing;
using System.IO;
namespace MVCFirmaCagri.ImageBinary
{
    public class BinaryImage
    {
        public static string ToBase64ImageString(byte[] data)
        {
            if (data is null)
                return null;
            return string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(data));
        }
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}