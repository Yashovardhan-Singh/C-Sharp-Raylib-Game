using Raylib_CsLo;

namespace RGame {
    
    public static class Program {

        public static List<Entity> rl(List<Entity> ml, Entity c, Entity player) {
            List<Entity> tl = new List<Entity>();
            foreach (var i in ml) {
                if (i.ID != c.ID) {
                    tl.Add(i);
                }
            }
            tl.Add(player);
            return tl;
        }
        
        public static void Gen(List<Entity> wl, int noe) {
            wl.Clear();
            for (int i = 0; i < noe; i++) {
                    Enemy tmpe = new Enemy(i);
                    wl.Add(tmpe);
            }
        }

        public static void Main(String[] args) {
            
            Raylib.InitWindow(800, 450, "");
            Raylib.SetTargetFPS(60);
            
            // Groups of entities
            List<Entity> el = new List<Entity>(); // enemy list
            List<Entity> wl = new List<Entity>(); // wall list
            Player p = new Player();
            
            // Load Levels
            using(StreamReader ll = new StreamReader("../../../.assets/1.txt")) {
                while (ll.Peek() >= 0) {
                    // https://stackoverflow.com/questions/911717/split-string-convert-tolistint-in-one-line
                    var nums = ll.ReadLine().Split(',').Select(Int32.Parse).ToList();
                    wl.Add(new Tile {Rect = new Rectangle(nums[0], nums[1], nums[2], nums[3])});
                }
            }
            
            // Load Enemies
            Gen(el, 5);

            Raylib.SetExitKey(KeyboardKey.KEY_F4);
            
            if (args.Contains("-d") || args.Contains("--developer")) Console.WriteLine("DEV-MODE ON");
            
            while (!Raylib.WindowShouldClose()) {

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_F2)) Gen(el, 5);
                
                Raylib.BeginDrawing();
                    Raylib.ClearBackground(Raylib.LIGHTGRAY);
                    foreach (var i in wl.Concat(el)) {
                        i.Update(wl.Concat(rl(el, i, p)).ToList());
                    }
                    p.Update(el.Concat(wl).ToList());
                    Raylib.EndDrawing();
            }
            
            Raylib.CloseWindow();
            
        }
    }
}