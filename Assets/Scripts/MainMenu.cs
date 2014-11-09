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

    string s0 = "<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>";
    string s1 = "<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>";
    string s2 = "<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>";
    string s3 = "<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>";
    string s4 = "<size=32>Please press" + "\n" + "      ,     or    " + "\n" + "     to join.</size>";

    public List<GameObject> objects;
    public List<KeyCode> blockedButtons;
    public List<Vector3> positions;

    public int currentP = 1;
    
	// Use this for initialization
    void Start()
    {
        blockedButtons = new List<KeyCode>();
        objects = new List<GameObject>();
        positions = new List<Vector3>();

        objects.Add(WKey1);
        objects.Add(WKey2);
        objects.Add(WKey3);
        objects.Add(WKey4);

        objects.Add(UpKey1);
        objects.Add(UpKey2);
        objects.Add(UpKey3);
        objects.Add(UpKey4);

        objects.Add(AButton1);
        objects.Add(AButton2);
        objects.Add(AButton3);
        objects.Add(AButton4);

        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        positions.Add(new Vector3(-1.88f, 0.88f, 0));
        positions.Add(new Vector3(1.3f, 0.88f, 0));
        positions.Add(new Vector3(-1.88f, -0.72f, 0));
        positions.Add(new Vector3(1.3f, -0.72f, 0));

        positions.Add(new Vector3(-1.66f, 0.88f, 0));
        positions.Add(new Vector3(1.51f, 0.88f, 0));
        positions.Add(new Vector3(-1.66f, -0.72f, 0));
        positions.Add(new Vector3(1.51f, -0.72f, 0));

        positions.Add(new Vector3(-1.35f, 0.88f, 0));
        positions.Add(new Vector3(1.83f, 0.88f, 0));
        positions.Add(new Vector3(-1.35f, -0.72f, 0));
        positions.Add(new Vector3(1.83f, -0.72f, 0));

        

        //AButton1.transform.localScale += new Vector3(0.0f, 0, 0);


        /*
        WKey1.transform.localPosition = new Vector3(-1.88f, 0.88f, 0);
        WKey2.transform.localPosition = new Vector3(1.3f, 0.88f, 0);
        WKey3.transform.localPosition = new Vector3(-1.88f, -0.72f, 0);
        WKey4.transform.localPosition = new Vector3(1.3f, -0.72f, 0);

        UpKey1.transform.localPosition = new Vector3(-1.66f, 0.88f, 0);
        UpKey2.transform.localPosition = new Vector3(1.51f, 0.88f, 0);
        UpKey3.transform.localPosition = new Vector3(-1.66f, -0.72f, 0);
        UpKey4.transform.localPosition = new Vector3(1.51f, -0.72f, 0);

        AButton1.transform.localPosition = new Vector3(-1.35f, 0.88f, 0);
        AButton2.transform.localPosition = new Vector3(1.83f, 0.88f, 0);
        AButton3.transform.localPosition = new Vector3(-1.35f, -0.72f, 0);
        AButton4.transform.localPosition = new Vector3(1.83f, -0.72f, 0);
        */

    }
        

    void OnGUI()
    {
        if (currentSubMenu == subMenu.Main)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
                obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].transform.localPosition = positions[i];
            }

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
                foreach (GameObject obj in objects)
                {
                    obj.SetActive(true);
                }
                s1 = s0.Clone().ToString();
                s2 = s0.Clone().ToString();
                s3 = s0.Clone().ToString();
                s4 = s0.Clone().ToString();

                firstStart = false;
            }
            GUI.enabled = false;
            GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.74f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.Button(new Rect(Screen.width * 0.74f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(""));
            GUI.enabled = true;

            GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(s1));
            GUI.Label(new Rect(Screen.width * 0.74f, Screen.height * 0.10f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(s2));
            GUI.Label(new Rect(Screen.width * 0.10f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(s3));
            GUI.Label(new Rect(Screen.width * 0.74f, Screen.height * 0.67f, Screen.width * 0.15f, Screen.height * 0.17f), string.Format(s4));

            

            if (GUI.Button(new Rect(Screen.width * 0.85f, Screen.height * 0.85f, Screen.width * 0.1f, Screen.height * 0.1f), string.Format("<size=20>Back</size>")))
            {
                currentP = 1;
                blockedButtons.Clear();
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
        /*if (currentSubMenu == subMenu.Main)
        {
            s1 = s0.Clone().ToString();
        }*/

        if (currentSubMenu == subMenu.Settings)
        {
            assignPlayers();
            
        }
	}
    void assignPlayers()
    {
        if (currentP == 1)
        {
            if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
            {
                s1 = "";
                KeysP1 = 1;
                blockedButtons.Add(KeyCode.W);
                WKey1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                WKey1.transform.localPosition += new Vector3(0.3f, 0, 0);
                WKey2.SetActive(false);
                WKey3.SetActive(false);
                WKey4.SetActive(false);
                AButton1.SetActive(false);
                UpKey1.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
            {
                s1 = "";
                KeysP1 = 2;
                blockedButtons.Add(KeyCode.UpArrow);
                UpKey1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                UpKey1.transform.localPosition += new Vector3(0.05f, 0, 0);
                UpKey2.SetActive(false);
                UpKey3.SetActive(false);
                UpKey4.SetActive(false);
                AButton1.SetActive(false);
                WKey1.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
            {
                s1 = "";
                KeysP1 = 3;
                blockedButtons.Add(KeyCode.Joystick1Button0);
                AButton1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton1.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey1.SetActive(false);
                WKey1.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
            {
                s1 = "";
                KeysP1 = 4;
                blockedButtons.Add(KeyCode.Joystick2Button0);
                AButton1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton1.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey1.SetActive(false);
                WKey1.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
            {
                s1 = "";
                KeysP1 = 5;
                blockedButtons.Add(KeyCode.Joystick3Button0);
                AButton1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton1.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey1.SetActive(false);
                WKey1.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
            {
                s1 = "";
                KeysP1 = 6;
                blockedButtons.Add(KeyCode.Joystick4Button0);
                AButton1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton1.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey1.SetActive(false);
                WKey1.SetActive(false);
                currentP = 2;
            }
        }
        else if (currentP == 2)
        {
            if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
            {
                s2 = "";
                KeysP2 = 1;
                blockedButtons.Add(KeyCode.W);
                WKey2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                WKey2.transform.localPosition += new Vector3(0.3f, 0, 0);
                WKey1.SetActive(false);
                WKey3.SetActive(false);
                WKey4.SetActive(false);
                AButton2.SetActive(false);
                UpKey2.SetActive(false);
                currentP = 3;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
            {
                s2 = "";
                KeysP2 = 2;
                blockedButtons.Add(KeyCode.UpArrow);
                UpKey2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                UpKey2.transform.localPosition += new Vector3(0.05f, 0, 0);
                UpKey1.SetActive(false);
                UpKey3.SetActive(false);
                UpKey4.SetActive(false);
                AButton2.SetActive(false);
                WKey2.SetActive(false);
                currentP = 2;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
            {
                s2 = "";
                KeysP2 = 3;
                blockedButtons.Add(KeyCode.Joystick1Button0);
                AButton2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton2.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey2.SetActive(false);
                WKey2.SetActive(false);
                currentP = 3;
            }
            else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
            {
                s2 = "";
                KeysP2 = 4;
                blockedButtons.Add(KeyCode.Joystick2Button0);
                AButton2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton2.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey2.SetActive(false);
                WKey2.SetActive(false);
                currentP = 3;
            }
            else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
            {
                s2 = "";
                KeysP2 = 5;
                blockedButtons.Add(KeyCode.Joystick3Button0);
                AButton2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton2.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey2.SetActive(false);
                WKey2.SetActive(false);
                currentP = 3;
            }
            else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
            {
                s2 = "";
                KeysP2 = 6;
                blockedButtons.Add(KeyCode.Joystick4Button0);
                AButton2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton2.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey2.SetActive(false);
                WKey2.SetActive(false);
                currentP = 3;
            }
        }
        else if (currentP == 3)
        {
            if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
            {
                s3 = "";
                KeysP3 = 1;
                blockedButtons.Add(KeyCode.W);
                WKey3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                WKey3.transform.localPosition += new Vector3(0.3f, 0, 0);
                WKey1.SetActive(false);
                WKey2.SetActive(false);
                WKey4.SetActive(false);
                AButton3.SetActive(false);
                UpKey3.SetActive(false);
                currentP = 4;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
            {
                s3 = "";
                KeysP3 = 2;
                blockedButtons.Add(KeyCode.UpArrow);
                UpKey3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                UpKey3.transform.localPosition += new Vector3(0.05f, 0, 0);
                UpKey1.SetActive(false);
                UpKey2.SetActive(false);
                UpKey4.SetActive(false);
                AButton3.SetActive(false);
                WKey3.SetActive(false);
                currentP = 4;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
            {
                s3 = "";
                KeysP3 = 3;
                blockedButtons.Add(KeyCode.Joystick1Button0);
                AButton3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton3.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey3.SetActive(false);
                WKey3.SetActive(false);
                currentP = 4;
            }
            else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
            {
                s3 = "";
                KeysP3 = 4;
                blockedButtons.Add(KeyCode.Joystick2Button0);
                AButton3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton3.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey3.SetActive(false);
                WKey3.SetActive(false);
                currentP = 4;
            }
            else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
            {
                s3 = "";
                KeysP3 = 5;
                blockedButtons.Add(KeyCode.Joystick3Button0);
                AButton3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton3.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey3.SetActive(false);
                WKey3.SetActive(false);
                currentP = 4;
            }
            else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
            {
                s3 = "";
                KeysP3 = 6;
                blockedButtons.Add(KeyCode.Joystick4Button0);
                AButton3.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton3.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey3.SetActive(false);
                WKey3.SetActive(false);

                currentP = 4;
            }
        }
        else if (currentP == 4)
        {
            if (Input.GetKey(KeyCode.W) && !blockedButtons.Contains(KeyCode.W))
            {
                s4 = "";
                KeysP4 = 1;
                blockedButtons.Add(KeyCode.W);
                WKey4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                WKey4.transform.localPosition += new Vector3(0.3f, 0, 0);
                WKey1.SetActive(false);
                WKey2.SetActive(false);
                WKey3.SetActive(false);
                AButton4.SetActive(false);
                UpKey4.SetActive(false);
                currentP = 5;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !blockedButtons.Contains(KeyCode.UpArrow))
            {
                s4 = "";
                KeysP4 = 2;
                blockedButtons.Add(KeyCode.UpArrow);
                UpKey4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                UpKey4.transform.localPosition += new Vector3(0.05f, 0, 0);
                UpKey1.SetActive(false);
                UpKey3.SetActive(false);
                UpKey2.SetActive(false);
                AButton4.SetActive(false);
                WKey4.SetActive(false);
                currentP = 5;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button0) && !blockedButtons.Contains(KeyCode.Joystick1Button0))
            {
                s4 = "";
                KeysP4 = 3;
                blockedButtons.Add(KeyCode.Joystick1Button0);
                AButton4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton4.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey4.SetActive(false);
                WKey4.SetActive(false);
                currentP = 5;
            }
            else if (Input.GetKey(KeyCode.Joystick2Button0) && !blockedButtons.Contains(KeyCode.Joystick2Button0))
            {
                s4 = "";
                KeysP4 = 4;
                blockedButtons.Add(KeyCode.Joystick2Button0);
                AButton4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton4.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey4.SetActive(false);
                WKey4.SetActive(false);
                currentP = 5;
            }
            else if (Input.GetKey(KeyCode.Joystick3Button0) && !blockedButtons.Contains(KeyCode.Joystick3Button0))
            {
                s4 = "";
                KeysP4 = 5;
                blockedButtons.Add(KeyCode.Joystick3Button0);
                AButton4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton4.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey4.SetActive(false);
                WKey4.SetActive(false);
                currentP = 5;
            }
            else if (Input.GetKey(KeyCode.Joystick4Button0) && !blockedButtons.Contains(KeyCode.Joystick4Button0))
            {
                s4 = "";
                KeysP4 = 6;
                blockedButtons.Add(KeyCode.Joystick4Button0);
                AButton4.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                AButton4.transform.localPosition += new Vector3(-0.25f, 0, 0);
                UpKey4.SetActive(false);
                WKey4.SetActive(false);
                currentP = 5;
            }
        }
    }
}
