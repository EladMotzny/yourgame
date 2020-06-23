# Treasure Fight!

Play the game: https://mozy.itch.io/treasure-blast

Or watch the trailer: https://youtu.be/uHu_sIvoEBg

![image](https://user-images.githubusercontent.com/33173449/83664048-24f56a80-a5d2-11ea-928a-8c9ec3700a9d.png)

Meet Chey and mollu, once the best of friends but now bitter rivals fighting over booty and treasure

They decided to have one last competition for the biggest treasure of all!

The winner is whoever manages to blow up all the bubbles on his side of the screen

Use your arrow keys to move and aim up and down or W A S D and press CTRL or T to charge your shot

But of course... A pirate without cheating is like a ship without a crew...

Chey and mollu will do anything in their power to win! Including shooting at eachother

Every now and then the gate between the two will open, which will give them the opportunity to distrupt one another

Be careful not to lose all of your HP or you might lose!

And with that.. We wish them the best of luck!

## Game Rules

1. The players stay on their side all of the game.
2. You may shoot at your opponents bubbles only when the wall opens. Otherwise your bubble will pop.
3. If you hit the opponents bubble it will freeze and turn into a black bubble. The only way to unfreeze it is to shoot at it a normal bubble and it will apply to itself the shooting bubble color.
4. If you shoot on adifferent color bubble it will stick to it until you pop it.
5. The balls pop when shot on the screen [edges](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/BubbleCollision.cs#L29-L33) and on the middle wall.

### How to win?
1. If your opponent bubbles reached the bubble in the launcher.
2. If you clear all of the levels first.




## Game Code
![game](https://user-images.githubusercontent.com/33619352/85406741-e74d8700-b56a-11ea-8040-3ac5cc5c70c7.gif)


### The Boundaries
The characters are [bounded](https://github.com/EladMotzny/yourgame/blob/4b25f834acc82f7cc92cce9e468169a01cd2b160/Blast/Assets/Scripts/Boundaries.cs#L10-L45) in the screen view. In addition there is a wall that limits their movement to their side of the screen. Mollo- to the right. Chey- to the left.

### The Characters and Bubbles

Both characters [move](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/CharacterMove.cs#L32-L99) in their own side.

Each has a rocket launcher which [aims](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/GunAim.cs#L40-L64) and [shoots](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/MolluShoot.cs#L45-L55) the bubbles to the map.

  1. The bubbles will [pop](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/BubbleCollision.cs#L37-L49) only when they hit the same color.
  2. If a different color bubble hits it will [stay](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/BubbleCollision.cs#L228-L300) until a same color bubble pops it.
  3. When a level is finished the [next level](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/GameManager.cs#L127-L131) appears immediately.
  4. If player 1 shoots a bubble at players 2 board, the bubble it hits will [freeze](https://github.com/EladMotzny/yourgame/blob/7a3e9d806a0a1156b84092b9c7edb7f6db337775/Blast/Assets/Scripts/BubbleCollision.cs#L125-L204) and turn black. to unfreeze it player 2 should shoot any bubble on it and it will turn to the bubble that was just thrown at it.
  ![Freeze](https://user-images.githubusercontent.com/33619352/85408367-195fe880-b56d-11ea-9b8b-c692fa0e2c5c.gif)





## Tutorial Code
To make things easy to edit on the scene itself we made some adjustment to our code.
We made a TextManager game object in which we could simply drag and drop the prefabs we want to show or write what we want to show on screen using a script:
![image](https://user-images.githubusercontent.com/33173449/83669182-d0ee8400-a5d9-11ea-87a7-bf38d58a632a.png)

To make it appear in the inspector we needed to define a [public array.](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L11-L12)
Then we dragged each prefab and wrote every line.

To instantiate a prefab we use a [function](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L66-L95) that gets called upon every time the players click on the continue button.

To write the text lines, we use TextMesh Pro similar to the dialogue homework. [These two functions](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L35-L65) write the text, check if the writing is over to show the button again and go over the next sentence when the button is clicked.



