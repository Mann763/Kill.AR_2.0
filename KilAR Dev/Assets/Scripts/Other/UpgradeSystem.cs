using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UpgradeSystem : MonoBehaviour
{
    playerHealth Phealth;
    ui_manager ui;
    ProjectileMoveScript pMover;
    WeaponScript weapon;
    Spawner spawn;

    public int coinToUpgrade; 

    // Start is called before the first frame update
    void Start()
    {
        Phealth = GetComponent<playerHealth>();
        ui = GetComponent<ui_manager>();
        pMover = GetComponent<ProjectileMoveScript>();
        weapon = GetComponent<WeaponScript>();
        spawn = GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Add_Health") && ui.coin >= coinToUpgrade)
        {
            ui.coin =- coinToUpgrade;
            ui.CoinRefresh(ui.coin);

            Phealth.currentHealth = Phealth.maxHealth;
            Phealth.healthBar.SetHealth(Phealth.currentHealth);

            pMover.player_Hit += 2;
        }

        if (CrossPlatformInputManager.GetButtonDown("Add_Damage") && ui.coin >= coinToUpgrade)
        {
            ui.coin = -coinToUpgrade;
            ui.CoinRefresh(ui.coin);

            weapon.GiveDamage += 3;
            pMover.player_Hit += 2;
        }

        if (CrossPlatformInputManager.GetButtonUp("Add_Health"))
        {
            ui.upgradeSystem.SetActive(false);
            spawn.nextwave = 0;
        }

        if (CrossPlatformInputManager.GetButtonUp("Add_Damage"))
        {
            ui.upgradeSystem.SetActive(false);
            spawn.nextwave = 0;
        }

        if (CrossPlatformInputManager.GetButtonDown("Skip"))
        {
            ui.upgradeSystem.SetActive(false);
            spawn.nextwave = 0;
        }

    }
}
