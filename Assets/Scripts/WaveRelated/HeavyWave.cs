public class HeavyWave : Wave
	{
		protected override void SetValues(){
			wait = 15;
			rate = 2;
			amount = 30;
			spread = 360;
			SetFrequencies(5, 4, 1);
		}
}
