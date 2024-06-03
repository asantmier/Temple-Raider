using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PauseMenu : MonoBehaviour
{
    public PlayerInput input;
    public StarterAssetsInputs sai;
    public GameObject menu;
    public GameObject victory;
    public GameObject begin;
    public GameObject player;
    public GameObject startCam;
    private bool won;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        victory.SetActive(false);
        begin.SetActive(true); 
        won = false;
        started = false;
        player.SetActive(false);
        input.enabled = false;
        sai.cursorInputForLook = false;
        sai.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        startCam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            begin.SetActive(false);
            started = true;
            player.SetActive(true);
            input.enabled = true;
            sai.cursorInputForLook = true;
            sai.cursorLocked = true;
            Cursor.lockState = CursorLockMode.Locked;
            startCam.SetActive(false);
        }
        else if (started && !won && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleMenu(true);
        }
    }

    private void ToggleMenu(bool isopen)
    {
        menu.SetActive(isopen);
        input.enabled = !isopen;
        sai.cursorInputForLook = !isopen;
        sai.cursorLocked = !isopen;
        Cursor.lockState = isopen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void CloseMenu()
    {
        ToggleMenu(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void DoVictory()
    {
        victory.SetActive(true);
        input.enabled = false;
        sai.cursorInputForLook = false;
        sai.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
