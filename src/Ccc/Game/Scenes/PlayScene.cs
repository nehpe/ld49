using static Raylib_cs.Color;

namespace Ccc.Game.Scenes
{
    public class PlayScene : IScene
    {
        Renderer.Renderer r;
        CccGame g;

        public PlayScene(Renderer.Renderer r, CccGame g)
        {
            this.r = r;
            this.g = g;
        }

        public void Draw()
        {
            r.ClearBackground(BLACK);
            r.BeginDrawing();
            r.DrawText("Oh hai", 100, 100, 48, WHITE);
            r.DrawFPS(10, 10);
            r.EndDrawing();
        }

        public void Update()
        {

        }
    }
}
