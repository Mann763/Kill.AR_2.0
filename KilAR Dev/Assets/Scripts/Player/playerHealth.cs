using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [HideInInspector]
    public float currentHealth;
    
    public float maxHealth;

    public HealthBar healthBar;

    [SerializeField] private Image redSplatterImage = null;

    [Header("Hurt Image Flash")]
    [SerializeField] private Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;

    //[Header("Audio Name")]
    //[SerializeField] private AudioClip hurtAudio = null;
    //private AudioSource healthAudioSource;

    void Start()
    {
        //healthAudioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar = GameObject.FindGameObjectWithTag("Player_Health").GetComponent<HealthBar>();
        hurtImage = GameObject.FindGameObjectWithTag("Hurt").GetComponent<Image>();
        redSplatterImage = GameObject.FindGameObjectWithTag("Flash").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if(currentHealth>= 0)
        {
            StartCoroutine(HurtFlash());
            currentHealth -= amount;
            healthBar.SetHealth(currentHealth);
            UpdateHealth();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //healthBar.gameObject.SetActive(false);
    }

    void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - (currentHealth / maxHealth);
        redSplatterImage.color = splatterAlpha;
    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        //healthAudioSource.PlayOneShot(hurtAudio);
        yield return new WaitForSeconds(hurtTimer);
        hurtImage.enabled = false;
    }
}
