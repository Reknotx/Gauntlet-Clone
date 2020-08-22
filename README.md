# Gauntlet-Clone
Clone of the Arcade Game Gauntlet for CAGD 380
Goal of this class project was to create a clone of the arcade game with multiplayer functionality.
Input was created with the use of the new Unity Input System package. Multiplayer is unfortunately
not implemented due to lack of time and documentation to properly implement one. Project is buildable
for execution on windows machines and requires an xbox controller to be played.

Code structure was designed around the Model-View-Controller software design pattern for both simplicity
and for organizational purposes, separating the data from the logic. 

Within the scripts folder

Data - Contains all the information for the game's systems.
  - Individual enemy information is stored within a scriptable object rather than being assigned values in the inspector.
  - Stats for each of the player classes are stored in scriptable objects to allow for more dynamic loading at the game start.
  Allows for players to choose their classes at the start.

Controllers - Handles the logic for the game in terms of combat, pick up behavior, world interaction behavior,
individual player input and movement (if it was setup), etc.
  - Every individual type of event that can happen in the game will be sent to the appropriate controller to filter the message
  and update the necessary data in the game.
  - Controllers are set up to filter the messages to players appropriately. 

View - Handles input detection and passes event callbacks to the controller.
  - Player input and collision detection are separated into their own scripts and inherit from a parent. This is to allow for 
  messages to be handled in one central location and to allow for code reuse.
  - Weapons are given their own collision detection scripts that send messages to the correct controller.


