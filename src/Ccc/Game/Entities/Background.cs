using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Background : IEntity
    {
        private Rectangle sprite;
        private Renderer.Renderer r;

        public Background(Renderer.Renderer r)
        {
            sprite = new Rectangle(-6000, 320, 13000, 8000);
            this.r = r;
        }

        public void Draw()
        {
            r.DrawRectangle(
                    (int)sprite.x, (int)sprite.y,
                    (int)sprite.width, (int)sprite.height,
                    Color.DARKGRAY);
        }

        public void Update()
        {

        }

        public bool Dead()
        {
            return false;
        }

        public Rectangle GetRect()
        {
            return new Rectangle();
        }
    }
}
