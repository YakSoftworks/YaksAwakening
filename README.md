# Yaks Awakening
## Current State: Slow Rolling Development

## Player:
The player is set up with movement and pausing. The general player setup is in a prefab.

## World:
In Prefabs, there is a RoomTemplate prefab which contains the basic prefab of the bare minimum of a room.
This includes the Room script and the basic tilemap.

## Core:
The core of the game includes the game manager which handles a large portion of the room changing.


# Working with the Content
In order to develop, the developer should know the following quirks and requirements for general functionality

## Player:
The Player can be added to much like any player character. To add functionality add to either PlayerController or to PlayerMovement

## World:
To create a new room prefab, create a prefab Variant of the Room Template. To add respawnable objects to the new room, you need to add an ObjectSpawner for it. In the object spawner, you will add the prefab of the object you want at that location. Whenever the room is enabled, the object will be re-instantiated. After making the objectSpawner in the room, you need to add it to the list of spawners contained within the Room script. The room script handles all of the calling of functions within rooms. 

## Core:
You shouldn't need to edit the Core.
