public class StandardWave : Wave
{
    protected override void SetValues()
    {
			wait = 10;
			rate = 2;
			amount = 25;
			if (Game.level < 6) {
			spread = Game.level * 60;
			} else {
				spread = 360;
      }
			SetFrequencies(8, 1, 1);
    }

}
