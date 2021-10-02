using System.Collections.Generic;
using System.Numerics;
using Ccc.Game.Entities;
using Ccc.Game.HUD;
using static Raylib_cs.Color;

namespace Ccc.Game.Scenes
{
    public class PlayScene : IScene
    {
        Renderer.Renderer r;
        CccGame g;

        Player player;
        Background bg;
        HUD.Hud h;

        List<Projectile> Projectiles = new List<Projectile>();

        public PlayScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;

            this.bg = new Background(r);
            this.player = new Player(r, g, this);

            this.h = new HUD.Hud(r);
        }

        public void Draw()
        {
            r.ClearBackground(BLACK);
            r.BeginDrawing();
            {
                bg.Draw();

                player.Draw();

                foreach (Projectile p in Projectiles)
                {
                    p.Draw();
                }


                r.DrawFPS(10, 10);
                h.Draw();
            }
            r.EndDrawing();
        }

        public void Update()
        {
            bg.Update();
            player.Update();
            foreach (Projectile p in Projectiles)
            {
                p.Update();
            }
            h.Update();
        }

        public void AddProjectile(float x, float y,
                float vx, float vy)
        {
            Projectiles.Add(new Projectile(
                        this.r,
                        new Vector2(x, y),
                        new Vector2(vx, vy)));
        }
    }
}
