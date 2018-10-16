# Introduction
Hi! Welcome to have a view of this project. <br>

This project contains anything that I have helped with my fellows' project, so most of them are about HoloLens/UWP development.
I recommend you to download Unity pages instead of git clone or downloading zip file, and ```please install MixedRealityToolkit-Unity(MRTK) before you import packages```(URL:https://github.com/Microsoft/MixedRealityToolkit-Unity)
<br>

This project would be updated on a monthly basis. ;-)  <br>
Good luck!


# Scene: WorldPositionSaver
Same from the default function - WorldAnchor, this solution is trying to duplicate the WorldAnchor function which extracts Object name, position, and rotation included.  <br>
For a reason, considering the instantiated GameOject newly cannot be saved into ```WorldAnchorStore.cs``` correctly,
this process could be utilized to take the place of WorldAnchor. <br>

## Contents:
This project is using XML to save the position information by the ```GameController.cs```. <br>
Those objects that you want to save should add a ```Actor.cs``` component. ```Name``` is free to set. <br>
Data would be written into ```Data/actors.xml```, and as I mentioned before because it is using two different platforms (UnityEditor and UWP), so the ```PATH``` setting is also included.



