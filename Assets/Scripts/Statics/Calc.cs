using UnityEngine;
using System;

public static class Calc{

//Rolls an index for an array of different probabilites
//Useful for asteroid and loot spawning
public static int WeightedRandomIndex(int[] weights){
        int[] accumulatedWeights = new int[weights.Length];
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
        total += weights[i];
            for (int j = i; j >= 0; j--){
              accumulatedWeights[i] += weights[j];
            }
        }
        int random = new System.Random().Next(total);
        int index = 0;
        for (int i = 0; i<weights.Length; i++){
          if (random < accumulatedWeights[i]) {
              index = i;
              break;
          }
        }
        return index;
    }
  public static Vector2 RandomCirclePoint(int radius){
      int direction = new System.Random().Next(360);
		int x = (int)(radius*Math.Cos(DegreeToRadian(direction)));
		int y = (int)(radius*Math.Sin(DegreeToRadian(direction)));
      return new Vector2(x, y);
    }
  public static Vector2 PolarToCartesian(int radius, int angle){
		int x = (int)(radius * Math.Cos(DegreeToRadian(angle)));
		int z = (int)(radius * Math.Sin(DegreeToRadian(angle)));
    return new Vector2(x,z);
    }
    public static bool LootRoll(float chance)
    {
        double number = new System.Random().NextDouble();
        if (chance >= number ){
          return true;
        }
        else {
          return false;
        }
    }
	private static double DegreeToRadian(int angle){
		return Math.PI * angle / 180.0;
	}
}
