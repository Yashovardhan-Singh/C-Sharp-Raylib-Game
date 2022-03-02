using Raylib_CsLo;

namespace RGame {
    public class Player : Entity {
        
        protected override void MoveX() {
            
            if (Raylib.IsKeyDown((KeyboardKey.KEY_A))) Dir.X = -1;
            else if (Raylib.IsKeyDown((KeyboardKey.KEY_D))) Dir.X = 1;
            else Dir.X = 0;
            
            if ((Math.Abs(Dir.X) > 0 || Math.Abs(Dir.X) < 0) && (Math.Abs(Dir.Y) > 0 || Math.Abs(Dir.Y) < 0)) 
                Rect.x += 2 * Dir.X * 0.7071f; else Rect.x += 2 * Dir.X;

        }
        
        protected override void MoveY() {
            if (Raylib.IsKeyDown((KeyboardKey.KEY_W))) Dir.Y = -1;
            else if (Raylib.IsKeyDown((KeyboardKey.KEY_S))) Dir.Y = 1;
            else Dir.Y = 0;
            
            if ((Math.Abs(Dir.X) > 0 || Math.Abs(Dir.X) < 0) && (Math.Abs(Dir.Y) > 0 || Math.Abs(Dir.Y) < 0)) 
                Rect.y += 2 * Dir.Y * 0.7071f; else Rect.y += 2 * Dir.Y;
            
        }
        
        protected override void CollideX(List<Entity> CL) {
            foreach (var i in CL) {
                bool collx = Raylib.CheckCollisionRecs(Rect, i.Rect);
                if (collx) {
                    if (Dir.X == 1) {Rect.X = i.Rect.X - Rect.width;}
                    else if (Dir.X == -1) {Rect.X = i.Rect.X + i.Rect.width;}
                }
            }
            if (Rect.x <= 0) Rect.x = 0;
            if (Rect.x >= 775) Rect.x = 775;
        }
        
        protected override void CollideY(List<Entity> CL) {
            foreach (var i in CL) {
                bool collx = Raylib.CheckCollisionRecs(Rect, i.Rect);
                if (collx) {
                    if (Dir.Y == 1) {Rect.Y = i.Rect.Y - Rect.height;}
                    else if (Dir.Y == -1) {Rect.Y = i.Rect.Y + i.Rect.height;}
                }
            }
            if (Rect.y <= 0) Rect.y = 0;
            if (Rect.y >= 425) Rect.y = 425;
        }
        
        public override void Update(List<Entity> CL) {
            Draw(); MoveX(); CollideX(CL); MoveY(); CollideY(CL);
        }
        
    }
}