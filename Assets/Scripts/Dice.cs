using UnityEngine;

public class Dice	{
	// Roll Dice
	public static int DiceRoll(int quantity, int sides = 1, int modifier = 0, int attempts = 1) {
		
		// The value of all the dice that we will return
		int sum = 0;
		
		// The temporary value
		int tmp = 0;
		
		// Get the highest value for each attempt
		for (int a = 1; a <= attempts; a++) {
			tmp = 0;
			// Roll a dice for every quantity
			for (int q = 1; q <= quantity; q++) {
				tmp += GetRandomInt (sides);
				
				// If the value is higher than the previous attempt, use this one
				if(tmp > sum) sum = tmp;
			}
		}
		
		// Add the modifier
		sum += modifier;
		
		return sum;
	}

	// Generate a random number
	// If max is null, min is set to 1, and the only value passed becomes the max
	private static int GetRandomInt(int min, int max = 0) {
		if (max == 0) {
			max = min;
			min = 1;
		}
		
		return Random.Range (min, max + 1);
	}
}


