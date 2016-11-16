#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using System.Diagnostics;	

public class PostBuildProcess {
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        RenameFileAndCleanup(pathToBuiltProject);
    }

    public static void RenameFileAndCleanup (string path)
    {
        // Remove the xml file that is made
        string xmlFilePath = path + ".xml";
        FileUtil.DeleteFileOrDirectory(xmlFilePath);

        // Change .cci file ending to .3ds
        string newPath = path.Substring(0, path.Length - 4) + ".3ds";
        FileUtil.MoveFileOrDirectory(path, newPath);
    }

    public static void ConvertOutput ()
    {
        Process p = new Process();
        p.StartInfo.FileName = "python";
        p.StartInfo.Arguments = "resize_reference_sprites.py";
        // Pipe the output to itself - we will catch this later
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        // Where the script lives
        p.StartInfo.WorkingDirectory = Application.dataPath + "/SpriteCollections/";
        p.StartInfo.UseShellExecute = false;

        p.Start();
        // Read the output - this will show is a single entry in the console - you could get  fancy and make it log for each line - but thats not why we're here
        UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
    }
}
#endif