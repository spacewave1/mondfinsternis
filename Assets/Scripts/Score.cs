using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Score : NetworkBehaviour {

	public GameObject guiManagerObj;
	[SyncVar]
	private int score = 0;							// Score the players have achieved	
	int sequenceMultiplier = 1;						// Variable for the multipliing points system
    float decreaseWait = 10000f;				// Wait variable that will decrease the multiplier if counted down
	public static Score Instance { get; private set; }

	public void initInstance(){
		Instance = this;
	}

	// Add points to the score if method is called. The players get more points if the position of the asteroid is far away
    public void addToScore(Vector3 positionOfDestroy, int points)
    {
        // Get the range to the platform
        int rangeToZero = (int) positionOfDestroy.magnitude;
        score += points * sequenceMultiplier;

        // Will initiate a Coroutine, which will increase points depending on how fast you can destroy asteroids in succession
        if (sequenceMultiplier == 1)
        {
            sequenceMultiplier = 3;
            //StartCoroutine(SequenceMultiplication());
        }
        
        sequenceMultiplier++;
        updateScoreBoard();
    }

    private void updateScoreBoard()
    {
		guiManagerObj.GetComponent<GuiManager> ().UpdateScore (score);
    }


    // This Coroutine takes care of counting down the sequence multiplicator

	IEnumerator SequenceMultiplication()
    {
        while (true)
        {
            if(sequenceMultiplier == 1)
            {
                break;
            }
            sequenceMultiplier -= 1;
            yield return new WaitForSeconds(decreaseWait);
        }
    }

}
