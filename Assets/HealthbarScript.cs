using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarScript : MonoBehaviour {
    public float damage;
    public float health;
    public float maxHealth;


    [SerializeField] private RectTransform fullBar;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform damageBar;
    private float initialWidth;

    void Start() {
        initialWidth = fullBar.sizeDelta.x;
        maxHealth = health;
    }

    void Update() {
        if (damage != 0) {
            float damageAdded = Mathf.Lerp(damage, 0, 0.1f) * Time.deltaTime;
            damage -= damageAdded;
            SetHealth(health - damageAdded);
            healthBar.sizeDelta = new Vector2(initialWidth * ((health-damage) / maxHealth), healthBar.sizeDelta.y);
        }

        if (damage > health || health == 0) {
            // call any game-end functions here
            Debug.Log("death is only a temporary hinderance to my unending journey to performing The Final Snap");

            // you can set the bar color to a different color, like purple! or play a death animation
            // purple
            // death animation/sprite
        }
    }


    void AddDamage(float damage) {
        SetHealth(health - this.damage);
        this.damage = damage;
    }
    
    // sets the HP and updates the healthBar size
    void SetHealth(float health) {
        this.health = Mathf.Max(health, 0);
        damageBar.sizeDelta = new Vector2(initialWidth * (health / maxHealth), damageBar.sizeDelta.y);
    }
}