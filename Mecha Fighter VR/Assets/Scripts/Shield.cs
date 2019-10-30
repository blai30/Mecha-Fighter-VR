using Stats;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxDurability = 500f;
    [SerializeField] private float defense = 5f;

    private float currentDurability;

    private void Start()
    {
        // Shield is inactive at start
        ToggleShield(false);
        currentDurability = maxDurability;
    }

    private void Update()
    {
        currentDurability += Time.deltaTime;
    }

    public float GetDurabilityPercentage()
    {
        return 100f * (currentDurability / maxDurability);
    }

    public void TakeDamage(float damageDealt)
    {
        currentDurability -= Mathf.Max(1, damageDealt - defense);
    }

    public void ToggleShield(bool triggered)
    {
        GetComponent<Collider>().enabled = triggered;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(triggered);
        }
    }
}
