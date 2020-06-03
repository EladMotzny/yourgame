# Treasure Fight!

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

## Tutorial Code
To make things easy to edit on the scene itself we made some adjustment to our code.
We made a TextManager game object in which we could simply drag and drop the prefabs we want to show or write what we want to show on screen using a script:
![image](https://user-images.githubusercontent.com/33173449/83669182-d0ee8400-a5d9-11ea-87a7-bf38d58a632a.png)

To make it appear in the inspector we needed to define a [public array.](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L11-L12)
Then we dragged each prefab and wrote every line.

To instantiate a prefab we use a [function](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L66-L95) that gets called upon every time the players click on the continue button.

To write the text lines, we use TextMesh Pro similar to the dialogue homework. [These two functions](https://github.com/EladMotzny/yourgame/blob/515566fa57b73b310acc7d43b8b3f695f95f49f1/Blast/Assets/Scripts/TutorialText.cs#L35-L65) write the text, check if the writing is over to show the button again and go over the next sentence when the button is clicked.
