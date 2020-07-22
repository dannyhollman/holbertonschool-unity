# 0x05. Unity - Assets: Models, Textures

## Description
What you should learn from this project:

* What is an Asset and how to import and use them
* How to use Asset Packages and the Unity Asset Store
* What are common Asset types
* How to use Unity primitives as placeholders to prototype a project
* What are materials and how to use them
* What are textures and how to use them
* What is a skybox
* What is are the components of a 3D model
* What is a mesh
* How to create UI elements with image components
* What is a Rigidbody and what is a Character Controller and what are the pros and cons of using each
* What is a Quaternion

---

### [0. Primitive player](./Assets/Scenes/Level01.unity)
* Create a new Scene called Level01. Create a capsule GameObject called Player which will be a placeholder for this project.


### [1. Primitive prototype](./Assets/Scenes/Level01.unity)
* In the Level01 scene, create a layout of floating platforms of different sizes and positions using only Unity Cube GameObjects, . Plan for a start point and an endpoint and create a path so that the Player can jump between them. The cubes will be placeholders for 3D models that we will import later on.


### [2. Pole position](./Assets/Scenes/Level01.unity)
* At the end point of the platforms, create a placeholder cylinder GameObject called WinFlag to designate the end of the path. Do not make WinFlag a child of any object. Later we will add scripting for when the Player reaches the WinFlag.


### [3. Jump man](./Assets/Scenes/Level01.unity)
* Create a new folder called Scripts. Inside that folder, create a new C# script called PlayerController and attach it to Player.


### [4. Camera ready](./Assets/Scenes/Level01.unity)
* Position the Main Camera at an offset behind the player. 


### [5. Steady cam](./Assets/Scenes/Level01.unity)
* In the Scripts folder, create a new C# script called CameraController that allows the camera to follow the player. The script should also allow the player to rotate the camera on their own by moving the mouse, either by just moving the mouse or holding down right-click and dragging the mouse to move the camera.


### [6. Falling up](./Assets/Scenes/Level01.unity)
* Currently if the player falls off a platform, it falls infinitely. Edit the PlayerController and CameraController scripts so that if the player falls from a platform and can’t get to another platform, the player instead falls from the top of the screen onto the start position, causing the player to need to start from the beginning again.


### [7. Time trial](./Assets/Scenes/Level01.unity)
* Create a new Canvas and UI Text element that displays a timer on screen.


### [8. Clock's ticking](./Assets/Scenes/Level01.unity)
* Create a script called Timer and attach to the Player. Timer should have a public Text variable called Timer Text for the TimerText Text object.


### [9. Finish line](./Assets/Scenes/Level01.unity)
* Create a script called WinTrigger and attach to WinFlag.


### [10. The sky's the limit](./Assets/Scenes/Level01.unity)
* In the Unity Asset Store, find Farland Skies - Cloudy Crown, a free set of skyboxes. Add them to a folder called Skyboxes in the Assets/Materials folder in your 0x05-unity-assets project.


### [11. The great outdoors](./Assets/Scenes/Level01.unity)
* Download Kenney’s Nature Pack Extended. Import the asset package and place the files in a directory called Models. For the sake of organization, inside the Assets folder, create a new directory called Materials and move the materials in Models into Materials.


### [12. Environmental awareness](./Assets/Scenes/Level01.unity)
* From the Nature Pack asset package in your Models folder, add trees, rocks, flowers, etc. to the platforms as you like. Organize your objects in your Hierarchy using empty GameObjects.


### [13. What's left of the flag](./Assets/Scenes/Level01.unity)
* Download this flag model. Place it in the Models directory. Add Flag to your scene and make it a child of the WinFlag GameObject. The pole of the flag should be positioned inside WinFlag‘s collider. Resize or reposition the collider if necessary.


### [14. (Sea)horse race](./Assets/Scenes/Level01.unity)
* Download this flag texture. Place it in a new directory called Textures. 


### [15. Under development](./Builds/)
* Scenes in Build:

---

## Author
* **Danny Hollman** - [dannyhollman](https://github.com/dannyhollman)
