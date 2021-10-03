using static Raylib_cs.Raylib;
using Ccc.Game.Scenes;
using System;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Player : IEntity
    {
        private Rectangle sprite;
        private CccGame g;
        private PlayScene s;
        private Renderer.Renderer r;
        private float speed = 170.0f;

        public Player(Renderer.Renderer r, CccGame g, PlayScene s)
        {
            this.sprite = new Rectangle(600, 480, 40, 40);
            this.r = r;
            this.g = g;
            this.s = s;
        }

        public void Draw()
        {
            r.DrawRectangle(
                (int)sprite.x, (int)sprite.y,
                (int)sprite.width, (int)sprite.height,
                Color.RED);
        }

        public void Update()
        {
            // Keyboard Input
            if (r.IsKeyDown(KeyboardKey.KEY_A))
                sprite.x -= speed * r.GetFrameTime();
            if (r.IsKeyDown(KeyboardKey.KEY_D))
                sprite.x += speed * r.GetFrameTime();

            if (r.IsKeyDown(KeyboardKey.KEY_W))
                sprite.y -= speed * r.GetFrameTime();
            if (r.IsKeyDown(KeyboardKey.KEY_S))
                sprite.y += speed * r.GetFrameTime();

            if (r.IsKeyPressed(KeyboardKey.KEY_LEFT))
                this.s.AddProjectile(
                        sprite.x, sprite.y,
                        -1, 0);
            if (r.IsKeyPressed(KeyboardKey.KEY_RIGHT))
                this.s.AddProjectile(
                        sprite.x, sprite.y,
                        1, 0);
            if (r.IsKeyPressed(KeyboardKey.KEY_UP))
                this.s.AddProjectile(
                        sprite.x, sprite.y,
                        0, -1);
            if (r.IsKeyPressed(KeyboardKey.KEY_DOWN))
                this.s.AddProjectile(
                        sprite.x, sprite.y,
                        0, 1);

        }

        public Rectangle GetRect()
        {
            return this.sprite;
        }

        public bool Dead()
        {
            return false;
        }
    }
}
