# Kookie3

> Kookie3 Media Player with un4seen BASS audio library

## About

Kookie3 is a media player based on [un4seen BASS audio library](https://www.un4seen.com/).
Supported for windows7 and above. Requires .NET framework 4.8 or above.

## Customized Interface

![ui1](mdsrc/ui1.png)

Kookie3 is **portable** and has minimal but **highly flexible UI**. Checkout some interface setting below.
___

![ui2](mdsrc/ui2.png)

**Transparent UI with opacity control**
___

![ui3](mdsrc/ui3.png)

**Resize UI and Dock seekbar & art as you like**
___

![ui4](mdsrc/ui4.png)

**Minimal UI with only a seekbar**
___

![ui5](mdsrc/ui5.png)

**Multi-Line Lable with TV-style UI**
___

![ui6](mdsrc/ui6.png)

**Fully Transparent Docked Player**
___

![ui7](mdsrc/ui7.png)

**Solid Lable with transparent art**
___

![ui8](mdsrc/ui8.png)

**Fully Solid (opaque) UI**
___

![ui9](mdsrc/ui9.png)

**Auto color matching UI** : Note - color matching is b/w art background and label background, this works during Hue shift as well.
___

![ui10](mdsrc/ui10.png)

**No Lable UI**
___

![ui11](mdsrc/ui11.gif)

**Full Hue shift with RGB effects** : turn on *Hue Shift* in settings
___

## Installation

Kookie3 is stand-alone, no installation required. You can compile from source code or use pre-compiled binaries available in zip format.

* [Download](https://github.com/Nelson-iitp/Kookie3/raw/main/Kookie3/Kookie3.zip) and Extract zip

![1](mdsrc/1.png "Download and Extract")

* Run `Kookie3.exe` executable, **drag-drop** files to play

![2](mdsrc/2.png "Run Executable")

* Press 'L' to view library and 'P' to view playlist
___

**Note:**
* make sure BASS related dlls `bass.dll` and `Bass.Net.dll` are in the same directory as the executable `Kookie3.exe`

![3](mdsrc/3.png "BASS dlls")

* on the first run, you shall be prompted to create a **default library** - click yes to create default library
	![4](mdsrc/4.png "first-run")
	* you must have a default library which is just a text file `k3.lib` created under app directory
	* also, default settings file `k3.ini` will be created under app directory on first run

![5](mdsrc/5.png "startup")

* After creating settings and library file, Kookie3 default interface will show up.
	* **right-click** to see alt-menu
	
![6](mdsrc/6.png "alt-menu")

* click on '**Setting -> Show Configuration**' menu item to see settings window

![7](mdsrc/7.png "setting window")

* '**Art/Art_Default'** can be choosen to set app background
	* some app backgrounds are provided within, check the folder `k3art` under app directory
* '**Art/Art_Always_Show_Default'** can be turned **False** to show album art when available
___


## UI Controls

Kookie3 is mainly focused on quick-keyboard shortcuts but all functionality can be accessed using mouse as well.

## Mouse Controls
* seekbar can be clicked
* volume control with mouse wheel
* drag-drop to open files/folders - works on UI, Library and Playlist
* press and hold left-mouse-button to move window
* right-click to see alt-menu

## Keyboard Controls

### General

|Action----------------------------|Key----------------------------|
|:------|:------|
|Exit|Escape|
|Show Playlist|P|
|Show Library|L|
|Toggle File Drop Target|D|
|Show Settings|E|
|Show Devices|V|
|Reinitialize BASS device|Enter|
|Open App Directory|F2|
|Visit Website|F1|


### Media Control

|Action----------------------------|Key----------------------------|
|:------|:------|
|Play/Pause|Space|
|Restart|ctrl + Space|
|Next/Prev Track|Right/Left|
|Seek +/-5 seconds|shift + Right/Left|
|Seek +/-30 seconds|ctrl + Right/Left|
|Seek +/-2 minutes|ctrl + shift + Right/Left|
|Volume +/-01|Up/Down|
|Volume +/-02|shift + Up/Down|
|Volume +/-05|ctrl + Up/Down|
|Volume +/-10|ctrl + shift + Up/Down|
|Mark As Favourite|F|
|Display media information|I|

### Playlist Control

|Action----------------------------|Key----------------------------|
|:------|:------|
|Clear Playlist|ctrl + X|
|Shuffle Playlist Once|S|
|Toggle Repeat Single|R|
|Toggle Repeat All|shift + R|
|Toggle Reversed Playlist|ctrl + shift + R|


### UI Size

|Action----------------------------|Key----------------------------|
|:------|:------|
|Width +/- 5px|shift + Add/Subtract|
|Width +/- 1px|shift + Multiply/Divide|
|Height +/- 5px|ctrl + Add/Subtract|
|Height +/- 1px|ctrl + Multiply/Divide|
|X-Axis +/- 1px|ctrl + shift + Add/Subtract|
|Y-Axis +/- 1px|ctrl + shift + Multiply/Divide|

### UI Visibility

|Action----------------------------|Key----------------------------|
|:------|:------|
|Opacity +/- 5%|Add/Subtract|
|Opacity +/- 1%|Multiply/Divide|
|Toggle Hidden Label|H|
|Toggle Hidden Seekbar|ctrl + H|
|Toggle Hide in Taskbar|shift + H|
|Toggle TopMost|ctrl + T|
|Center Screen UI|ctrl + C|
|Center Screen UI if out of bounds|C|
|Auto-size UI|ctrl + B|

### Misc

|Action----------------------------|Key----------------------------|
|:------|:------|
|Toggle Hue Shift|T|
|Choose Custom Default Art|A|
|Set Color as Background|shift + S|
|Load Config Changes|ctrl + O|
|Save Config Changes|ctrl + S|
|Save As Config Changes|ctrl + shift + S|



### On Library View

|Action----------------------------|Key----------------------------|
|:------|:------|
|Close|Escape
|Clear Playlist|ctrl + X|
|Find in Library|ctrl + F|
|Find Next|F3|
|Select All|ctrl + A|
|Select None|ctrl + L|
|Toggle Grouped View|ctrl + G|
|Show Info about selected item|F1|


### On PlayList View

|Action----------------------------|Key----------------------------|
|:------|:------|
|Play Now|Enter|
|Shuffle Once |ctrl + S|
|Select All|ctrl + A|
|Select None|ctrl + L|
|Remove Selected Tracks|Delete|
|Clear Playlist|ctrl + X|
|Find in Playlist|ctrl + F|
|Find Next|F3|
|Locate Current Track|Space|

___
