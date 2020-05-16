# AppNapRepro
Repro of a vanilla Xamarin.Mac app napping despite being instructed not to.

## Steps to reproduce

1. On a Mac, open the .sln file using Visual Studio for Mac 2019.
2. Hit Play, i.e., run the app in Debug mode.
3. Minimise the app and cover Visual Studio (VS) with another application (not sure if it's significant but that's what I did).
4. Lock the Mac, go away, do stuff for about half an hour.
5. Return to your Mac, unlock, and check the Application Output panel in VS.

## Expected result

6. There should not be a debug line reading: FFSakes Apple!

## Actual result

6. There is.

## Environment

OS: macOS Catalina, 10.15.4
Processor: 2.4 GHz Quad-Core Intel Core i5
