# Image-Converter
Converts images with .NET supported formats + WebP

CLI app. List of supported arguments:
<input file> [depth] [output extension(s)] [output file]

(you can rename the exe to a smaller name if you want, it'll work with the new exe name)

Input/Output images can be one of these
<pre>
bmp
gif
jpeg
jpg
png
tif
tiff
<-- note: the formats below won't work as output if the input image doesn't meet a certain criteria -->
webp
ico
memorybmp
exif
wmf
emf
</pre>

Depth can be one of these
<pre>
1
4
8
16
24
32
48
64
16argb1555
16rgb555
16gray
32pargb
32rgb
64pargb
</pre>

Depth names with description
<pre>
1  (each pixel is stored on one bit and is an index to a palette of 2 colours)
4  (each pixel is stored on 4 bits and is an index to a palette of 16 colours)
8  (each pixel is stored on 8 bits and is an index to a palette of 256 colours)
16 / 16rgb565 / rgb565 (each pixel is stored on 16 bits)
24 / rgb (24 bits per pixel, one byte red, one byte green, one byte blue)
32 / rgba (32 bits per pixel, one byte for each channel: red, green, blue, alpha)
48 (48 bits per pixel. two bytes red, two bytes green, two bytes blue)
64 (64 bits per pixel. two bytes red, two bytes green, two bytes blue, two bytes alpha)
16argb1555 / 16argb / 16a / argb1555 (one bit alpha, 5 bits red, 5 bits green, 5 bits blue)
16rgb555 / 16555 (one unused bit, then 5 bit for each channel: red, green, blue)
16gray / 16grey / 16g (each pixel is a 16-bit shade of gray)
32pargb / 32p / pargb ("the red, green, and blue components are premultiplied according to the alpha component")
32rgb / 32r (for each pixel: one byte red, one byte green, one byte blue, and one unused byte. this happens when bmp version (0x1E) is set to 0 
64pargb / 64p ("the red, green, and blue components are premultiplied according to the alpha component")
</pre>

## about WebP Support
WepP images can only be 24-bit RGB or 32-bit RGBA. this means you must add the parameter "24" or "32" if the output image format is webp. <br>
I took the source code of <a href="https://github.com/JosePineiro/WebP-wrapper">this repository</a> and I modified it a little so I could get the width and the height of the encoded webp image.

## examples:
no matter which format you choose, the syntax is the same. here's some commands examples which covers most features <br>
feel free to rename the exe, so it's faster to use it. <br>
Alternatively, you can make .bat files or .lnk shortcuts with custom icons to encode to a specific format.

#### Convert png to jpeg
output file: apple_yoshi.jpeg
<pre>WebP-convert.exe yoshi.png apple_yoshi.jpeg</pre>

#### Convert bmp to jpeg and ico and tiff on a specific output folder
output files: C:/whatever/new_yoshi.jpeg, C:/whatever/new_yoshi.ico, C:/whatever/new_yoshi.tiff
(ico max dimensions are 256x256, trying to produce an image above this will throw an error)
<pre>WebP-convert.exe yoshi.bmp ico tiff C:/whatever/new_yoshi.jpeg</pre>

#### Convert gif to 24-bit depth webp and throws the stack trace if an error occurs
output file: yoshi64.webp
<pre>WebP-convert.exe yoshi.gif 24 webp yoshi64</pre>

#### Convert webp to 64-bit bmp and make the console silent (it won't output the created files or tell you an error occured)
output file: gal.bmp
<pre>WebP-convert.exe gal.webp 64 stfu gal.bmp</pre>
