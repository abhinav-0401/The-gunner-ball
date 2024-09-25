# THE GUNNER BALL

The Gunner Ball is a top down survival shooter game. This game was build on Unity game engine.

### Description:
NOTE : All the inputs are taken using Unity Engine API

MOVEMENT & AIM:
  - Player Movement : Movement of the player character was implemented by updating player's position with every frame. The directions of movement was given by the user in x and y directions having a magnitude of 1 which was then multiplied by a runSpeed(speed of the player) variable. Also when going in diagonal directions, the speed was dimmed by 0.7*runSpeed.
  - Player aim: Player is supposed to look in the direction of the mouse pointer. So for that we took mouse position input and made a vector between mouse position and player face direction. Then player's current angle w.r.t to the direction vector was calculted and using rigidbody physics it was rotated towards that angle with a certain speed.
  - Enemy Movement or Enemy AI: Enemy's aim was implemented using vector calculations. A direction vector was made between player position and enemy position. Then the angle was calculated between current direction vector and enemy face direction and then it was rotated towards the direction vector. Enemy's movements is also implemented using the direction vector. The enemy is given a velocity in direction of direction vector.
 
GUN SYSTEM: 
  - For the gun system a gun class was made which of a single constructor and various other variable which contains information about the gun. Gun class also have several methods to extract the information from a particular gun in another script. 
  - Another gun container class was made where all kinds of guns were stored as static objects.
  - These gun obejcts from the gun container class were called in player and enemy objects for implementing shooting mechanism and multi_bullet shooting powerup.
 
MUSIC & AUDIO: 
  - Music and audio was implemented using "Singleton Design Pattern". 
  - In the main menu scene a MusicManager object was created and MusicManager script was attached on it which allowed only one instance of that gameobejct in the entire game. So now to play the audio effects MusicManager object is accessed and audioclip(which is attached on the triggering gameobejct) is passed as argument in the Play() method of MusicManger. Similarly background Music is also played in the game.
  
MAP GENERATION: 
  - A map generation algorithm was used to spawn powerups and enemies and bosses.
  - The algorithm works as follows:
    - At first the limits of the arena is defined, which is x , y limits.
    - Then a list of enemies and powerups is defined in seperate identical scripts.
    - Then in the project window all the enemy prefabs and powerup prefabs are added in the respective lists.
    - Now in for loop random x and y values are taken inside the arena and at that position a tandom enemy or powerup prefab from their lists is instantiated until the loop stops.
    - The no. of powerups and enemies to be spawned is increasing at every 10 sec.
    
SPECIAL EFFECTS: 
  - Camera Shake : Camera Shake brings some liveliness to any game. This effect was implemented using spring joint component. At first the Main camera is made the child of an empty game object(camera_follower) and camera follow script is attached on that. The camera_follower game object has given a rigidbody2d and that rigidbody is given to the attached rigidbody field in the spring joint in the MainCamera. Now a small force is given to the Main Camera in a random direction and the linear drag is set to a magnitufe of 15 so that the vibrations can decay after some time.
  - LeanTween : Tweening is the process of generating intermediate frames between two images, called key frames, to give the appearance that the first image evolves smoothly into the second image. LeanTween is a free open source package available on Unity Asset store. It was used to create several animations in the game.
  - Particle Effects/Animations : A particle system is a technique in game physics, motion graphics, and computer graphics that uses many minute sprites, 3D models, or other graphic objects to simulate certain kinds of "fuzzy" phenomena, which are otherwise very hard to reproduce with conventional rendering techniques. Various particle animations like death effects and smoke effects were made using the Unity's Inbuilt particle system. A particle system manager gameobject is used to store all 
the animations and was accessed whenever needed using Unity API.

UI ELEMENTS : 
  - Canvas Component : Unity's canvas gameobject is used to create all the UI elements of the game. In Unity, the Canvas is also a Game Object with a Canvas component attached to it. This Canvas component acts as the master of all UI elements on the screen. That's why all UI elements are child gameObject of the Canvas gameObject.

JOYSTICK : 
  - For joysticks, a free joystick package is used to gove controls on an android device.
## SCREENSHOTS

![sc1](https://user-images.githubusercontent.com/87766488/180740733-384a5bf7-4a17-4dc8-9362-14de1f98bce4.png)
![sc2](https://user-images.githubusercontent.com/87766488/180740877-4629cf91-83ab-4cd3-9199-26e8f8e38d6a.png)
![sc4](https://user-images.githubusercontent.com/87766488/180740955-dbd9237a-54d4-4f5e-ba5e-1a56474b9682.png)
![sc5](https://user-images.githubusercontent.com/87766488/180741145-5a5d3ba4-90d4-484f-abe0-63bdecac85b5.png)

## DOWNLOAD LINK

[Download the android and desktop version(Windows) from itch.io](https://arun-game-dev.itch.io/the-gunner-man)
