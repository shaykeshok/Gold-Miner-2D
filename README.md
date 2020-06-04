# Gold-Miner Game
In the game you collect gold, stones, and minerals to reach your daily goal. With the money you collect you can buy upgrades such as explosives, which let you mine more efficiently. 
Each stage has a 60-second timer that needs to be adhered to so as not to be disqualified.
This game is different from the original game because here in the game every stage has a number. Also on every stone, gold and diamond there is an account number or operator. The player must collect stones, gold and diamonds but not just collect but only collect the things that help create a formula whose solution is the number to have at that stage.
For example, if the number at a certain stage is 27 and the game has stones, gold and diamonds with the following numbers and operators: 2,3,4,5,6,0, +, *
The player must collect the elements with the following numbers: 6,4,3,4, * because if we create such a formula: (6*4)+3 we will get the number 27.
If the player has collected an element that does not help him to create a formula (in our case, for example, 0), he loses 10 seconds from the time of that stage but receives $ 10.

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

# photos

<img src="" target="_blank"/>

<img src="" />

Link to the game: <a href="" target="_blank"
