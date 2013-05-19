pixlib
======
Pixlib is a fast and simple image processing utility for all .NET languages.

The ```IPixelProvider``` defines classes that can provide pixel data while the ```IPixelScanner``` defines classes that can work with this pixel data.

Out of the box, there are two ```IPixelProvider```s. ```FastBitmapPixelProvider``` and ```SlowBitmapPixel``` provider. The "fast" one uses Lockbits and unsafe pointers to retrieve the pixel data while the "slower" version uses the built-in Get-/SetPixel methods of the .NET ```Bitmap```-object.

Also, there is an advanced color tolerance system which you can use to find colors ignoring channels.

Here are some usage examples of these two classes:

```C#
var testBitmap = new Bitmap("a.png");
using (var provider = new FastBitmapPixelProvider(testBitmap))
{
  var scanner = new DefaultScanner(provider);
  scanner.View = new Rectangle(10, 10, 20, 20); // Only look in this rectangle
      
  var tolerance = new ColorTolerance(10, true); // Allow a tolerance of 10 and ignore the alpha channel
  Color color = Color.White;
  
  IEnumerable<Pixel> pixels = scanner.FindPixels(color, tolerance);
  var colors = pixels.Select(p => p.Color); // here we go
}
```
