using System.Data;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Human : IEntity
    {
        Renderer.Renderer r;
        Rectangle sprite;
        float Health = 10f;
        public bool IsDead = false;

        public Human(Renderer.Renderer r, int x, int y)
        {
            this.r = r;

            sprite = new Rectangle(x, y, 50, 50);
        }

        public void Draw()
        {
            r.DrawRectangle(
                (int)sprite.x, (int)sprite.y,
                (int)sprite.width, (int)sprite.height,
                Color.MAROON);
        }

        public void Update()
        {
            //TODO(np): I should do something, because I am definitely a human and not a log
        }

        public void TakeDamage(Projectile p)
        {
            Health -= p.Dmg;

            if (Health <= 0)
            {
                IsDead = true;
            }
        }

        public Rectangle GetRect()
        {
            return this.sprite;
        }

        public bool Dead()
        {
            return IsDead;
        }
    }
}
