using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{

    public int health = 100;
    public Image damageBackground;

    void Update()
    {
        if (health < 0) {
            health = 0;
        }

        Color color = damageBackground.color;
        color.a -= Time.deltaTime;
        damageBackground.color = color;
    }

    public int getHealth() {
        return health;
    }

    public void damage(int damage, DamageCause cause) {

        this.health -= damage;

        if (cause == DamageCause.FALL)
        {
            Debug.Log("Вы упали и потеряли " + damage + " здоровья");
            Color color = damageBackground.color;
            color.a = 0.3F;
            damageBackground.color = color;
        }
        else {
            Color color = damageBackground.color;
            color.a = 0.2F;
            damageBackground.color = color;
        }

    }

    public enum DamageCause {

        PLAYER_ATTACK,
        FALL,
        FIRE,
        OTHER

    }

}
