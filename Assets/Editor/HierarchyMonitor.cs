using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoadAttribute]
public static class HierarchyMonitor
{
    static HierarchyMonitor()
    {
        EditorApplication.hierarchyChanged += CollisionManager.SetColliders;
    }

}
