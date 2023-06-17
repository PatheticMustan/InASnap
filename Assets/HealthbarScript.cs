using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthbarScript : MonoBehaviour {
    public static HealthbarScript Instance;
    
    public float damage;
    public float health;
    public float maxHealth;

    public UnityEvent death;

    [SerializeField] private RectTransform fullBar;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform damageBar;
    private float initialWidth;

    void Awake() {
        initialWidth = fullBar.sizeDelta.x;
        maxHealth = health;

        Instance = this;
    }

    void Update() {
        if (damage != 0) {
            float damageAdded = Mathf.Lerp(damage, 0, 0.1f) * Time.deltaTime;
            damage -= damageAdded;
            SetHealth(health - damageAdded);
            //healthBar.sizeDelta = new Vector2(initialWidth * ((health-damage) / maxHealth), healthBar.sizeDelta.y);
        }

        // if it's really small, just add the rest
        if (damage <= 1) AddDamage(0);

        if ((health-damage) <= 0.05f || health < 0) {
            // call any game-end functions here
            //Debug.Log("death is only a temporary hinderance to my unending journey to performing The Final Snap");

            ResetHealth();
            death.Invoke();

            // you can set the bar color to a different color, like purple! or play a death animation
            // purple
            // death animation/sprite
            //Time.timeScale = 0;
        }
    }

    public void ResetHealth() {
        health = maxHealth;
        damage = 0;
        SetHealth(health);
    }

    public void AddDamage(float damage) {
        SetHealth(health - this.damage);
        this.damage = damage;
    }
    
    // sets the HP and updates the healthBar size
    public void SetHealth(float health) {
        this.health = Mathf.Max(health, 0);
        damageBar.sizeDelta = new Vector2(initialWidth * (health / maxHealth), damageBar.sizeDelta.y);
        healthBar.sizeDelta = new Vector2(initialWidth * ((health - damage) / maxHealth), healthBar.sizeDelta.y);
    }
}