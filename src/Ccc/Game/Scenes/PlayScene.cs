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

        public PlayScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;

            this.bg = new Background(r);
            this.player = new Player(r);

            this.h = new HUD.Hud(r);
        }

        public void Draw()
        {
            r.ClearBackground(BLACK);
            r.BeginDrawing();
            {
                bg.Draw();

                player.Draw();


                r.DrawFPS(10, 10);
                h.Draw();
            }
            r.EndDrawing();
        }

        public void Update()
        {
            bg.Update();
            player.Update();
            h.Update();
        }
    }
}