using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using UnityEngine;

public class End : MonoBehaviour
{

    [DllImport("datamine.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string GetFirstName();

    public Transform dialogBox;
    public Transform player;
    private TextBox dialog;
    public Transform CamPos1;
    public Transform CamPos2;

    public static string spookyText = ".̵̜̻̰͖̝͆̈́̇͑͒͐̈́̅̕͝ͅ";

    public string[] msg = {"good day 'peggy a. thoits'. i see you have come to talk", "it's too late, my conquest over your life is complete and now your place has been set"
        ,"i know you hate me, that's my place in your little world", "no matter what you do, you can't get rid of me. face it: i am to you the city upon the hill; and now, you have nowhere else to run to.",
        "lux in tenebris non fulgebunt quod tenebrae eam comprehenderunt.","you can't do anything, you're worthless.", "what're you gonna say? huh?", "I love you.", "what? no. no. no.",
        "69206861746520796f7572206775747320796f752073686f756c6420676f206265erolod ed onod inna M et796f6e6420646561746820616e6420746f206120706c616365206f6620737566666572696e67",
        MakeSpooky(GetFirstName()) + "!!!!!" };

    public int switch1 = 7;
    
    private bool triggered = false;
    private bool triggerLock = false;
    private bool textBoxUp = false;
    private bool isDone = false;

    public int msgi = 0;
    // Start is called before the first frame update
    private void Start()
    {
        string[] temp = {
            "good day 'peggy a. thoits'. i see you have come to talk", "it's too late, my conquest over your life is complete and now your place has been set"
        ,"i know you hate me, that's my place in your little world", "no matter what you do, you can't get rid of me. face it: i am to you the city upon the hill; and now, you have nowhere else to run to.",
        "lux in tenebris non fulgebunt quod tenebrae eam comprehenderunt.","you can't do anything, you're worthless.", "what're you gonna say? huh?", "I love you.", "what? no. no. no.",
        "69206861746520796f7572206775747320796f752073686f756c6420676f206265erolod ed onod inna M et796f6e6420646561746820616e6420746f206120706c616365206f6620737566666572696e67",
        "cain" + "!!!!!" };
        msg = temp;
    }
    void OnTriggerEnter()
    {
        triggered = true;
    }
    void OnTriggerExit()
    {
        triggered = false;
    }

    private void Update()
    {
        if (triggered && !triggerLock)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().HaultMovement();
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            triggerLock = true;
            triggered = false;
            GameManager gm = GameObject.Find("Player").GetComponent<GameManager>();
            if (gm.activeTextWindow == false)
            {
                gm.toggleTextWindow();
            }
            dialog = dialogBox.GetComponent<TextBox>();
            dialog.WriteText(msg[msgi], 1);
            if (msgi == switch1)
            {
                Camera.main.transform.position = CamPos2.position;
                Camera.main.transform.rotation = CamPos2.rotation;
            } else
            {
                Camera.main.transform.position = CamPos1.position;
                Camera.main.transform.rotation = CamPos1.rotation;
            }
        } else if (triggerLock)
        {
            if (isDone)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (msgi == msg.Length - 1)
                    {
                        Application.Quit();
                        Application.LoadLevel(Application.loadedLevel);
                    }
                        
                    isDone = false;
                    triggerLock = false;
                    msgi++;
                    triggered = true;
                }
            } else
            {
                dialog = dialogBox.GetComponent<TextBox>();
                dialog.allowTyping = false;
                isDone = true;
            }
        }
    }
    private static string MakeSpooky(string input)
    {
        string output = "";
        //make a string where each character of the input string is replaced by the sample spooky text
        foreach (char c in input)
        {
            output += spookyText;
        }
        int inputChar = 0;
        //replace the standin character in the spooky text example with each of the characters of the original string
        for (int i = 0; i < output.Length; i++)
        {
            if (output.ToCharArray()[i] == '.')
            {
                char[] temp = output.ToCharArray();
                temp[i] = input.ToCharArray()[inputChar];
                output = temp.ToString();
                inputChar++;
            }
        }
        return output;
    }
}
