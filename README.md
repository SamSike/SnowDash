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

### Table of contents

- [Game Summary](#game-summary)
- [Technologies](#technologies)
- [Instructions](#instructions)
- [High Level Gameplay Decisions](#gameplay-design-decisions)
- [Asset Design](#asset-design)
- [Shaders and Special Effects](#shaders-and-special-effects)

### Game Summary

**Snow Dash** is an endless runner game, where the main goal of this game is to get as many points as possible while not crashing into any obstacles. While running, the player can move left, right, and can duck or jump, in order to avoid crashing into oncoming obstacles, such as
trees, pillars, branches, etc. Crashing results in the game ending. The player can collect various items/power ups to enhance their character (eg. running slower, teleport forward, jump higher, immunity). Other items available to be picked up include armor which can block one collision.
The player will traverse through various stages which include different obstacles and unlock new stages as they go along.

### Video

https://youtu.be/Kv1iRwkiA5k

### Technologies

Project is created with:

- Unity 2022.1.9f1

### Instructions

Try to avoid obstacles using:

- **Arrow Keys:**
  Up - Jump
  Left - Left
  Right - Right
  Down - Duck

- **WASD Keys:**
  W - Jump
  A - Left
  D - Right
  S - Duck

**Spacebar** - Jump
**Shift** - Duck

Player can collect power ups to help you get more points and survive.

**Power Ups include:**

- Armor - It gives the player ability to avoid one collision
- Speed Boost - It gives the player a Speed Boost within a duration.
- Decrease Speed - It slows down the Speed of the Player within a duration.
- Invincible - It gives the player an ability to move through obstacles within a duration.
- Points Addition - It gives the player an additional 200 points.
- Jump Higher - It increases the Vertical Jump Distance of the player within a duration.

### High Level Gameplay Decisions

- Camera Movement
  There were two options for how the camera was moving with the player, either the camera remains in the center whilst the player moves left/right or the camera would move left/right with the player. We decided to make the camera move left and right with the player as certain obstacles would obscure the view after running past it and this was a solution to that issue.

- Player move speed
  Initially, the speed in which a player could switch ‘lanes’ was uniform as that seemed like the most logical choice as it felt too choppy otherwise, however, with internal playthroughs, the uniform speed made the game impossible to play. Thus, the speed in which a character can switch a ‘lane’ was scaled to match with the rate in which the character ran forward to maintain the feeling of smoother transitions in low speeds but allowed playability at high speeds.

### Asset Design

Main player (snowman on a sled) was simply a combination of free license assets from the unity asset store. In the same light, many of the themes are prefabs created through the use of different assets and textures found throughout the store.

### Procedural Generation

File Path: /Assets/Scripts/InfiniteFlow.cs
The game demands that items spawn at random. There is an opportunity to do one of the following periodically:
Until the following interval, spawn items at random and roll another chance.
Up to the next period, only spawn double-lane objects, followed by an interval of truly random objects.
The themes are switched at regular intervals, and the game will always switch to a new theme at the specified intervals.
Powerups have a chance to spawn at regular intervals, and will spawn between two objects so that the player should always be able to grab a powerup (unless 2 powerups are the same in a row but that is very unlikely). This is so that the player does not get handed powerups without any effort, i.e. if two lanes are blocked and the third lane is a powerup on the same z-value as obstacles, the player does not need to do any extra movements to get the powerup as that is the only pathway available to them

### Shaders and Special Effects

#### Shaders - Graphics Pipeline

Unfortunately, there are no shaders in implementation as we ran into difficulties in attempts to apply shaders to the player since it was a prefab made up of many different materials. Nonetheless, there were ideas for shaders to be implemented.

Cel Shading was a potential implementation for the player/powerups/obstacles in order to create a distinct style that differentiates them from the rest of the background noise. This would have increased the clarity when playing as playthroughs have shown that the game can become chaotic and confusing at times.

Additionally shaders were considered for certain effects such as the fire or dust storm particles as these systems could become a strain on performance where framerate seemed to be negatively impacted in certain stages.

#### Particle System

File Path: /Assets/Prefabs/snowprefab/Snow Fall
Attribute changed

1. Start Size - Random between 0.025 and 0.05 since Snow doesn’t always start at the same size.
2. Max Particles - 1500 (tested and adjusted according to the Snow Scene)
   The Max Particle can’t be too big since it will block the view of the player if it’s too big, the whole screen will be filled with Snow.
3. Rate over Time - 150 (tested and adjusted according to the Snow Scene).
   The rate over time is tested and changed many times to make the snow more realistic, it can’t be too big otherwise it will look like a Blizzard.
4. Velocity over Lifetime - X direction (random between -2 and 2)
   Y direction (random between -2 and -4)
   Z direction (random between -2 and 2)
   Realistically, snow doesn’t always travel in the same direction and speed.
5. Fade (Render) - The Fade rendering mode is also used to represent when the snow melts.

### Evaluation

1. Methods
   For the way to evaluate the game we chose two methods, one of them querying and the other one observational. For the querying methods there was a survey in google forms. We asked people to play the game and then gave them the survey so they could answer. The questions were basic ones regarding demographic like age and gender, as well as them rating the game and their enjoyment. For the observational method we chose the Post-task walkthrough as we believe it gave a more realistic experience to the user and we could know more about their thoughts on the game.

2. Participants
   a. Survey
   6 participants - 4 men (66.7%) and 2 women (33.3%)
   Most are in their early twenties (with the range being youngest 19 and oldest 26)

   b.Post-task walkthrough
   5 Participants - 3 women and 2 men
   All in their early twenties
   Most of them (⅘) said they play videogames constantly (At least twice weekly)

3. Feedback
   Overall in the survey there were mostly positive responses; the average rating of the game was 3.33 out of 5. Most said they liked the game, that it was easy to play and 66.7% said they would play the game.
   For the walkthroughs we had more in depth feedback. All said the game was pretty intuitive and one mentioned they liked the lack of mouse use. They did mention the speed with the rain and/or smoke made the game more challenging especially in regard to the branch obstacle which was difficult to perceive sometimes.

4. Changes made
   Because of the short period of time there was no opportunity to create improvement iterations from the feedback we received. So we believe that would create a good opportunity for future work and also have a wider pool of feedback.

### References + Resources

https://www.youtube.com/watch?v=Q4rtR8iNFbY
https://www.youtube.com/watch?v=K4uOjb5p3Io
