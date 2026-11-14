using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

internal static class CreateMvcMenu
{
    private const string MenuPath = "Assets/Tools/CreateMVC";
    private static readonly Regex IdentifierPrefix = new Regex(
        @"\A[_\p{L}\p{Nl}][\p{L}\p{Nl}\p{Mn}\p{Mc}\p{Nd}\p{Pc}]*\z");

    [MenuItem(MenuPath, true)]
    private static bool ValidateCreate()
    {
        return GetSelectedFolder() != null;
    }

    [MenuItem(MenuPath)]
    private static void Create()
    {
        var folder = GetSelectedFolder();
        if (folder == null)
            return;

        var prefix = Path.GetFileName(folder);
        if (!IdentifierPrefix.IsMatch(prefix))
        {
            Debug.LogWarning($"CreateMVC: フォルダ名「{prefix}」をC#のクラス名に使用できません。");
            return;
        }

        var outputDirectory = Path.Combine(Path.GetDirectoryName(Application.dataPath)!, folder);
        var templates = GetTemplates(prefix);
        var runtimeAssembly = typeof(BaseModel).Assembly;
        foreach (var (className, _) in templates)
        {
            var fileName = className + ".cs";
            var path = Path.Combine(outputDirectory, fileName);
            if (File.Exists(path) || Directory.Exists(path) || runtimeAssembly.GetType(className) != null)
            {
                Debug.LogWarning($"CreateMVC: 同名のファイルまたはクラス「{className}」が既に存在します。");
                return;
            }
        }

        var createdFiles = new List<string>(templates.Length);
        try
        {
            foreach (var (className, source) in templates)
            {
                var path = Path.Combine(outputDirectory, className + ".cs");
                using var stream = File.Open(path, FileMode.CreateNew, FileAccess.Write);
                createdFiles.Add(path);
                using var writer = new StreamWriter(stream);
                writer.Write(source);
            }
        }
        catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
        {
            Debug.LogError($"CreateMVC: ファイルを生成できませんでした。{exception.Message}");
            foreach (var path in createdFiles)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception cleanupException) when (cleanupException is IOException || cleanupException is UnauthorizedAccessException)
                {
                    Debug.LogError($"CreateMVC: 生成途中のファイルを削除できませんでした。{cleanupException.Message}");
                }
            }
            return;
        }

        AssetDatabase.Refresh();
    }

    private static string? GetSelectedFolder()
    {
        // The Project window's folder tree can select assets without setting activeObject.
        var guids = Selection.assetGUIDs;
        if (guids.Length != 1)
            return null;

        var path = AssetDatabase.GUIDToAssetPath(guids[0]);
        return (path == "Assets" || path.StartsWith("Assets/", StringComparison.Ordinal))
            && AssetDatabase.IsValidFolder(path) ? path : null;
    }

    private static (string ClassName, string Source)[] GetTemplates(string prefix)
    {
        return new[]
        {
            (prefix + "Scope", $@"using VContainer;

public class {prefix}Scope : SceneScope<{prefix}Model, {prefix}View, {prefix}ViewController>
{{
    protected override void Configure(IContainerBuilder builder)
    {{
        base.Configure(builder);
    }}
}}
"),
            (prefix + "Model", $@"public class {prefix}Model : BaseModel
{{
    public override void Init()
    {{
        
    }}
}}
"),
            (prefix + "View", $@"public class {prefix}View : BaseView
{{
}}
"),
            (prefix + "ViewController", $@"using UnityEngine;

[RequireComponent(typeof({prefix}View))]
[RequireComponent(typeof({prefix}Scope))]
public class {prefix}ViewController : ViewController<{prefix}Model, {prefix}View>
{{
    protected override void SubscribeEvents()
    {{
    }}
}}
")
        };
    }
}
