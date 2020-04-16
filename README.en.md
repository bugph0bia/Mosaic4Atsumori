Mosaic4Atsumori
===

![Software Version](http://img.shields.io/badge/Version-v0.0.2-green.svg?style=flat)
![.NET Framework](http://img.shields.io/badge/.NET_Framework-v4.6.1-blue.svg?style=flat)
![VS Version](http://img.shields.io/badge/VisualStudio-2017-blue.svg?style=flat)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](LICENSE)

[Japanese Page](./README.md)

## Overview
A tool to help you create your My Design for "Animal Crossing: New Horizons".
  
This is for Windows only.

![main](https://user-images.githubusercontent.com/18702413/79063578-876e7080-7cdd-11ea-8487-713fc93fb072.png)

### What you can do
- Image files are converted to mosaic art (dot picture) in the following format and displayed.
    - Width: 32px
    - Height: 32px
    - Color palette: less than 15 colors
- Displays "Hue" "Vividness" and "Brightness" of the palette color to be used.
- Highlight the selected palette color.

### What you can't do
- Image conversion to non-32x32.
- QR code creation.

## Version
v0.0.2

## Download
You can download v0.0.2 [here](https://github.com/mat2umoto/Mosaic4Atsumori/releases/download/v0.0.2/Mosaic4Atsumori.zip) .

## Requirements
- Windows OS
- NET Framework V4.6.1 or later

## Development Environment
Visual Studio 2017

## License
MIT License

## Install/Uninstall
### How to install
Just put `Mosaic4Atsumotri.exe` in an any directory and run it.  

### How to Uninstall
Remove `Mosaic4Atsumotri.exe`. The registry is not used.

## How to use
### Operation Flow
1. Run `Mosaic4Atsumotri.exe` by double-click etc.
2. Import image files (bmp, jpg, png, gif) by clicking the button on the top left of the screen or drag and drop them.
3. The image will be converted to mosaic art and displayed, so you can create My Design while looking at it.


### About the palette

![palette](https://user-images.githubusercontent.com/18702413/79063581-889f9d80-7cdd-11ea-8308-fad304efcc6a.png)

- A palette of up to 15 colors is displayed at the top of the image display area, allowing you to see up to colors used in the image.  
- The palette is arranged in the order of the most used places in the image.  
- When you click on one of the palettes, you can use it to create a color by displaying the color's "Hue", "Vividness" and "Brightness" on the right side.  
- It highlights where the clicked color is used in the image and shows the number of times that color is used in each row or column, so you can use it as a hint when creating My Design.  

Note:
- If the window size is small, the numbers in the column direction will be broke.  
- If less than 15 colors are used, the rest of the palette will turn white and will not respond when clicked.
