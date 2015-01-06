using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int gameDifficulty = 2;

	public int CHA, CON, DEX, INT, STR, WIL;
	private GameObject CHA_value, CON_value, DEX_value, INT_value, STR_value, WIL_value;
	private Text CHA_text, CON_text, DEX_text, INT_text, STR_text, WIL_text;

	public int Cha, Con, Dex, Int, Str, Wil;

	public int Height, Weight;
	private GameObject Height_value, Weight_value;
	private Text Height_text, Weight_text;

	private int[] Amod = {-5,-5,-4,-3,-2,-2,-1,-1,-1,0,0,0,0,1,1,1,2,2,3,4,5}; 

	// Use this for initialization
	void Start () {
		RollNewCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RollNewCharacter() {

		// Roll 3D6+0 for each attribute, 
		// 	Lower difficulties get more attempts at a higher roll
		CHA = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);
		CON = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);
		DEX = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);
		INT = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);
		STR = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);
		WIL = Dice.DiceRoll (3, 6, 0, 4 - gameDifficulty);

		CalculateAttributeModifier ();

		// Base Height (inches)
		// Male: 58 + 4D6
		// Female: 53 + 4D6
		Height = Dice.DiceRoll (4, 6, 58);

		// Base Weight (pounds)
		// Height (in inches) + 40 + (4D6 * 3) + (Str * 10)
		Weight = Height + 40 + (Dice.DiceRoll(4,6) * 3) + (Str * 10);

		UpdateCharacterScreen ();
	}

	private void CalculateAttributeModifier() {
		Str = Amod [STR];
	}

	private void UpdateCharacterScreen() {
		CHA_value = GameObject.Find ("CHA_value");
		CHA_text = CHA_value.GetComponent<Text> ();
		CHA_text.text = CHA.ToString();
		CON_value = GameObject.Find ("CON_value");
		CON_text = CON_value.GetComponent<Text> ();
		CON_text.text = CON.ToString();
		DEX_value = GameObject.Find ("DEX_value");
		DEX_text = DEX_value.GetComponent<Text> ();
		DEX_text.text = DEX.ToString();	
		INT_value = GameObject.Find ("INT_value");
		INT_text = INT_value.GetComponent<Text> ();
		INT_text.text = INT.ToString();
		STR_value = GameObject.Find ("STR_value");
		STR_text = STR_value.GetComponent<Text> ();
		STR_text.text = STR.ToString();
		WIL_value = GameObject.Find ("WIL_value");
		WIL_text = WIL_value.GetComponent<Text> ();
		WIL_text.text = WIL.ToString();
		
		Height_value = GameObject.Find ("Height_value");
		Height_text = Height_value.GetComponent<Text> ();
		Height_text.text = Height.ToString();		
		Weight_value = GameObject.Find ("Weight_value");
		Weight_text = Weight_value.GetComponent<Text> ();
		Weight_text.text = Weight.ToString();
	}




}
