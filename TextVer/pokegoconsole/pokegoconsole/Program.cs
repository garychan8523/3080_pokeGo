using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pokegoconsole
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WindowHeight = Console.LargestWindowHeight - 12;
            Console.WindowWidth = Console.LargestWindowWidth/2-10;

            ConsoleInterface game = new ConsoleInterface(63,20,20);//(x size[min 5], y size[min 5], gym nmuber[min 1])
 
            game.playGame();
         }
    }

    public class ConsoleInterface 
    {
        bool stopgame = false;
        int worldsizeX,worldsizeY;
        int GYMnumber;
        //char[,] worldmap = new char[worldsizeY, worldsizeX];
        char[,] worldmap;
        int PokeTrainerY, PokeTrainerX;
        int WidePokemonX, WidePokemonY;
        int countround = 0;
        int spreadness = 4; //range that pokemon will gen arround player
        int GenDuration = 10; //Pokemon Gen per (GenDuration) round
        string commendinput;
        Random rnd = new Random();
        PokeTrainer RED = new PokeTrainer();

        public ConsoleInterface(int x, int y, int z){
            if (x >= 5 && y >= 5 && z >= 1 && z < x*y)//(x[min 5], y[min 5], z[min 1])
            {
                worldsizeX = x;
                worldsizeY = y;
                GYMnumber = z;
                worldmap = new char[y, x];
                initializeWorldmap();
                initializePokeTrainer();
                gameStartMenu();
            }
            else
            { 
                Console.WriteLine("".PadRight(66,'*'));
                Console.WriteLine("".PadRight(3, '*') + "".PadRight(12,' ') + "Map size or number of GYM is wrong.".PadRight(36)+"".PadRight(12,' ') + "".PadRight(3, '*'));
                Console.WriteLine("".PadRight(66, '*'));
                stopgame = true;
                Console.WriteLine("Press ENTER to Quit...");
                Console.ReadLine();
            }           
        }

        public void initializeWorldmap()
        {
            //worldmap = new char[20, 60];
            for (int i = 0; i < worldsizeY; i++)
            {
                for (int j = 0; j < worldsizeX; j++)
                {
                    worldmap[i,j]='.';
                }
            }
            

            editMapToGym(GYMnumber);
            

        }

        public void initializePokeTrainer() {
            int y = worldsizeY;
            int x = worldsizeX;
            if (y % 2 == 0)
                PokeTrainerY = y / 2;
            else 
            {
                y--;
                PokeTrainerY = y / 2;
            }
            if (x % 2 == 0)
                PokeTrainerX = x / 2;
            else
            {
                x--;
                PokeTrainerX = x / 2;
            }

            worldmap[PokeTrainerY, PokeTrainerX]='R';

            

        }

        public void gameStartMenu() 
        {
            Console.WriteLine("8888888b.           888                                                .d8888b.           888 ");
            Console.WriteLine("888   Y88b          888                                               d88P  Y88b          888 ");
            Console.WriteLine("888    888          888                                               888    888          888");
            Console.WriteLine("888   d88P  .d88b.  888  888  .d88b.  88888b.d88b.   .d88b.  88888b.  888         .d88b.  888");
            Console.WriteLine("8888888P\"  d88\"\"88b 888 .88P d8P  Y8b 888 \"888 \"88b d88\"\"88b 888 \"88b 888  88888 d88\"\"88b 888");
            Console.WriteLine("888        888  888 888888K  88888888 888  888  888 888  888 888  888 888    888 888  888 Y8P");
            Console.WriteLine("888        Y88..88P 888 \"88b Y8b.     888  888  888 Y88..88P 888  888 Y88b  d88P Y88..88P  \" ");
            Console.WriteLine("888         \"Y88P\"  888  888  \"Y8888  888  888  888  \"Y88P\"  888  888  \"Y8888P88  \"Y88P\"  888");
            Console.WriteLine("");
            Console.WriteLine("t  e  x  t    v  e  r.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("".PadRight(38) + "Press ENTER to start");
            Console.ReadLine();
        }

        public void TrainerStatus()
        {

            Console.WriteLine("+".PadRight(64, '-') + "+");
            Console.WriteLine("|  R: Player Red ; G: GYM ; ?: Wild Pokemon".PadRight(64) + "|");
            Console.WriteLine("|".PadRight(64) + "|");
            Console.WriteLine("|  Prof Oak: ".PadRight(64)+"|");
            Console.WriteLine(("|  Red, you are now in location ["+PokeTrainerY.ToString()+", "+PokeTrainerX.ToString()+"]").PadRight(64)+"|");
            Console.WriteLine("|  What do you want to do?".PadRight(64) + "|");
            Console.WriteLine("|  Left = a ; Right = d ; Up = w ; Down = s; ".PadRight(64) + "|");
            Console.WriteLine("|  Menu = m ; Quit  = q".PadRight(64) + "|");
            Console.WriteLine(("|  Round: " + countround.ToString()).PadRight(64) + "|");
            Console.WriteLine("+".PadRight(64, '-') + "+");
        }

        public void playGame()
        {
            while (stopgame==false)
            {
                Console.Clear();
                if (countround % GenDuration == 0) genWidePokemon();
                this.printWorldmap();
                this.TrainerStatus();
                commendinput = Console.ReadLine();
                pokeTrainerMove(commendinput);
                checkIfeventhappen();
                countround++;
                updateWorldmap();
            }
        }

        public void pokeTrainerMove(string commendinput)
        {
            if (commendinput == "w") 
            {
                if (PokeTrainerY - 1 >= 0)
                {
                    worldmap[PokeTrainerY, PokeTrainerX] = '.';
                    PokeTrainerY--;
                }
                
            }
            if (commendinput == "s") 
            {
                if (PokeTrainerY + 1 < worldsizeY)
                { 
                worldmap[PokeTrainerY, PokeTrainerX] = '.';
                PokeTrainerY++;
                }
            }
            if (commendinput == "a") 
            {
                if (PokeTrainerX - 1 >= 0)
                {
                    worldmap[PokeTrainerY, PokeTrainerX] = '.';
                    PokeTrainerX--;
                }
            }
            if (commendinput == "d")
            {
                if (PokeTrainerX + 1 < worldsizeX)
                {
                worldmap[PokeTrainerY, PokeTrainerX] = '.';
                PokeTrainerX++;
                }   
            }
            if (commendinput == "m")
            {
                statusMenu();
            }
            if (commendinput == "q")
            {
                Console.WriteLine("**Quit Game**[y/n]");
                string x = Console.ReadLine();
                if (x == "y")
                    stopgame = true;
                else
                { 
                    Console.WriteLine("Cancelled. Press ENTER to continue.");
                    Console.ReadLine();
                }
            }
        }
        
        public void updateWorldmap()
        {
            worldmap[PokeTrainerY, PokeTrainerX] = 'R';
        }
        
        public void genWidePokemon() 
        {
            
            int x = rnd.Next(-spreadness, spreadness+1);
            int y = rnd.Next(-spreadness, spreadness+1);
            
            if (PokeTrainerY + y < worldsizeY && PokeTrainerX + x >= 0 && PokeTrainerX + x < worldsizeX && PokeTrainerY + y >= 0 )
            {
                WidePokemonX = PokeTrainerX + x;
                WidePokemonY = PokeTrainerY + y;
                if (worldmap[WidePokemonY, WidePokemonX] != 'G' && worldmap[WidePokemonY, WidePokemonX] != '?' && worldmap[WidePokemonY, WidePokemonX] != 'R')
                    worldmap[WidePokemonY, WidePokemonX] = '?';
                else
                    genWidePokemon(); 
             }
            else { genWidePokemon(); }
        }
        
        public void checkIfeventhappen()
        {
            if (worldmap[PokeTrainerY, PokeTrainerX] == '?') 
            {
                Pokemon P = new Pokemon();
                capturePokemon(P);
            }
            if (worldmap[PokeTrainerY, PokeTrainerX] == 'G')
            {
                PokeGYM G = new PokeGYM();
                battleGym(G);
            }
        }
        
        public void capturePokemon(Pokemon P)
        {
            Console.Clear();
            Console.WriteLine("+".PadRight(64, '-') + "+");
            Console.WriteLine(("|   Wild " + P.Name.PadRight(12)+" appeared! It CP is " + (P.Cp.ToString()+".").PadRight(20)).PadRight(64)+"|");
            Console.WriteLine("|   Flip a coin if HEAD appear means you catch it successfully!".PadRight(64)+"|");
            Console.WriteLine("|".PadRight(64) + "|");
            Console.WriteLine("|   f : flip ; r : run".PadRight(64) + "|");
            Console.WriteLine("+".PadRight(64,'-') + "+");
            string x = Console.ReadLine();
            if (x == "f")
            {
                if (rnd.Next(2) == 0)
                {
                    Console.WriteLine("+".PadRight(64, '-') + "+");
                    Console.WriteLine("|   GotCha! You flip a HEAD! You captured " + (P.Name+"!").PadRight(15) + "       |");
                    Console.WriteLine("+".PadRight(64, '-') + "+");
                    RED.OwnPokemon.Add(P);
                }
                else Console.WriteLine("Sosad! " + P.Name + " ran away!");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                
            }
            else if (x == "r")
            {
                Console.WriteLine("You ran away!");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Press any Key to continue...");
                Console.ReadLine();
                capturePokemon(P);
                
            }
            worldmap[PokeTrainerY, PokeTrainerX] = '.';
            
        }

        public void battleGym(PokeGYM G) 
        {
            Console.Clear();
            
            Console.WriteLine("+".PadRight(64, '-') + "+");
            Console.WriteLine("| This is a Gym.".PadRight(64)+"|");
            Console.WriteLine("|".PadRight(64) + "|");
            Console.WriteLine(("| The lastest Champion is " + (G.Champ.Name + ".").PadRight(10) + "It's CP value is " + G.Champ.Cp + ".").PadRight(64)+"|");
            if (RED.havePokemon() && RED.allPokemonAlive())
            {
                Console.WriteLine("| Do you want to fight it? [y/n]".PadRight(64) + "|");
                Console.WriteLine("+".PadRight(64, '-') + "+");
                string result = Console.ReadLine();
                if (result == "y")
                {
                    PokeStatus();
                    Console.WriteLine("Which pokemon you want to send out to fight? No.");
                    string input = Console.ReadLine();
                    int number;
                    Int32.TryParse(input, out number);
                    if (number > 0 && number <= RED.OwnPokemon.Count)
                    {

                        number--;
                        if (!RED.OwnPokemon[number].isDead())
                            battleLogic(G.Champ, RED.OwnPokemon[number]);
                        else
                        {
                            Console.WriteLine("Sorry. You cant send out dead pokemon");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        Console.WriteLine("Press any Key to continue...");
                        Console.ReadLine();
                        battleGym(G);
                    }
                }
                else if (result == "n")
                {
                    Console.WriteLine("You ran away!!");
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                }
                else 
                {
                    Console.WriteLine("ERROR Input");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    battleGym(G);
                }
            }
            else 
            {
                Console.WriteLine("+".PadRight(64, '-') + "+");
                Console.WriteLine("");
                Console.WriteLine("Sosad. You have no alive pokemon.");
                
                Console.WriteLine("Press ENTER to Leave...");
                Console.ReadLine();
            }
            PokeTrainerX = PokeTrainerX + 1;
        }

        private void battleLogic(Pokemon G,Pokemon P) 
        {
            Console.Clear();
            bool battleEnded = false;
            while (!battleEnded) 
            {
                Console.WriteLine(("Champion ".PadRight(10) + G.Name.PadRight(12) + "CP:" + G.Cp).PadRight(31) + " vs " + ("Player ".PadRight(10) + P.Name.PadRight(12) + "CP:" + P.Cp).PadRight(31));
                while (G.isDead()==false && P.isDead()==false)
                {
                    
                    Console.WriteLine("".PadRight(66, '*'));
                    Console.WriteLine("Champion ".PadRight(10)+G.Name.PadRight(12)+"Attack!");
                    G.attackCalculat(P);
                    Console.WriteLine("Your ".PadRight(10) + P.Name.PadRight(12) + " HP: " + P.Hp.ToString().PadRight(5)+"/ "+ P.Maxhp.ToString().PadRight(5) + "!");
                    Console.WriteLine("".PadRight(66, '*'));
                    Console.ReadLine();
                    if (!P.isDead())
                    {
                        Console.WriteLine("".PadRight(66, '*'));
                        Console.WriteLine("Your ".PadRight(12) + P.Name.PadRight(12) + "Attack!");
                        P.attackCalculat(G);
                        Console.WriteLine("Champion ".PadRight(10) + G.Name.PadRight(12) + " HP: " + G.Hp.ToString().PadRight(5)+"/ "+ G.Maxhp.ToString().PadRight(5) + "!");
                        Console.WriteLine("".PadRight(66, '*'));
                        Console.ReadLine();
                        if (G.isDead()) 
                        {
                            Console.WriteLine("Congratulation! You have defeated the GYM!");
                            Console.WriteLine("You earn 1 GYM badge and 10 Pokemon Candy");
                            RED.winGYM();

                            Console.ReadLine();
                            battleEnded = true;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Your ".PadRight(10) + P.Name.PadRight(12)+"is dead");
                        Console.WriteLine("Your got kicked out from the GYM");
                        Console.ReadLine();
                        battleEnded = true;
                    }
                }      
            }
            
        }

        private void PokeStatus() 
        {
            int count = 1;
            Console.WriteLine("+".PadRight(64, '-') + "+");
            Console.WriteLine(("|  No.".PadRight(10) + "| Name".PadRight(12) + "| CP".PadRight(10) + "| Size".PadRight(10) + "| Hp  / Max HP".PadRight(15)).PadRight(64) + "|");
            foreach (Pokemon n in RED.OwnPokemon)
            {
                Console.WriteLine((("|  " + count.ToString()).PadRight(10) + ("| " + n.Name).PadRight(12) + ("| " + n.Cp.ToString()).PadRight(10) + ("| " + n.Size.ToString()).PadRight(10) + ("| " + n.Hp.ToString().PadRight(4) + "/ " + n.Maxhp.ToString().PadRight(4)).PadRight(15)).PadRight(64) + "|");
                count++;
            }

            Console.WriteLine("+".PadRight(64, '-') + "+");
            
        
        }

        private void statusMenu() {
            
            Console.Clear();
            Console.WriteLine("+".PadRight(64, '-') + "+");
            Console.WriteLine("|".PadRight(64, ' ') + "|");
            Console.WriteLine(("|    * Pokemon Candy : "+RED.Pokecandy.ToString()+" | "+"GYM badges : "+RED.GYMbadge.ToString()+" * ").PadRight(64)+"|");
            Console.WriteLine("|".PadRight(64, ' ') + "|");

            PokeStatus();
            Console.WriteLine("|".PadRight(64, ' ') + "|");
            Console.WriteLine("|  p : power-up pokemon ; s : sell pokemon ; h : heal pokemon".PadRight(64, ' ') + "|");
            Console.WriteLine("|  m : return".PadRight(64, ' ') + "|");
            Console.WriteLine("|".PadRight(64, ' ') + "|");
            Console.WriteLine("+".PadRight(64, '-') + "+");

            string x = Console.ReadLine();
            if (x == "p") { powerUP(); }
            if (x == "s") { sell(); }
            if (x == "m") { playGame(); }
            if (x == "h") { heal(); }
            else
            {
                Console.WriteLine("ERROR Input");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                statusMenu();
            }
        }

        public void powerUP() 
        {

            if (RED.Pokecandy > 0 && RED.OwnPokemon.Count()>0)
            {
                Console.WriteLine("Each power up consume 1 Pokemon Candy.");
                Console.WriteLine("Which pokemon do you want to power up? Input No.");
                string input = Console.ReadLine();
                int number;
                Int32.TryParse(input, out number);
                if (number <= 0 || RED.OwnPokemon.Count()<number) { 
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Press any Key to continue...");
                    Console.ReadLine();
                }
                else 
                {
                    number--;
                    RED.powerUpPokemon(number);
                }      
            }
            else 
            {
                Console.WriteLine("You dont have enough poke candy or pokemon!");
                Console.WriteLine("Press any Key to continue...");
                Console.ReadLine();
            }
            statusMenu();
        }

        public void sell()
        {
            if (RED.havePokemon())
            {
                Console.WriteLine("Sell one pokemon can get 3 Pokemon Candy.");
                Console.WriteLine("Which pokemon do you want to sell?");
                string input = Console.ReadLine();
                int number;
                Int32.TryParse(input, out number);
                //number = input;
                

                if (number <= 0 || RED.countPokemon() < number)
                {
                    Console.WriteLine("ERROR Input");
                    Console.WriteLine("Press any Key to continue...");
                    Console.ReadLine();

                }
                else
                {
                    number--;
                    Console.WriteLine("Are you sure you want to sell " + RED.OwnPokemon[number].Name + "? [y/n]");
                    string x = Console.ReadLine();
                    if (x == "y")
                    {
                        RED.sellPokemon(number);
                        Console.WriteLine("You get 3 Pokemon Candy from Prof Oak.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Cancel. Press enter to contimue...");
                        Console.ReadLine();
                    }
                }
            }
            else {
                Console.WriteLine("You dont have pokemon! Press enter to contimue...");
                Console.ReadLine();
            }
            statusMenu();
        }

        public void heal() 
        {
            
            if (RED.Pokecandy >= 3) 
            {
                if (RED.OwnPokemon.Count > 0)
                {
                    Console.WriteLine("Heal each Pokemon need 3 Pokemon Candy");
                    Console.WriteLine("Which pokemon do you want to heal?");
                    string input = Console.ReadLine();
                    int number;
                    Int32.TryParse(input, out number);

                    if (number <= 0 || RED.countPokemon() < number)
                    {
                        Console.WriteLine("ERROR Input");
                        Console.WriteLine("Press any Key to continue...");
                        Console.ReadLine();

                    }
                    else
                    {
                        number--;
                        if (RED.OwnPokemon[number].Hp == RED.OwnPokemon[number].Maxhp)
                        {
                            Console.WriteLine("Your Pokemon " + RED.OwnPokemon[number].Name.PadRight(12) + "is very health.");
                            Console.WriteLine("No need to heal it");
                            Console.ReadLine();
                        }
                        else 
                        {
                            RED.healPokemon(number);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry you have no pokemon to heal");
                    Console.WriteLine("Press enter to contimue...");
                    Console.ReadLine();
                }
                
            }
            else
            {
                Console.WriteLine("Sorry, you dont have enough Pokemon Candy");
                Console.WriteLine("Press enter to contimue...");
                Console.ReadLine();
            }
            
            statusMenu();
        
        }

        public static class Util
        {
        private static Random rnd = new Random();
        public static int GetRandom(int range)
        {
            return rnd.Next(range);
        }
        }

        public void editMapToGym(int x)
        {
            //private static Random rnd = new Random();
            for (int a = 0; a < x; a++)
            {
                int i = rnd.Next(1, worldsizeY-1);
                int j = rnd.Next(1, worldsizeX-1);
                while (worldmap[i, j] != 'G')
                {
                    i = rnd.Next(1, worldsizeY-1);
                    j = rnd.Next(1, worldsizeX-1);
                    worldmap[i, j] = 'G';
                }
            }
        }

        public void printWorldmap() {
            Console.Write("+");
            for (int i = 0; i < worldsizeX; i++) Console.Write("-");
            Console.WriteLine("+");
            for (int i = 0; i < worldsizeY; i++)
            {
                Console.Write("|");
                for (int j = 0; j < worldsizeX; j++)
                {
                    Console.Write(worldmap[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.Write("+");
            for (int i = 0; i < worldsizeX; i++) Console.Write("-");
            Console.WriteLine("+");
        }

    }  

    public class PokeTrainer
    {
        public List<Pokemon> OwnPokemon { get { return POwnPokemon; } }
        private List<Pokemon> POwnPokemon = new List<Pokemon>(); 
        private int pokecandy;
        public int Pokecandy { get { return pokecandy; } }
        private int gymbadge;
        public int GYMbadge { get { return gymbadge; } }

        public PokeTrainer() 
        {
            pokecandy = 3;
            gymbadge = 0;
        }

        public void powerUpPokemon(int x) 
        {
            this.POwnPokemon[x].powerUp();
            this.pokecandy--;
        }

        public void sellPokemon(int x) 
        {
            this.POwnPokemon.RemoveAt(x);
            this.pokecandy += 3;
        }

        public void healPokemon(int x)
        {
            this.POwnPokemon[x].Heal();
            this.pokecandy -= 3;
        }

        public void getOneCandy() 
        {
            pokecandy++;
        }

        public void useOneCandy()
        {
            pokecandy++;
        }

        public void winGYM() 
        {
            this.pokecandy += 10;
            this.gymbadge++;

        }

        public bool havePokemon(){
            if (this.POwnPokemon.Count > 0)
                return true;          
            else return false;
        }

        public bool allPokemonAlive() 
        {
            bool status = false;
            foreach (Pokemon x in this.OwnPokemon) 
            {
                if (x.Hp > 0) status = true;
            }
            return status;
        }

        public int countPokemon()
        {
            return this.POwnPokemon.Count;
        }
    }

    public class Pokemon
    {
        Random rnd = new Random();
        public Pokemon()
        {
            if (ListName == null)
            {
                loadPokeData();
            }
            int numgen = RandGen();
            this.name = ListName[numgen];
            this.type = ListType[numgen];
            this.ap = ListAp[numgen] + rnd.Next(3);
            this.maxhp= ListHp[numgen] + rnd.Next(3);
            this.hp = this.maxhp;
            this.size = (pokesize)rnd.Next(5);
            /*
            pokesize = (int)size.l;
            */
        }
        public Pokemon(int x) //For generating pre-PowerUp pokemon
        {
            if (ListName == null)
            {
                loadPokeData();
            }
            int numgen = RandGen();
            this.name = ListName[numgen];
            this.type = ListType[numgen];
            this.ap = ListAp[numgen] + rnd.Next(3);
            this.maxhp = ListHp[numgen] + rnd.Next(3);
            this.hp = this.maxhp;
            this.size = (pokesize)rnd.Next(5);

            if (x >= 1)
            {
                for (int i = 0; i < x; i++)
                {
                    this.powerUp();
                }
            }
        }

        private string name;
        private string type;
        private int cp;
        private int ap;
        private int hp;
        private int maxhp;
        private pokesize size;
        public enum pokesize { xs, s, m, l, xl };
        private List<string> ListName;
        private List<string> ListType;
        private List<int> ListAp;
        private List<int> ListHp;

        public string Name { get { return name; } }
        public string Type { get { return type; } }
        public int Cp { get { cpCaluate(); return cp; } }
        public int Ap { get { return ap; } }
        public int Hp { get { return hp; } }
        public int Maxhp { get { return maxhp; } }
        public pokesize Size { get { return size; } }

        //public List<string> ListName = new List<string>(new string[] { "Bulbasaur", "Charmander", "Squirtle", "Caterpie", "Pidgey", "Pikachu" });
        //public List<string> ListType = new List<string>(new string[] { "Grass", "Fire", "Water", "Bug", "Flying", "Electric" });
        //private List<int> ListAp = new List<int>(new int[] { 19, 20, 21, 15, 10, 25 });
        //private List<int> ListHp = new List<int>(new int[] { 45, 39, 44, 45, 40, 35 });



        public void loadPokeData()
        {
            // instantiate each list for storing poke data
            ListName = new List<string>();
            ListType = new List<string>();
            ListAp = new List<int>();
            ListHp = new List<int>();

            // load poke name from resources and add to ListName
            string[] path = Properties.Resources.pokename.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in path) { ListName.Add(line); }

            // load poke type from resources and add to ListType
            path = Properties.Resources.poketype.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in path) { ListType.Add(line); }

            // load poke ap from resources and add to ListCp
            path = Properties.Resources.pokeap.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in path) { int temp = Int32.Parse(line); ListAp.Add(temp); }

            // load poke hp from resources and add to ListHp
            path = Properties.Resources.pokehp.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in path) { int temp = Int32.Parse(line); ListHp.Add(temp); }
        }

        private int RandGen() 
        {
            return rnd.Next(this.ListName.Count());
        }



        private int cpCaluate() 
        {
            cp = this.ap + this.maxhp;
            return cp;
        }   

        public void powerUp()
        {
            this.ap = (int)(this.ap * 1.1);
            this.hp = (int)(this.hp * 1.2);
            this.maxhp = (int)(this.maxhp * 1.2);
        }

        public void Heal() 
        {
            this.hp = this.maxhp;        
        }

        public void attackCalculat(Pokemon x) {
            int extra = rnd.Next((int)this.ap/10);
            x.hp = x.hp - this.ap- extra;
            if (x.hp < 0) x.hp = 0;
        }

        public bool isDead() 
        {
            if (this.hp <= 0)
            {
                
                return true;
            }
            return false;
        }

    }

    
    public class PokeGYM
    {
        private Pokemon champ = new Pokemon(10);
        public Pokemon Champ { get { return champ; } }

        public void regenGymChamp()
        {
            champ = new Pokemon(10);
        }

        public void battle(Pokemon trainerPokemon, Pokemon gymPokemon, int turn)
        {
            if (turn == 1)
            {
                trainerPokemon.attackCalculat(gymPokemon);
            }
            else if (turn == 2)
            {
                gymPokemon.attackCalculat(trainerPokemon);
            }
        }
    }



}


