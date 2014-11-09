using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour {

    public enum subMenu { Main, Settings };

    public subMenu currentSubMenu = subMenu.Main;

    public bool firstStart = true;

    public float buttonTranslate = 1.1f;

    public GameObject AButton1;
    public GameObject AButton2;
    public GameObject AButton3;
    public GameObject AButton4;

    public GameObject WKey1;
    public GameObject WKey2;
    public GameObject WKey3;
    public GameObject WKey4;

    public GameObject UpKey1;
    public GameObject UpKey2;
    public GameObject UpKey3;
    public GameObject UpKey4;

    public static int KeysP1 = 1;
    public static int KeysP2 = 1;
    public static int KeysP3 = 1;
    public static int KeysP4 = 1;


    public List<KeyCode> blockedButtons;

    public int currentP = 1;
    
	// Use this for initialization
	void Start () 
    {
        blockedButtons = new List<KeyCode>();

        AButton1.SetActive(false);
        AButton2.SetActive(false);
        AButton3.SetActive(false);
        AButton4.SetActive(false);

        WKey1.SetActive(false);
        WKey2.SetActive(false);
        WKey3.SetActive(false);
        WKey4.SetActive(false);

        UpKey1.SetActive(false);
        UpKey2.SetActive(false);
        UpKey3.SetActive(false);
        UpKey4.SetActive(false);

        //AButton1.transform.localScale += new Vector3(0.0f, 0, 0);
        AButton1.transform.localPosition = new Vector3(-1.35f, 0.88f, 0);
        AButton2.transform.localPosition = new Vector3(1.83f, 0.88f, 0);
        AButton3.transform.localPosition = new Vector3(-1.35f, -0.72f, 0);
        AButton4.transform.localPosition = new Vector3(1.83f, -0.72f, 0);

        WKey1.transform.localPosition = new Vector3(-1.88f, 0.88f, 0);
        WKey2.transform.localPosition = new Vector3(1.3f, 0.88f, 0);
        WKey3.transform.localPosition = new Vector3(-1.88f, -0.72f, 0);
        WKey4.transform.localPosition = new Vector3(1.3f, -0.72f, 0);

        UpKey1.transform.localPosition = new Vector3(-1.66f, 0.88f, 0);
        UpKey2.transform.localPosition = new Vector3(1.51f, 0.88f, 0);
        UpKey3.transform.localPosition = new Vector3(-1.66f, -0.72f, 0);
        UpKey4.transform.localPosition = new Vector3(1.51f, -0.72f, 0);      
	}

    void OnGUI()
    {
        if (currentSubMenu == subMenu.Main)
        {
            if (GUI.Button(new Rect(Screen.width * 0.40f, Screen.height * 0.3f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Start</size>")))
            {
                firstStart = true;
                currentSubMenu = subMenu.Settings;
            }
            if (GUI.Button(new Rect(Screen.width * 0.40f, Screen.height * 0.6f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Ausfahrt</size>")))
            {
                Application.Quit();
            }
        }
        else if (currentSubMenu == subMenu.Settings)
        {
            if (firstStart)
            {
                AButton1.SetActive(true);
                AButton2.SetActive(true);
                AButton3.SetActive(true);
                AButton4.SetActive(true);

                WKey1.SetActive(true);
                WKey2.SetActive(true);
                WKey3.SetActive(true);
                WKey4.SetActive(true);

                UpKey1.SetActive(true);
                UpKey2.SetActive(true);
                UpKey3.SetActive(true);
                UpKey4.SetActive(true);

                firstStart = false;
            }
            GUI.enabled = false;
            GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.74f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.74f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.enabled = true;

            GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>"));
            GUI.Label(new Rect(Screen.width * 0.74f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>"));
            GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>"));
            GUI.Label(new Rect(Screen.width * 0.74f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>"));

            
            
            





            //GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.40f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format((WKey1.transform.localPosition).ToString()));

            if (GUI.Button(new Rect(Screen.width * 0.85f, Screen.height * 0.85f, Screen.width * 0.1f, Screen.height * 0.1f), string.Format("<size=20>Back</size>")))
            {
                
                currentSubMenu = subMenu.Main;
            }
            if (GUI.Button(new Rect(Screen.width * 0.40f, Screen.height * 0.3f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format("<size=32>Start Game</size>")))
            {
                Application.LoadLevel("CordsPlayground");
            }
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        

        Debug.Log(currentP);
        //assign players to controls
        if (currentP == 1)
        {         
            if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
            {
                KeysP1 = 1;
                blockedButtons.Add(KeyCode.W);
                WKey1.SetActive(false);
                WKey2.SetActive(false);
                WKey3.SetActive(false);
                WKey4.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
            {
                KeysP1 = 2;
                blockedButtons.Add(KeyCode.UpArrow);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
            {
                KeysP1 = 3;
                blockedButtons.Add(KeyCode.Joystick1Button0);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
            {
                KeysP1 = 4;
                blockedButtons.Add(KeyCode.Joystick2Button0);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
            {
                KeysP1 = 5;
                blockedButtons.Add(KeyCode.Joystick3Button0);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
            {
                KeysP1 = 6;
                blockedButtons.Add(KeyCode.Joystick4Button0);
                currentP = 2;
            }
        }
            else if (currentP == 2)
            {
                if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
                {
                    KeysP2 = 1;
                    blockedButtons.Add(KeyCode.W);
                    WKey1.SetActive(false);
                    WKey2.SetActive(false);
                    WKey3.SetActive(false);
                    WKey4.SetActive(false);
                    currentP = 3;
                }
                else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
                {
                    KeysP2 = 2;
                    blockedButtons.Add(KeyCode.UpArrow);
                    currentP = 3;
                }
                else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
                {
                    KeysP2 = 3;
                    blockedButtons.Add(KeyCode.Joystick1Button0);
                    currentP = 3;
                }
                else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
                {
                    KeysP2 = 4;
                    blockedButtons.Add(KeyCode.Joystick2Button0);
                    currentP = 3;
                }
                else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
                {
                    KeysP2 = 5;
                    blockedButtons.Add(KeyCode.Joystick3Button0);
                    currentP = 3;
                }
                else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
                {
                    KeysP2 = 6;
                    blockedButtons.Add(KeyCode.Joystick4Button0);
                    currentP = 3;
                }
            }
                else if (currentP == 3)
                {
                    if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
                    {
                        KeysP3 = 1;
                        blockedButtons.Add(KeyCode.W);
                        WKey1.SetActive(false);
                        WKey2.SetActive(false);
                        WKey3.SetActive(false);
                        WKey4.SetActive(false);
                        currentP = 4;
                    }
                    else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
                    {
                        KeysP3 = 2;
                        blockedButtons.Add(KeyCode.UpArrow);
                        currentP = 4;
                    }
                    else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
                    {
                        KeysP3 = 3;
                        blockedButtons.Add(KeyCode.Joystick1Button0);
                        currentP = 4;
                    }
                    else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
                    {
                        KeysP3 = 4;
                        blockedButtons.Add(KeyCode.Joystick2Button0);
                        currentP = 4;
                    }
                    else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
                    {
                        KeysP3 = 5;
                        blockedButtons.Add(KeyCode.Joystick3Button0);
                        currentP = 4;
                    }
                    else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
                    {
                        KeysP3 = 6;
                        blockedButtons.Add(KeyCode.Joystick4Button0);
                        currentP = 4;
                    }
                }
                    else if (currentP == 4)
                    {
                        if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
                        {
                            KeysP4 = 1;
                            blockedButtons.Add(KeyCode.W);
                            WKey1.SetActive(false);
                            WKey2.SetActive(false);
                            WKey3.SetActive(false);
                            WKey4.SetActive(false);
                            currentP = 5;
                        }
                        else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
                        {
                            KeysP4 = 2;
                            blockedButtons.Add(KeyCode.UpArrow);
                            currentP = 5;
                        }
                        else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
                        {
                            KeysP4 = 3;
                            blockedButtons.Add(KeyCode.Joystick1Button0);
                            currentP = 5;
                        }
                        else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
                        {
                            KeysP4 = 4;
                            blockedButtons.Add(KeyCode.Joystick2Button0);
                            currentP = 5;
                        }
                        else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
                        {
                            KeysP4 = 5;
                            blockedButtons.Add(KeyCode.Joystick3Button0);
                            currentP = 5;
                        }
                        else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
                        {
                            KeysP4 = 6;
                            blockedButtons.Add(KeyCode.Joystick4Button0);
                            currentP = 5;
                        }
                    }
        /*
        if (Input.GetKey("up"))
            WKey1.transform.localPosition += new Vector3(0, 0.01f, 0);
        else if (Input.GetKey("down"))
            WKey1.transform.localPosition += new Vector3(0, -0.01f, 0);
        else if (Input.GetKey("left"))
            WKey1.transform.localPosition += new Vector3(-0.01f, 0, 0);
        else if (Input.GetKey("right"))
            WKey1.transform.localPosition += new Vector3(0.01f, 0, 0);

        Debug.Log(AButton1.transform.localPosition);
        */
	}
}
