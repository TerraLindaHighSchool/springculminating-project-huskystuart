using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCollide : MonoBehaviour
{

	public Transform TextBox;
	public string Text;
	public Transform Player;
	private TextBox dialogbox;

	bool isTriggered = false;
	bool isDone = false;
	bool triggerLock = false;

	void OnTriggerEnter()
	{
		isTriggered = true;
	}

	void OnTriggerExit()
	{
		isTriggered = false;
	}

	// Update is called once per frame
	void Update()
	{

		if (TextBox.GetComponent<TextBox>().doneTyping == true)
		{
			isDone = true;
		}
		else
		{
			isDone = false;
		}

		if (triggerLock == false)
		{
			if (isTriggered == true)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{

					triggerLock = true;
					isDone = false;
					GameManager areavar = Player.GetComponent<GameManager>();
					if (areavar.activeTextWindow == false)
					{
						areavar.toggleTextWindow();
					}
					Player.GetComponent<PlayerController>().HaultMovement();
					Player.GetComponent<PlayerController>().enabled = false;
					dialogbox = TextBox.GetComponent<TextBox>();
					dialogbox.WriteText(Text, 1);
				}


			}
		}
		else if (triggerLock == true)
		{
			if (isDone == true)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					GameManager areavar = Player.GetComponent<GameManager>();
					if (areavar.activeTextWindow == true)
					{
						areavar.toggleTextWindow();
					}
					Player.GetComponent<PlayerController>().enabled = true;
					isDone = false;
					triggerLock = false;
				}
			}
			else if (isDone == false)
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
					dialogbox = TextBox.GetComponent<TextBox>();
					dialogbox.allowTyping = false;
					isDone = true;
				}
			}
		}


	}
}
