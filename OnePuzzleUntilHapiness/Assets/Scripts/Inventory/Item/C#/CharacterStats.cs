using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHeath = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;


    private void Awake()
    {
        currentHealth = maxHeath;
    }

    public void TakeDamage(int _damage) 
    {
        _damage -= armor.getValue();
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);

        currentHealth -= _damage;

        Debug.Log(transform.name + " Take" + _damage + " of Damage !");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public virtual void Die() 
    {
        Debug.Log(transform.name + " Die!!!");
    }
}
