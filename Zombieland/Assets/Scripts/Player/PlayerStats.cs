using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //current stats with all modifiers
    private int current_Health;
    private int current_Armour;
    private int current_Attack;

    //Base stats when no modifiers aplicated
    private int BASE_HEALTH = 100;
    private int BASE_ARMOUR = 0;
    private int BASE_ATTACK = 10;

    //UI elements
    public Text txt_Health;
    public Text txt_Armour;
    public Text txt_Attack;
    public Image img_healthFill;

    public static PlayerStats instance;//singleton

    private void Start()
    {
        #region Singleton
        if (instance != null) { Debug.Log("Mais de 1 playerStats!!!"); return; }

        instance = this;
        #endregion

        current_Health = BASE_HEALTH;
        current_Armour = BASE_ARMOUR;
        current_Attack = BASE_ATTACK;
    }

    private void Update()
    {
        UpdateUI();
    }


    public void AddModifiers(int _health,int _armour,int _attack) 
    {
        current_Health += _health;
        current_Armour += _armour;
        current_Attack += _attack;
    }

    public void RemoveModifiers(int _health, int _armour, int _attack) 
    {
        current_Health -= _health;
        current_Armour -= _armour;
        current_Attack -= _attack;
    }


    public void UpdateUI() 
    {
        if (txt_Armour.IsActive()) //atualiza o texto se o elemento de UI estiver ativo
        {
            txt_Health.text = "Health: " + current_Health.ToString();
            txt_Armour.text = "Armadura: " + current_Armour.ToString();
            txt_Attack.text = "Ataque: " + current_Attack.ToString();
        }
        if (img_healthFill.IsActive()) 
        {
            img_healthFill.fillAmount = (current_Health * 100) / BASE_HEALTH;
        }

       
    }
}
