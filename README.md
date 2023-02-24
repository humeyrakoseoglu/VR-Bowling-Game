
# VR Bowling Game 🎳 - Unity Game Engine

Multiplayer game with voice talk<br/><br/>
We used Unity's Photon Unity Networking package to design a multiplayer game. For the voice chat function, we used the Photon Voice Chat package. <br/>
Photon Unity Networking (Unity Multiplayer): https://www.photonengine.com/pun<br/>
Photon Voice Chat package (Multiplayer Voice Chat): https://assetstore.unity.com/packages/tools/audio/photon-voice-2-130518<br/>
Avatars: https://www.mixamo.com/<br/>
Indoor Sports - Mixed Room Pack (Environment): https://assetstore.unity.com/packages/3d/environments/indoor-sports-mixed-room-pack-60418<br/><br/>

##  What it does ?
In our project, players play bowling with their friends just like in real life. The rooms are arranged so that the number of players is two. After connecting to the server, the player can create a room or join an existing room by entering its name. In this way, friends can enter the room with the same name and play games together. With the voice chat feature, they can talk to each other during the game. 

### Bowling Game
Bowling is a game based on the logic of knocking down the pins at the end of the game line with a bowling ball. 
### Rules
Rules are pretty simple,
<ul>
<li>The game consists of 5 sets</li>
<li>Each player has two shot per set. </li>
<li>If players throw the ball out of the bowling alley, they take 0 points.</li>
<li>layer who collects the highest score wins.</li>
</ul>

### Platform
PC, Mac & Linux Standalone

### Architecture
<img src="https://user-images.githubusercontent.com/71442681/221169715-ec681a7b-5d75-4aee-85b6-4aff67ebf672.png" width="400" height="250">



##  How we build it ?
Our game consists of 3 scenes. In the game, there is a "Loading" scene for connecting to the server, a "Lobby" scene where the rooms where the players can be synchronized over the network are created or joined to the existing room, and the main scene where our game is played is the "Game" scene. In the lobby scene, we receive an input from the user for gender selection and we assign an avatar according to the input we receive. We selected these avatars from the “Mixamo” site and transferred them to our project. Again, we get an input for the room name in the Lobby. We use it to create a room or join an existing room. By clicking the "Create" or "Join" buttons, we have entered the game. We designed a game room on the “Game” stage. For this environment, we used the "Indoor Sports - Mixed Room" package from the Unity Asset Store. We prepared a bowling game line in one of the rooms and placed the pins. Our game is played in accordance with the rules we have mentioned here. In order to show the score status in the game, we have prepared a score table in the hall where the scores of the players are kept.

## Screenshots:
### Loading Scene
<img src="https://user-images.githubusercontent.com/71442681/221162481-1670ae22-1ee0-4f41-bf93-e3be57619772.png" width="400" height="250">

### Lobby Scene
Create And Join Room 321 <br/>
<img src="https://user-images.githubusercontent.com/71442681/221167535-8eaf173b-2328-46f6-af6f-7b0a98780416.png" width="400" height="250">
<img src="https://user-images.githubusercontent.com/71442681/221167992-125bd42f-25a6-40bd-978e-52cc6c2b9b23.png" width="400" height="250">

### Game Scene
<img src="https://user-images.githubusercontent.com/71442681/221168050-33c396ac-212d-4628-b1ec-a83a06b4bfa8.png" width="400" height="250">
<img src="https://user-images.githubusercontent.com/71442681/221168119-9f114c19-14d5-458d-be7b-3448b7fd4db2.png" width="400" height="250">
<img src="https://user-images.githubusercontent.com/71442681/221168129-96da1d6b-3b44-4797-a114-b19c7591ebd6.png" width="400" height="250">
<img src="https://user-images.githubusercontent.com/71442681/221168186-508313e3-b671-4eed-9e9f-1c9d58e92451.png" width="400" height="250">
<img src="https://user-images.githubusercontent.com/71442681/221168297-51fe39d4-c2ee-4104-8a46-390bd84e7c68.png" width="400" height="250">

### Avatars
MALE <br/>
<img src="https://user-images.githubusercontent.com/71442681/221167736-7789f0c0-e635-4d29-8a4c-921766591636.png" width="400" height="250"><br/>
FEMALE <br/>
<img src="https://user-images.githubusercontent.com/71442681/221167874-119e1a5f-99cf-4236-a174-c74ff1668430.png" width="400" height="250">
