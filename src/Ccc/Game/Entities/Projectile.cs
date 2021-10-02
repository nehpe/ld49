using System.Numerics;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Projectile : IEntity
    {
        Rectangle sprite;
        Vector2 velocity;
        public float Dmg = 5f;

        public float speed = 200f;

        public bool IsDead = false;

        private Renderer.Renderer r;

        public Projectile(Renderer.Renderer r,
            Vector2 p, Vector2 v)
        {
            this.r = r;
            this.sprite = new Rectangle(p.X, p.Y, 20, 20);
            this.velocity = v;
        }

        public void Draw()
        {
            r.DrawRectangle(
                (int)sprite.x, (int)sprite.y,
                (int)sprite.width, (int)sprite.height,
                Color.YELLOW);
        }

        public void Update()
        {
            // Move the projectile
            if (!IsDead)
            {
                sprite.x += velocity.X * speed * r.GetFrameTime();
                sprite.y += velocity.Y * speed * r.GetFrameTime();
            }
        }

        public Rectangle GetRect()
        {
            return this.sprite;
        }

        public void Kill()
        {
            IsDead = true;
        }

        public bool Dead()
        {
            return IsDead;
        }
    }
}
