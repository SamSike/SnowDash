
// This class contains metadata for your submission. It plugs into some of our
// grading tools to extract your game/team details. Ensure all Gradescope tests
// pass when submitting, as these do some basic checks of this file.
public static class SubmissionInfo
{
    // TASK: Fill out all team + team member details below by replacing the
    // content of the strings. Also ensure you read the specification carefully
    // for extra details related to use of this file.

    // URL to your group's project 2 repository on GitHub.
    public static readonly string RepoURL = "https://github.com/COMP30019/project-2-666";
    
    // Come up with a team name below (plain text, no more than 50 chars).
    public static readonly string TeamName = "666";
    
    // List every team member below. Ensure student names/emails match official
    // UniMelb records exactly (e.g. avoid nicknames or aliases).
    public static readonly TeamMember[] Team = new[]
    {
        new TeamMember("Xu Koi Kok", "kokx@student.unimelb.edu.au"),
        new TeamMember("Rebeca Monserrat Guevara Lagunas", "rguevara@student.unimelb.edu.au"),
        new TeamMember("Jason Phan", "phanjp@student.unimelb.edu.au"),
        new TeamMember("Sameer Sikka", "ssikka@student.unimelb.edu.au"), 
    };

    // This may be a "working title" to begin with, but ensure it is final by
    // the video milestone deadline (plain text, no more than 50 chars).
    public static readonly string GameName = "Snow dash";

    // Write a brief blurb of your game, no more than 200 words. Again, ensure
    // this is final by the video milestone deadline.
    public static readonly string GameBlurb = 
@"Running Man is a runner game, the main goal of this game is to get to the highest stage possible
while not crashing into any obstacles. While running, the player can move up, down, left, or right, 
corresponding to the direction they want to move, to avoid crashing into oncoming obstacles, such as 
vehicles, walls, boxes, poles, etc. Crashing results in the game ending. The player can collect various items/power ups to 
enhance their character (eg. running slower, teleport forward, jump higher). Other items could be armour to block one collision. 
Player needs to reach the finish line to complete each stage/level, and unlock new stages as they go along.
";
    
    // By the gameplay video milestone deadline this should be a direct link
    // to a YouTube video upload containing your video. Ensure "Made for kids"
    // is turned off in the video settings. 
    public static readonly string GameplayVideo = "https://youtu.be/Kv1iRwkiA5k";
    
    // No more info to fill out!
    // Please don't modify anything below here.
    public readonly struct TeamMember
    {
        public TeamMember(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }
    }
}
