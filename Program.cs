using System;
using System.IO;

internal class Program
{
    public static void Main(string[] args)
    {
        // check value
        var random1 = new CustomIndexRandom(1024);
        var random2 = new CustomIndexRandom(1024);
        var random3 = new CustomIndexRandom(1024);
        for (int i = 0; i < 9876; i++)
        {
            random1.NextDouble();
        }
        Console.WriteLine("random1 seed 1024, index 9876 is:" + random1.NextDouble()); // note: index is from 0
        Console.WriteLine("random2 seed 1024, index 9876 is:" + random2.NextDoubleByIndex(9876));
        Console.WriteLine("random3 seed 1024, index 9876 is:" + random3.NextDoubleByIndex(9876));
        
        // gen noise image
        /*
        var random = new CustomIndexRandom(1024);
        var size = 256;
        var pic = new System.Drawing.Bitmap(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                pic.SetPixel(i, j, System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            }
        }

        var path = Directory.GetCurrentDirectory();
        var fileName = Path.Combine(path, "noise.jpg");
        Console.WriteLine("filepath:" + fileName);
        pic.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        */
    }
}
