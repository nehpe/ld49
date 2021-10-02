using System.Numerics;
using Raylib_cs;
namespace Ccc.Game.Entities
{
    public class Projectile : IEntity
    {
        Rectangle sprite;
        Vector2 velocity;

        public float speed = 100f;

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
                    (int) sprite.x, (int) sprite.y,
                    (int) sprite.width, (int) sprite.height,
                    Color.YELLOW);
        }

        public void Update()
        {
            // Move the projectile
            sprite.x += velocity.X * speed * r.GetFrameTime();
            sprite.y += velocity.Y * speed * r.GetFrameTime();
        }

    }
}
