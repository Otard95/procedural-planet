using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject {

  public float radius = 1;
  
  void OnValidate () {
    if (radius <= 0.5) {
      radius = 0.5f;
    }
  }

}
