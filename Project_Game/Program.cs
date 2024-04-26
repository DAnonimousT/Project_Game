using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        Symbols symbols = new Symbols();
        Inputs inputs = new Inputs();
        Talks talk = new Talks();
        Riddels riddels = new Riddels();


entry:
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine();
        if (username == "")
        {
            Console.WriteLine("Need to add username!");
            goto entry;
        }
        Console.WriteLine(talk.talk1);
beggining:
        while (inputs.running)
        {
            string command = Console.ReadLine();
            switch (command)
            {
                case "Scout":
                    Console.WriteLine(talk.scoutInfo);
                    break;

                case "WallLeft":
                    Console.WriteLine(symbols.symbols);
                    break;

                case "WallRight":
                    Console.WriteLine(symbols.allSymbols);
                    break;

                case "Chest":
                    Console.WriteLine(talk.chestStory);
                    while (inputs.chest)
                    {
                        string entry = Console.ReadLine();
                        if (entry == "104776")
                        {
                            inputs.key1 = 1;
                            Console.WriteLine(talk.chestComp);
                            break;
                        }
                        else if (entry == "Back")
                        {
                            Console.WriteLine("You went back!");
                            goto beggining;
                        }
                        else if (entry == "Help")
                        {
                            Console.WriteLine("You need to write the code without space between the numbers!");
                        }
                        else
                            Console.WriteLine("Try again!");
                    }
                    break;

                case "Head":
                    if (inputs.key1 == 0) { Console.WriteLine("You don't have the Head!"); break; }
                    if (inputs.key2 == 1) { Console.WriteLine("You need me for the door!"); break; }
                    Console.WriteLine(talk.headStory);
                    Console.WriteLine(riddels.riddle1);
                    while (inputs.riddle)
                    {
                        string answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "Darkness":
                                Console.WriteLine(riddels.riddle2);
                                while (inputs.riddle2)
                                {
                                    string answer2 = Console.ReadLine();
                                    switch (answer2)
                                    {
                                        case "Pencil lead":
                                            Console.WriteLine(riddels.riddle3);
                                            while (inputs.riddle3)
                                            {
                                                string answer3 = Console.ReadLine();
                                                switch (answer3)
                                                {
                                                    case "Breath":
                                                        Console.WriteLine(talk.headComp);
                                                        inputs.riddle = false;
                                                        inputs.riddle2 = false;
                                                        inputs.riddle3 = false;
                                                        inputs.key2 = 1;
                                                        break;
                                                    case "Hint":
                                                        Console.WriteLine(riddels.hint3);
                                                        break;
                                                    case "Back":
                                                        Console.WriteLine("You went back!");
                                                        goto beggining;
                                                        break;
                                                    case "Help":
                                                        Console.WriteLine("Commands: Hint, Back, Help, Quit");
                                                        break;
                                                    case "Quit":
                                                        inputs.running = false;
                                                        goto beggining;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Try again!");
                                                        break;
                                                }
                                            }
                                            break;
                                        case "Hint":
                                            Console.WriteLine(riddels.hint2);
                                            break;
                                        case "Back":
                                            Console.WriteLine("You went back!");
                                            goto beggining;
                                            break;
                                        case "Help":
                                            Console.WriteLine("Commands: Hint, Back, Help, Quit");
                                            break;
                                        case "Quit":
                                            inputs.running = false;
                                            goto beggining;
                                            break;
                                        default:
                                            Console.WriteLine("Try again!");
                                            break;
                                    }
                                }
                                break;
                            case "Hint":
                                Console.WriteLine(riddels.hint1);
                                break;
                            case "Back":
                                Console.WriteLine("You went back!");
                                goto beggining;
                                break;
                            case "Help":
                                Console.WriteLine("Commands: Hint, Back, Help, Quit");
                                break;
                            case "Quit":
                                inputs.running = false;
                                goto beggining;
                                break;
                            default:
                                Console.WriteLine("Try again!");
                                break;
                        }
                    }
                    break;

                case "Door":
                    if (inputs.key2 == 1)
                    {
                        Console.WriteLine(talk.end);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t THE END");
                        inputs.running = false;
                    }
                    else
                        Console.WriteLine("This door don't have a keyhole!");
                    break;

                case "Help":
                    Console.WriteLine("Commands: Scout, Door, Chest, WallLeft, WallRight, Head, Help, Quit");
                    break;

                case "Quit":
                    inputs.running = false;
                    break;

                default:
                    Console.WriteLine("Unknown command! Type Help for more info!");
                    break;
            }
        }
    }
}

public class Riddels
{
    public string riddle1 = "Riddle number 1: The more of this there is, the less you can see. What is it?";
    public string riddle2 = "Good one! Next riddle: I'm taken from mine, and shut up in a wooden case, from which I'm never released and yet I am used by almost every person. What am I?";
    public string riddle3 = "Very good! Last one: I'm light as a feather, but even the world's strongest person couldn't hold me for long. What am I?";
    public string hint1 = "Hint: Consider what happens at night or in a dimly lit room, affecting your ability to see everything around you!";
    public string hint2 = "Hint: The object is often found in homes and it's essential for communication and staying connected with others!";
    public string hint3 = "Hint: This object is intangible and can't be physically grasped, yet it can have a significant impact on people's lives.";
}

public class Talks
{

    public string talk1 = "You find yourself in a dimly lit room, facing a chest with six numbered slots, a closed door with two intresting hoes, and two distinct wall patterns. The chest's locked, silent, promising secrets or perhaps answers. Commands: Scout, Door, Chest, WallLeft, WallRight, Head, Help, Quit";
    public string chestStory = "As you approach the chest, its ancient surface bears six numbered slots, each awaiting a combination yet to be discovered. With no knowledge of what lies within, your curiosity drives you to unravel the mystery concealed behind the locked lid. The chest stands as a silent sentinel, its secrets tantalizingly close, yet shrouded in uncertainty. It beckons, a silent challenge waiting to be conquered. Write your code. If you want to go back write - Back";
    public string scoutInfo = "The left wall is plain except for six circles, each containing a symbol. The right wall features a single line of text that reads, Order in nature, the key to unlocking. Realizing the symbols on the left wall represent numbers in nature - the phases of the moon, perhaps, or the petals on flowers - you deduce that these symbols must correspond to the numbers needed for the chest's slots. Your task is clear: decode the symbols, input the numbers into the chest, and discover what lies within. The solution feels just within reach, waiting for the right combination to reveal itself and perhaps provide the key to unlocking the door as well.";
    public string chestComp = "As the chest's lock clicks open and the lid creaks back, a surprising sight greets you: a head, ancient and wise, with eyes that flicker with a mischievous spark. It speaks in a voice as old as time.";
    public string headStory = "Ah forever beholden to the mystery that you seek to unravel. Listen well, for my words will not repeat. \t New commands are added! Type Help for more!";
    public string headComp = "As you voice your answers, the head's eyes glow with an ancient light, its expression shifting between inscrutable wisdom and anticipation. After a moment of silence, where the air itself seems to hold its breath, the head finally speaks, its voice resonant with a depth that echoes through the chamber:\r\n\r\n\"Brave seeker, you have traversed the landscape of riddles with the agility of thought and sharpness of mind. Each answer you have given rings true, cutting through the veils of mystery that have long shrouded these challenges. You have proven yourself not just a traveler of paths physical, but a navigator of the mental mazes that confound many who dare to tread this sacred ground. Put me infront of the door to open it.";
    public string end = "As the final echoes of your journey fade into the silence of the chamber, you approach the once enigmatic chest for the last time. Its contents revealed and its mysteries unraveled, a soft glow begins to emanate from within, casting light upon your face and the ancient walls that have borne witness to your quest.\r\n\r\nA voice, warm and familiar, fills the space around you—the voice of the head, now free from its confines:\r\n\r\n\"Traveler of paths both dark and bright, your journey within these walls concludes under the watch of stars unseen. The riddles you have solved, the truths you have unearthed, and the courage you have shown, are but reflections of the strength that lies within you. The chest, once locked, served not as a barrier, but as a gateway to the discovery of self and the unearthing of wisdom buried deep.\"\r\n\r\nThe light from the chest grows brighter, enveloping the room in a serene glow. The walls, once inscribed with cryptic patterns, now shine with clear messages of encouragement and knowledge passed from the ancients to those who dare to seek.\r\n\r\n\"As you step forth from this chamber, carry with you the lessons of resilience, insight, and curiosity. The world beyond these stone confines brims with mysteries yet to be solved, paths yet to be trodden, and stories yet to be told. Your quest within these walls may end, but the journey of your heart and mind stretches into the horizon, endless and unbound.\"\r\n\r\nThe light begins to recede, gently drawing back into the chest, which slowly closes, its purpose fulfilled. The door to the chamber swings open, revealing the path ahead, bathed in the gentle light of dawn.\r\n\r\n\"Go forth, enlightened traveler, for every end is but a new beginning. Let the wisdom of the ancients guide you, and may the curiosity that led you here light your way through the adventures that await. Remember, the greatest treasure is not found within a chest, but within the journey itself.\"\r\n\r\nWith those final words, the voice fades away, leaving you in a profound silence, filled with a sense of completion and anticipation for what lies beyond. You step through the door, into the light, ready for the next chapter of your story to unfold.";

}

public class Inputs
{
    public bool running = true;
    public bool chest = true;
    public bool riddle = true;
    public bool riddle2 = true;
    public bool riddle3 = true;
    public int key1 = 0;
    public int key2 = 0;
}

public class Symbols
{
    public string symbols = "Ω M ¥ µ";
    public string allSymbols = "§ - 64 ¤ - 30 ¡ - 92 ¢ - 49 Ω - 10 ‡ - 51 ? - 68 ¥ - 7 & - 36 ℮ - 26 ∑ - 51 M - 4 $ - 87 ` - 98 ≈ - 53 ∞ - 33 µ - 76";
}
