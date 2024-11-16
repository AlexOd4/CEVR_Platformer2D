using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int life;
    public int Life { get { return life; } }

    private int _maxLife;
    public int MaxLife { get { return _maxLife; } }

    public void Awake()
    {
        _maxLife = life;
    }

    public void Heal(int healPoints)
    {
        life += healPoints;
        Mathf.Clamp(life, 0, _maxLife);
    }
    
    public void Hit(int hitDamage = 0)
    {
        life -= hitDamage;
        if (isDead() && !this.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);

        else if (isDead() && this.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<PlayerMovementController>().enabled = false;
            this.gameObject.GetComponent<PlayerInputHandler>().enabled = false;
        }
        
        if (this.gameObject.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();
            StartCoroutine(PlayerHitRenderer(playerSprite, 6));

        }
    }

    /// <summary>
    /// makes the animation of been hitted
    /// </summary>
    /// <param name="sprite">The sprite who is going to be changed</param>
    /// <param name="flahsRepeat"> how many times the sprite flashes</param>
    /// <returns></returns>
    private IEnumerator PlayerHitRenderer(SpriteRenderer sprite, int flahsRepeat)
    {
        for (int i = 0; i < flahsRepeat; i++)
        {
            sprite.color = Color.red;
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        sprite.color = Color.white;


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
