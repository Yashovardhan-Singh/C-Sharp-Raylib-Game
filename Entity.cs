using Raylib_CsLo;
using System.Numerics;

namespace RGame {
    public class Entity {
        
        public Rectangle Rect = new Rectangle(400,225,25,25);
        protected Vector2 Dir = new Vector2(0,0);
        protected Color Col = Raylib.RED;

        public int ID {get; protected set;}
        
        protected virtual void Draw() {
            Raylib.DrawRectangleRec(Rect, Col);
        }
        
        protected virtual void MoveX() { }
        protected virtual void MoveY() { }
        protected virtual void CollideX(List<Entity> CL) { }
        protected virtual void CollideY(List<Entity> CL) { }
       
        public virtual void Update(List<Entity> CL) {Draw(); MoveX(); CollideX(CL); MoveY(); CollideY(CL);}
        
    }

    public class Tile : Entity {
        public Tile() {
            Col = Raylib.GRAY;
        }
        public override void Update(List<Entity> CL) {
            Draw();
        }
    }

}