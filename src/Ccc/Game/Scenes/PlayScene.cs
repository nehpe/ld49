using System;
using System.Collections.Generic;
using System.Numerics;
using Ccc.Game.Entities;
using Ccc.Game.HUD;
using Ccc.Game.Utilities;
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

        SpawnTimer st;

        List<Projectile> Projectiles = new List<Projectile>();
        List<Human> Humans = new List<Human>();
        List<IEntity> Pickups = new List<IEntity>();

        public PlayScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;

            this.bg = new Background(r);
            this.player = new Player(r, g, this);

            this.h = new HUD.Hud(r);

            Humans.Add(
                new Human(this.r,
                    GameState.rnd.Next(0, CccSettings.SCREEN_WIDTH - 50),
                    GameState.rnd.Next(0, CccSettings.SCREEN_HEIGHT - 50))
            );

            st = new SpawnTimer(this, this.r);

            this.load();
        }

        private void load()
        {
            AssetManager.AddTexture("grass", r.LoadTexture("Assets/grass.png"));
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

                foreach (IEntity p in Pickups)
                    p.Draw();


                r.DrawFPS(10, 10);
                h.Draw();
            }
            r.EndDrawing();
        }

        public void Update()
        {
            if (GameState.GameOver)
            {
                this.g.ChangeScene(new GameOverScene(this.r, this.g));
            }

            bg.Update();
            player.Update();
            foreach (Projectile p in Projectiles)
            {
                p.Update();
            }

            foreach (Human human in Humans)
            {
                h.Update();
            }

            foreach (IEntity p in Pickups)
                p.Update();

            h.Update();


            // Check for collisions

            bulletCollisions();
            pickups();

            // Should I spawn a human?
            st.Update();
        }

        private void bulletCollisions()
        {
            // There's probably a better way to do this but whatever gamejam
            foreach (Projectile p in Projectiles)
            {
                foreach (Human human in Humans)
                {
                    if (r.CheckCollisionRecs(p.GetRect(), human.GetRect()))
                    {
                        p.Kill();
                        human.TakeDamage(p);
                        if (human.Dead())
                        {
                            // Spawn a pickup?
                            Pickups.Add(new BloodPickup(
                                (int) human.GetRect().x,
                                (int) human.GetRect().y,
                                this.r));
                        }
                    }
                }
            }

            // Cleanup ded objects
            cleanupProjectile();
            cleanupHumans();
        }

        private void pickups()
        {
            foreach (IEntity p in Pickups)
            {
                BloodPickup bp = (BloodPickup) p;
                if (r.CheckCollisionRecs(player.GetRect(), p.GetRect()) && !bp.Dead())
                {
                    bp.Kill();
                    GameState.Health += 10;
                }
            }
            
            cleanupPickups();
        }

        private void cleanupPickups()
        {
            Pickups.RemoveAll(e => e.Dead());
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

        public void AddHuman(Human human)
        {
            Humans.Add(human);
        }
    }
}