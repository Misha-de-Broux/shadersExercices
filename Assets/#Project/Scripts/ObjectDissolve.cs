using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDissolve : MonoBehaviour {
    Material material;
    [SerializeField] float timeToDissolve = 1;

    // Start is called before the first frame update
    void Start() {
        material = GetComponent<Renderer>().material;
        if (timeToDissolve > 0) {
            Invoke("StartDissolve", 5f);
        }
    }

    private void StartDissolve() {
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve() {
        float dissolved = 0;
        while (dissolved < 1) {
            dissolved += Time.deltaTime / timeToDissolve;
            material.SetFloat("_Dissolved", dissolved);
            yield return null;
        }
    }
}
