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
            r.DrawRectangle(-6000, 320, 13000, 8000, Color.DARKGRAY);
        }

        public void Update()
        {

        }
    }

}
