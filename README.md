# Kookie3

> Kookie3 Media Player with un4seen BASS audio library

## About

Kookie3 is a media player based on [un4seen BASS audio library](https://www.un4seen.com/).
Supported for windows7 and above. Requires .NET framework 4.8 or above.

## Customized Interface

![ui1](mdsrc/ui1.png)

Kookie3 is **portable** and has **highly flexible UI**. Checkout some interface setting below.
___

![ui2](mdsrc/ui2.png)

**Transparent UIs with opacity control**
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

**Solid Lable with solid art**
___

![ui9](mdsrc/ui9.png)

**Auto color matching UI**
___

![ui10](mdsrc/ui10.png)

**No Lable - only seekbar and album-art in UI**
___

![ui11](mdsrc/ui11.gif)

**Full Hue shift with RGB effects** : turn on *Hue Shift* in settings
___

## Installation

Kookie3 is stand-alone, no installation required. 

* [Download](https://github.com/Nelson-iitp/Kookie3/raw/main/Kookie3/Kookie3.zip) and Extract zip

![1](mdsrc/1.png "Download and Extract")

* Run `Kookie3.exe` executable, **drag-drop** files to play

![2](mdsrc/2.png "Run Executable")

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

* click on '**setting**' menu item to see all settings window

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
* drag-drop to open files/folders
* press and hold left-mouse-button to move window
* right-click to see alt-menu

## Keyboard Controls


### General
```
Exit  ::  Keys.Escape
Show Devices :: Keys.E
Show Playlist  ::  Keys.P
Show Library  ::  Keys.L
Toggle File Drop Target  :: Keys.D
Reinitialize BASS device  ::  Keys.Enter
```

### Media Control
```
Play/Pause  ::  Keys.Space
Restart  ::  ctrl + Keys.Space
Next/Prev Track  ::  Keys.Right/Left
Clear Playlist  ::  ctrl + Keys.X
Shuffle Playlist Once  ::  Keys.S
Toggle Repeat Single  ::  Keys.R
```

### Volume Control
```
Volume up +/-01 :: Keys.Up/Down
Volume up +/-02 :: shift + Keys.Up/Down
Volume up +/-05 :: ctrl + Keys.Up/Down
Volume up +/-10 :: ctrl + shift + Keys.Up/Down
Seek Media +/- 05sec :: shift + Keys.Right/Left
Seek Media +/- 50sec :: ctrl + Keys.Right/Left
```

### Playlist Control
```
Mark As Favourite  ::  Keys.F
Toggle Auto-Play  ::  Keys.A
Toggle Random Starting Track  ::  ctrl + Keys.A
Toggle Reversed Playlist  ::  ctrl + shift + Keys.R
Toggle Auto-Remove unplayable media  ::  ctrl + Keys.X
```

### UI Arts & Colors
```
Choose Background Color  ::  Keys.D1
Choose Foreground Color  ::  Keys.D2
Choose Font Style  ::  Keys.D3
Choose Transperancy Key :: Keys.D4
Clear Transperancy Key :: Leys.D5
Choose Custom Default Art :: Keys.D6
Show AlbumArt :: Keys.Z
Dock AlbumArt :: Ctrl + Keys.Z
```

### UI and Taskbar
```
Toggle TopMost :: ctrl + Keys.T
Toggle Hidden Seekbar  ::  ctrl + Keys.H
Toggle Hidden Label  ::  Keys.H
Toggle Hide in Taskbar :: shift + Keys.H
```


### UI Hue Shift
```
Toggle Hue Shift  ::  Keys.T
Set HueShift Angle :: shift + Keys.T
```

### UI Size and Opacity
```
Opacity +/- 5% :: Keys.Add/Subtract
Opacity +/- 1% :: Keys.Multiply/Keys.Divide
Width +/- 5px :: shift + Keys.Add/Subtract
Width +/- 1px :: shift + Keys.Multiply/Keys.Divide
Height +/- 5px :: ctrl + Keys.Add/Subtract
Height +/- 1px :: ctrl + Keys.Multiply/Keys.Divide
X-Axis +/- 1px :: ctrl + shift + Keys.Add/Subtract
Y-Axis +/- 1px :: ctrl + shift + Keys.Multiply/Keys.Divide
```

### Misc
```
Change Startup Msg  ::  Keys.M
Display status information  ::  ctrl + Keys.I
Display media information  ::  Keys.I
Save Changes  ::  ctrl + Keys.S
```


### On Library View
```
Close  ::  Keys.Escape
Clear Playlist  ::  ctrl + Keys.X
Find in Library  ::  ctrl + Keys.F
Find Next  ::  Keys.F3
Select All  ::  ctrl + Keys.A
Select None  ::  ctrl + Keys.L
Toggle Grouped View  ::  ctrl + Keys.G
Show Info about selected item  ::  Keys.F1
```

### On PlayList View
```
Play Now  ::  Keys.Enter
Shuffle Once  :: ctrl + Keys.S
Select All  ::  ctrl + Keys.A
Select None  ::  ctrl + Keys.L
Remove Selected Tracks  ::  Keys.Delete
Clear Playlist  ::  ctrl + Keys.X
Find in Playlist  ::  ctrl + Keys.F
Find Next  ::  Keys.F3
Locate Current Track  ::  Keys.Space
```
