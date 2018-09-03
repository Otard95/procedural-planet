using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor {

  Planet planet;
  Editor shapeEditor;
  Editor colorEditor;

  public override void OnInspectorGUI () {

    using (var check = new EditorGUI.ChangeCheckScope()) {
      base.OnInspectorGUI();
      if (check.changed && planet.autoUpdate) {
        planet.GeneratePlanet();
      }
    }

    if (GUILayout.Button("Generate Planet")) {
      planet.GeneratePlanet();
    }

    DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
    DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout, ref colorEditor);

  }

  void DrawSettingsEditor (Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor) {
    
    foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

    using (var check = new EditorGUI.ChangeCheckScope()) {
      
      if (foldout) {
        editor.OnInspectorGUI();
      }
      
      if (check.changed && planet.autoUpdate) {
        onSettingsUpdated();
      }
      
    }
  }

  void OnEnable () {
    planet = (Planet) target;
    shapeEditor = CreateEditor(planet.shapeSettings);
    colorEditor = CreateEditor(planet.colorSettings);
  }

}
