

**The University of Melbourne**
# COMP30019 – Graphics and Interaction

## Teamwork plan/summary

<!-- [[StartTeamworkPlan]] PLEASE LEAVE THIS LINE UNTOUCHED -->

<!-- Fill this section by Milestone 1 (see specification for details) -->

Game Design: ALL
  UML diagram
  Sequence diagram

Level Design: Sameer
  Creating Levels

Graphics Design: Jason, Xu Koi Kok
  Themes of the game
  Objects/Textures
  
Game Engineering: Rebeca
  Coding the physics of the game


<!-- [[EndTeamworkPlan]] PLEASE LEAVE THIS LINE UNTOUCHED -->

## Final report

Read the specification for details on what needs to be covered in this report... 

Remember that _"this document"_ should be `well written` and formatted **appropriately**. 
Below are examples of markdown features available on GitHub that might be useful in your report. 
For more details you can find a guide [here](https://docs.github.com/en/github/writing-on-github).

### Table of contents
* [Game Summary](#game-summary)
* [Technologies](#technologies)
* [Using Images](#using-images)
* [Code Snipets](#code-snippets)

### Game Summary
Running Man is a runner game, the main goal of this game is to get to the highest stage possible
while not crashing into any obstacles. While running, the player can move up, down, left, or right, 
corresponding to the direction they want to move, to avoid crashing into oncoming obstacles, such as 
vehicles, walls, boxes, poles, etc. Crashing results in the game ending. The player can collect various items/power ups to 
enhance their character (eg. running slower, teleport forward, jump higher). Other items could be armour to block one collision. 
Player needs to reach the finish line to complete each stage/level, and unlock new stages as they go along.

### Video
https://youtu.be/Kv1iRwkiA5k

### Technologies
Project is created with:
* Unity 2022.1.9f1 
* Ipsum version: 2.33
* Ament library version: 999

### Using Images

You can include images/gifs by adding them to a folder in your repo, currently `Gifs/*`:

<p align="center">
  <img src="Gifs/sample.gif" width="300">
</p>

To create a gif from a video you can follow this [link](https://ezgif.com/video-to-gif/ezgif-6-55f4b3b086d4.mov).

### Code Snippets 

You may wish to include code snippets, but be sure to explain them properly, and don't go overboard copying
every line of code in your project!

```c#
public class CameraController : MonoBehaviour
{
    void Start ()
    {
        // Do something...
    }
}
```
