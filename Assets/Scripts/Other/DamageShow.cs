using System;
using TMPro;
using UnityEngine;

public class DamageShow : MonoBehaviour
{
    public TextMeshPro text;
    private float _damage = 0;
    private Color _color;
    private float _lifeTime = 0;
    private const float MaxLifeTime = 2.75F;
    private const float SpeedOfY = 15.5F;

    void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;

        transform.position += new Vector3((float) Math.Sin(SpeedOfY / 2), SpeedOfY) * Time.deltaTime;
    }

    public void Setup(float damage)
    {
        _damage = damage;
        text.text = ((int) damage).ToString();
    }
    
}