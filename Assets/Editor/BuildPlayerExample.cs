using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayerExample : MonoBehaviour
{
    [MenuItem("Build/Build Windows")]
    public static void MyBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };

        DateTime dt = DateTime.Now;
        string stamp = dt.ToString("yyyy-MM-dd-HH-mm-ss");
        buildPlayerOptions.locationPathName = $"Builds/{stamp}/{PlayerSettings.productName}.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.NoUniqueIdentifier;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}