using PinBallRunner.Prototyping.Scripts.Configuration;

namespace PinBallRunner.Prototyping.Scripts.Common
{
    public class PinballGame
    {
        public GameConfiguration Configuration { get; private set; }

        public PinballGame(GameConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Run()
        {

        }
    }
}
