using Raylib_CsLo;
using System.Diagnostics.CodeAnalysis;

namespace RGame {
    [SuppressMessage("ReSharper", "ReplaceWithSingleAssignment.False")]
    public class Enemy : Entity { 
        
        public int timer {get; private set;}
        bool dec = true;

        public Enemy(int ID) {
            Rect = new Rectangle(Raylib.GetRandomValue(20,770),Raylib.GetRandomValue(20,370),20,20);
            Col = Raylib.DARKGRAY;
            timer = 60; //TIMEDHERE
            this.ID = ID;
        }
        
        protected override void MoveX() {
            
            if (timer == 0) Dir.X = Raylib.GetRandomValue(-1,1);
            if ((Math.Abs(Dir.X) > 0 || Math.Abs(Dir.X) < 0) && (Math.Abs(Dir.Y) > 0 || Math.Abs(Dir.Y) < 0)) 
                Rect.x += 2 * Dir.X * 0.7071f; else Rect.x += 2 * Dir.X;

        }
        
        protected override void MoveY() {
            if (timer == 0) Dir.Y = Raylib.GetRandomValue(-1,1);
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
        
        private void Time() {
            if (dec) {
                timer--;
                if (timer <= 0) dec = false;
            } else {
                timer++;
                if (timer >= 60) dec = true; //TIMEDHERE
            }
        }
        
        public override void Update(List<Entity> CL) {
            Draw(); MoveX(); CollideX(CL); MoveY(); CollideY(CL); Time();
        }
        
    }
}