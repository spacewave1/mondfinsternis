public class StormWave : Wave
	{
		protected void SetValues(){
			wait = 5;
			rate = 0.5f;
			amount = 20;
			spread = 30;
			SetFrequencies(0, 0, 1);
		}
}
