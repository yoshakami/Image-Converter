# Image-Converter
Converts images with .NET supported formats

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
<-- note: these crashes the app if the input image doesn't meet a certain criteria -->
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

## examples:
#### Convert png to exif
output file: apple_yoshi.exif
<pre>ImageConv.exe yoshi.png apple_yoshi.exif</pre>

#### Convert bmp to jpeg and ico and tiff on a specific output folder
output files: C:/whatever/new_yoshi.jpeg, C:/whatever/new_yoshi.ico, C:/whatever/new_yoshi.tiff
<pre>ImageConv.exe yoshi.bmp ico tiff C:/whatever/new_yoshi.jpeg</pre>

#### Convert gif to 64-bit depth png
output file: yoshi64.png
<pre>ImageConv.exe yoshi.gif png yoshi64</pre>
