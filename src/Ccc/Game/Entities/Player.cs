using static Raylib_cs.Raylib;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Player : IEntity
    {
        private Rectangle sprite;
        private Renderer.Renderer r;
        private float speed = 170.0f;

        public Player(Renderer.Renderer r)
        {
            this.sprite = new Rectangle(400, 280, 40, 40);
            this.r = r;
        }

        public void Draw()
        {
            r.DrawRectangle(
                (int) sprite.x, (int) sprite.y,
                (int) sprite.width, (int) sprite.height,
                Color.RED);
        }

        public void Update()
        {
            if (r.IsKeyDown(KeyboardKey.KEY_A))
                sprite.x -= speed * r.GetFrameTime();
            if (r.IsKeyDown(KeyboardKey.KEY_D))
                sprite.x += speed * r.GetFrameTime();
            
            if (r.IsKeyDown(KeyboardKey.KEY_W))
                sprite.y -= speed * r.GetFrameTime();
            if (r.IsKeyDown(KeyboardKey.KEY_S))
                sprite.y += speed * r.GetFrameTime();
        }
    }
}