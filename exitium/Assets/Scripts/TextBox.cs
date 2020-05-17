using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    int textpos = 0;
    public float delay = 0.06f;
    public Text textbox;
    public bool allowTyping = true;
    public bool doneTyping = false;

	public void WriteText(string texttowrite, int voice)
	{
		allowTyping = true;
		doneTyping = false;
		StartCoroutine(Write(texttowrite, voice));
	}


	IEnumerator Write(string thetext, int voice)
	{
		textbox.text = "";
		textpos = 0;
		while (textpos < thetext.Length)
		{
			if (allowTyping == true)
			{
				textbox.text += thetext[textpos++];
			}
			else if (allowTyping == false)
			{
				textbox.text = thetext;
				textpos = thetext.Length;
				break;
			}
			yield return new WaitForSeconds(delay);
		}
		doneTyping = true;
	}
}
