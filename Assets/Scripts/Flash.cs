using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used for a flashing red effect on doors that cannot be opened
public class Flash : MonoBehaviour
{
    SpriteRenderer warningRenderer;
    private float offset = 0.01f;
    
    // Start is called before the first frame update
    private void Start()
    {
        warningRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WarningFlash());
    }

    private IEnumerator WarningFlash()
    {
        while (true)
        {
            for (int i = 30; i < 50; i++)
            {
                warningRenderer.color = new Color(i * offset, 0f, 0f, 0.5f);
                yield return new WaitForSeconds(0.05f);
            }
            for (int i = 50; i > 30; i--)
            {
                warningRenderer.color = new Color(i * offset, 0f, 0f, 0.5f);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
