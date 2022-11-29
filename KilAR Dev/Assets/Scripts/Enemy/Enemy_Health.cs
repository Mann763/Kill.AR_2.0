using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Transform centerPoint;

    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    //Ragdoll ragdoll;

    public HealthBar healthBar;

    //public GameObject damageText;

    public Transform cam;

    WeaponScript Ws;
    public ui_manager Ui_m;

    public int addScore;
    public int addCoin;


    // Update is called once per frame
    void LateUpdate()
    {
        // - is used because its mirrored
        transform.LookAt(cam.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();

        this.transform.parent = centerPoint;

        Ui_m = GameObject.FindGameObjectWithTag("UI_MGR").GetComponent<ui_manager>();
        Ws = GetComponent<WeaponScript>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        //ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;

        var Collider = GetComponentsInChildren<BoxCollider>();
        foreach(var Collider_ in Collider)
        {
            HitBox hitbox = Collider_.gameObject.AddComponent<HitBox>();
            hitbox.health = this;
        }
    }

    public void TakeDamage(int amount, Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        //Damage_popup popup = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<Damage_popup>();
        //popup.SetDamageText(amount);
        if (currentHealth <= 0)
        {
            AddScore();
            AddCoin();
            Die();
        }
    }

    private void Die()
    {
        //ragdoll.ActivateRagdoll();
        Destroy(this.gameObject);
        //healthBar.gameObject.SetActive(false);
    }

    private void AddScore()
    {
        Ui_m.score += addScore;
        Ui_m.ScoreRefresh(Ui_m.score);
    }

    private void AddCoin()
    {
        Ui_m.coin += addCoin;
        Ui_m.CoinRefresh(Ui_m.coin);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
