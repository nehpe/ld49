using System;
using Ccc.Game.Scenes;

namespace Ccc.Game
{
    public class CccGame : IDisposable
    {
        Renderer.Renderer r;
        IScene currentScene;


        public CccGame()
        {
            r = new Renderer.Renderer(CccSettings.SCREEN_WIDTH,
                    CccSettings.SCREEN_HEIGHT, "CCC v" + CccSettings.VERSION);
            currentScene = new PlayScene(r, this);
        }


        public void Run()
        {
            while (!r.WindowShouldClose())
            {
                currentScene.Update();
                currentScene.Draw();
            }
        }

        public void Dispose()
        {
            r.CloseWindow();
            r = null;
        }
    }
}
