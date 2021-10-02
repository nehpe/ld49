using System.Numerics;
using Raylib_cs;

namespace Ccc.Game.Entities
{
    public class Bloodometer : IEntity
    {
        Renderer.Renderer r;
        string HealthFormat = "Health: {0}";
        Vector2 bloodPosition;
        
        float timer = 0f;
        private float timerSpeed = 2f;
        float timerMax = 5f;

        public Bloodometer(Renderer.Renderer r)
        {
            this.r = r;
            
            var measure = r.MeasureText(HealthFormat, 28);

            bloodPosition = new Vector2(
                CccSettings.SCREEN_WIDTH - measure - 28,
                CccSettings.SCREEN_HEIGHT - 48);
        }

        public void Draw()
        {
            r.DrawText(
                string.Format(HealthFormat, GameState.Health),
                (int) bloodPosition.X, (int) bloodPosition.Y,
                28, Color.RED);
        }

        public void Update()
        {
            timer += timerSpeed * r.GetFrameTime();
            if (timer > timerMax)
            {
                timer = 0f;
                GameState.Health -= GameState.HealthDepreciationRate;
            }
        }

        public bool Dead()
        {
            return false;
        }
    }
}