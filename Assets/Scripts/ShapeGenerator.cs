using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator {

  ShapeSettings shapeSettings;

  public ShapeGenerator (ShapeSettings shapeSettings) {
    this.shapeSettings = shapeSettings;
  }

  public Vector3 CalculatePintOnPlanet (Vector3 pointOnUnitSphere) {

    return pointOnUnitSphere * shapeSettings.radius;

  }

}
