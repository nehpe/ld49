using System;
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
        List<Human> Humans = new List<Human>();

        public PlayScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;

            this.bg = new Background(r);
            this.player = new Player(r, g, this);

            this.h = new HUD.Hud(r);

            Humans.Add(
                new Human(this.r,
                    GameState.rnd.Next(0, CccSettings.SCREEN_WIDTH),
                    GameState.rnd.Next(0, CccSettings.SCREEN_HEIGHT))
            );
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

                foreach (Human h in Humans)
                {
                    h.Draw();
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
                Console.WriteLine(p.GetRect());
            }

            foreach (Human human in Humans)
            {
                h.Update();
            }

            h.Update();


            // Check for collisions

            // There's probably a better way to do this but whatever gamejam
            foreach (Projectile p in Projectiles)
            {
                foreach (Human human in Humans)
                {
                    Console.WriteLine("Projectile:" + p.GetRect());
                    Console.WriteLine("Human:" + human.GetRect());
                    if (r.CheckCollisionRecs(p.GetRect(), human.GetRect()))
                    {
                        Console.WriteLine("I collided");
                        p.Kill();
                        human.TakeDamage(p);
                    }
                }
            }
            // Cleanup ded objects
            cleanupProjectile();
            cleanupHumans();

            // Should I spawn a human?
            /*if (GameState.rnd.Next(0, 10) >= 8)
            {
                Humans.Add(
                    new Human(this.r,
                        GameState.rnd.Next(0, CccSettings.SCREEN_WIDTH),
                        GameState.rnd.Next(0, CccSettings.SCREEN_HEIGHT))
                );
            }*/
        }

        private void cleanupHumans()
        {
            Humans.RemoveAll(e => e.Dead());
        }
        
        private void cleanupProjectile()
        {
            Projectiles.RemoveAll(e => e.Dead());
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
