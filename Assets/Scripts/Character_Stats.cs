using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Stats : MonoBehaviour
{
    public delegate void OnHealthChanged(float hp);
    public OnHealthChanged OnHealthChangedCallback;

    [SerializeField] private Stat maxHp;
    [SerializeField] private Stat strength;
    [SerializeField] private Stat attackRange;
    [SerializeField] private Stat attackDelay;

    [SerializeField] private float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp.GetValue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        OnHealthChangedCallback?.Invoke(currentHp);

        if(currentHp <= 0)
        {
            if (gameObject.tag == "Player")
            {
                PlayerDie();
            }
            else
            {
                Die();
            }
        }
    }

    private void ResetHp()
    {
        currentHp = maxHp.GetValue();
        OnHealthChangedCallback?.Invoke(currentHp);
    }

    private void Die()
    {
        //Drop loot etc.
        GameObject.Destroy(gameObject);
    }

    private void PlayerDie()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        ResetHp();
    }

    #region Get/Set
    public float GetStrength()
    {
        return strength.GetValue();
    }

    public float GetRange()
    {
        return attackRange.GetValue();
    }

    public float GetAttackDelay()
    {
        return attackDelay.GetValue();
    }

    public float GetCurrentHP()
    {
        return currentHp;
    }

    public float GetMaxHP()
    {
        return maxHp.GetValue();
    }
    #endregion
}
