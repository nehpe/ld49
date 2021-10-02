namespace Ccc.Game
{
    public class GameState
    {
        public static int Health = 100;
        public static int HealthDepreciationRate = 1;

        public static bool GameOver => (Health <= 0);
    }
}