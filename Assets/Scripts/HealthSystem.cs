using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int life;
    private int maxLife;

    public void Awake()
    {
        maxLife = life;
    }

    public void Heal(int healPoints)
    {
        life += healPoints;
        Mathf.Clamp(life, 0, maxLife);
    }
    
    public void Hit(int hitDamage = 0)
    {
        life -= hitDamage;
        if (isDead() && !this.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);

        else if (isDead() && this.gameObject.CompareTag("Player"))
        {
            print("Me he muelto");

            this.gameObject.GetComponent<PlayerMovementController>().enabled = false;
            this.gameObject.GetComponent<PlayerInputHandler>().enabled = false;

        }
        //TODO Hacer el sistema de perder y que te lleve al menú de vuelta (Llamaría a una función de un GameManager ó MenuManager)
    }

    public void Kill() 
    {
        life = 0;
        Hit();
    }

    private bool isDead()
    {
        if (life <= 0) return true;
        return false;
    }

}
