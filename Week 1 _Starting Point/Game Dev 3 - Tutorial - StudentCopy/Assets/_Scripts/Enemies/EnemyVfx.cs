using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyVfx : MonoBehaviour
{
    /// <summary>
    /// This script only deals with the colour change when something is hit
    /// </summary>
    /// 

    SpriteRenderer sRVariable;                          //Variable to access the sprite renderer component

    public Color hitFlashColor;                         //Variable to store Color of the flash
    [SerializeField] private Color originalColor;        //Variable to store the original color
    public float hitFlashDuration;                      //Variable to store the duration of the flash

    // Start is called before the first frame update
    void Start()
    {
        sRVariable = GetComponent<SpriteRenderer>();
        originalColor = sRVariable.color;
    }


    public IEnumerator HitFlash()
    {
        sRVariable.color = hitFlashColor;
        yield return new WaitForSeconds(0.1f);
        sRVariable.DOColor(originalColor, hitFlashDuration);
    }
}
