using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material originalMaterial;
    public Material flashMaterial;

    private float flashTime = 0.08f;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void FlashStart()
    {
        meshRenderer.material = flashMaterial;
        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        meshRenderer.material = originalMaterial;
    }
}
