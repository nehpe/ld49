using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class BloodPickup : IEntity
    {
        private Rectangle sprite;
        private Renderer.Renderer r;

        private bool IsDead = false;

        public BloodPickup(int x, int y, Renderer.Renderer r)
        {
            this.r = r;

            sprite = new Rectangle(x, y, 10, 10);
        }

        public void Draw()
        {
            r.DrawRectangle(
                    (int)sprite.x, (int)sprite.y,
                    (int)sprite.width, (int)sprite.height,
                    Color.GREEN);
        }

        public void Update()
        {

        }

        public Rectangle GetRect()
        {
            return this.sprite;
        }

        public bool Dead()
        {
            return IsDead;
        }

        public void Kill()
        {
            IsDead = true;
        }
    }

}
