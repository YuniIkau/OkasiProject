using System.Reflection;
using UnityEditor;

public static class ConsoleClear
{
    [MenuItem("Tools/Clear Console %#v")]
    private static void Clear()
    {
        var type = Assembly
            .GetAssembly(typeof(SceneView))
#if UNITY_2017_1_OR_NEWER
            .GetType("UnityEditor.LogEntries")
#else
            .GetType( "UnityEditorInternal.LogEntries" )
#endif
        ;
        var method = type.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
        method.Invoke(null, null);
    }
}