using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(3,LoadSceneMode.Single);
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Next"))
        {
            NextCharacter();
        }

        if (CrossPlatformInputManager.GetButtonDown("Previous"))
        {
            PreviousCharacter();
        }

        if (CrossPlatformInputManager.GetButtonDown("Play"))
        {
            StartGame();
        }
    }
}
