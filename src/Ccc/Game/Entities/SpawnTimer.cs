using Raylib_cs;
using Ccc.Game.Scenes;

namespace Ccc.Game.Entities
{
    public class SpawnTimer : IEntity
    {
        PlayScene s;
        Renderer.Renderer r;

        float timer = 0f;
        float timerMax = 10f;
        float timerIncrement = 1f;

        public SpawnTimer(PlayScene s, Renderer.Renderer r)
        {
            this.s = s;
            this.r = r;
        }

        public void Draw()
        {

        }

        public void Update()
        {
            timer += timerIncrement * r.GetFrameTime();

            if (timer > timerMax)
            {
                timer = 0f;

                s.AddHuman(new Human(this.r,
                        GameState.rnd.Next(0, CccSettings.SCREEN_WIDTH - 50),
                        GameState.rnd.Next(0, CccSettings.SCREEN_HEIGHT - 50)));
            }

        }

        public bool Dead()
        {
            return false;
        }

        public Rectangle GetRect()
        {
            return new Rectangle();
        }
    }
}
