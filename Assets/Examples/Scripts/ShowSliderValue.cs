using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;


public class ShowSliderValue : MonoBehaviour
{
    [SerializeField]
    private Text lbl;
	public void UpdateLabel (float value)
	{
		if (lbl != null)
			lbl.text = Mathf.RoundToInt (value * 100) + "%";
	}
}
