using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    //public TMP_Text label;

    // Start is called before the first frame update
    private void Awake()
    {
        
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject cloan = Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        //label.text = prefab.name;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
