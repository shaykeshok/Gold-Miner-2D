# Gold-Miner Game
In the game you collect gold, stones, and minerals to reach your daily goal. With the money you collect you can buy upgrades such as power, which let you mine more efficiently. 
Each stage has a time that needs to be adhered to so as not to be disqualified.
This game is different from the original game because here in the game every stage has a formula in the top of the scene. Also on every stone, gold and diamond there is an account number or operator. The player must collect stones, gold and diamonds but not just collect but only collect the things that help solהe the a equation.
Each equation shows the number of elements needed to solve the equation.
For example, if the number at a certain stage is 27 and the number of elements that you need to collect is 5. The game has stones, gold and diamonds with the following numbers and operators: 2,3,4,5,6,0, +, *
The player must collect the elements with the following numbers: 6,4,3,*,+ because if we create such a formula: (6*4)+3 we will get the number 27.
If the player has collected an element that does not help him to solve the equation (in our case, for example, 0), he loses 10 seconds from the time of that stage but receives $ 10.
The money accumulated in each turn is used to buy in the game store where there is an option to buy upgrades like: power, bomb, 10 seconds extra and a hint. Only one quantity per item can be purchased per stage and all items are valid only for that one stage.
# Components

We used the right sounds for every moment of the game. For example, if the timer reaches the last 10 seconds of the same stage, the music changes to something appropriate.
We have a menu management component where you can choose to play or quit the game.
We have a number of animations:
1. Throwing the rope
2. Player animation

In the GAMEPLAYMANAGER component, we have the following:
1. Function responsible for the phase timer
2. A function responsible for counting the player's point count at that stage
3. A function responsible for moving the actor to the correct scene according to his actions.
4. Responsible for the treatment of the formula
5. Responsible on play the products that the player buy in the market.
Sound component:
An element responsible for sound management in the game

TAG component:
A component that holds constant names for the commonly used scripts.

HEADSCRIPT component:
Responsible for the actions that happen when you conflict with one of the elements in the game

HOOKMOVEMENT component:
Responsible for everything related to throwing the rope and turning the hook. This component listens to the mouse click that tells the script to drop the rope.
This script also defines the rope length settings

PLAYERANIMATION component:
Responsible for running the player's animations

MainMenu component:
Responsible for the menu scene

LevelSelector component:
Responsible for the selector level scene. 
Responsible for turning the buttons off and on as the player progressesץ

Market component:
Responsible for the market of the game.

sceneFader component:
Responsible for the redirect of scene in the game.

# Video

<iframe width="420" height="345" src="https://youtu.be/wipXZ2D1j9g">
</iframe>

# photos

<img src="https://github.com/shaykeshok/Gold-Miner-2D/blob/master/menu.PNG" width="400px" height="200px">

<img src="https://github.com/shaykeshok/Gold-Miner-2D/blob/master/Capturesdf.PNG" width="400px" height="200px">

<img src="https://github.com/shaykeshok/Gold-Miner-2D/blob/master/Captsure.PNG" width="400px" height="200px">

<img src="https://github.com/shaykeshok/Gold-Miner-2D/blob/master/Capasfasfture.PNG" width="400px" height="200px">

Link to the game: <a href="https://shaykeshok.itch.io/gold-minner" target="_blank">Gold miner</a>
