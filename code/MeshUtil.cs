using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using System.IO;

namespace Reallusion.Import
{
    public static class MeshUtil
    {
        public const string INVERTED_FOLDER_NAME = "Inverted Meshes";
        public const string PRUNED_FOLDER_NAME = "Pruned Meshes";

        [MenuItem("CC3/Tools/Reverse Triangle Order", priority = 100)]
        private static void DoReverse()
        {
            ReverseTriangleOrder(Selection.activeObject);
        }

        [MenuItem("CC3/Tools/Prune Blend Shapes", priority = 101)]
        private static void DoPrune()
        {
            PruneBlendShapes(Selection.activeObject);
        }

        [MenuItem("CC3/Tools/Open or Close Character Mouth", priority = 201)]
        private static void DoOpenCloseMouth()
        {
            CharacterOpenCloseMouth(Selection.activeObject);
        }

        [MenuItem("CC3/Tools/Open or Close Character Eyes", priority = 202)]
        private static void DoOpenCloseEyes()
        {
            CharacterOpenCloseEyes(Selection.activeObject);
        }

        public static Mesh GetMeshFromSelected(Object obj)
        {
            if (obj.GetType() == typeof(Mesh))
            {
                Mesh m = (Mesh)obj;
                if (m) return m;
            }

            if (obj.GetType() == typeof(GameObject))
            {
                GameObject go = (GameObject)obj;
                if (go)
                {
                    Mesh m = go.GetComponent<Mesh>();
                    if (m) return m;
                    
                    MeshFilter mf = go.GetComponent<MeshFilter>();
                    if (mf)
                    {
                        return mf.mesh;
                    }
                    
                    SkinnedMeshRenderer smr = go.GetComponent<SkinnedMeshRenderer>();
                    if (smr)
                    {
                        return smr.sharedMesh;
                    }
                }
            }

            return null;
        }

        public static bool ReplaceMesh(Object obj, Mesh mesh)
        {
            if (obj.GetType() == typeof(GameObject))
            {
                GameObject go = (GameObject)obj;
                if (go)
                {
                    MeshFilter mf = go.GetComponent<MeshFilter>();
                    if (mf)
                    {
                        mf.mesh = mesh;
                        return true;
                    }

                    SkinnedMeshRenderer smr = go.GetComponent<SkinnedMeshRenderer>();
                    if (smr)
                    {
                        smr.sharedMesh = mesh;
                        return true;
                    }
                }
            }

            return false;
        }

        // Copies the source mesh from the obj and removes blend shapes with little to no influence on the vertices.
        public static void PruneBlendShapes(Object obj)
        {
            if (!obj) return;

            GameObject sceneRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
            GameObject asset = PrefabUtility.GetCorrespondingObjectFromSource(sceneRoot);
            Object srcObj = PrefabUtility.GetCorrespondingObjectFromSource(obj);
            Mesh srcMesh = GetMeshFromSelected(srcObj);
            string path = AssetDatabase.GetAssetPath(asset);

            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning("Object: " + obj.name + " has no source Prefab Asset.");
                path = Path.Combine("Assets", "dummy.prefab");
            }

            if (!srcMesh)
            {
                Debug.LogError("No mesh found in selected object.");
                return;
            }

            string folder = Path.GetDirectoryName(path);
            string meshFolder = Path.Combine(folder, PRUNED_FOLDER_NAME);

            Mesh dstMesh = new Mesh();
            dstMesh.vertices = srcMesh.vertices;
            dstMesh.uv = srcMesh.uv;
            dstMesh.uv2 = srcMesh.uv2;
            dstMesh.normals = srcMesh.normals;
            dstMesh.colors = srcMesh.colors;
            dstMesh.boneWeights = srcMesh.boneWeights;
            dstMesh.bindposes = srcMesh.bindposes;
            dstMesh.bounds = srcMesh.bounds;
            dstMesh.tangents = srcMesh.tangents;
            dstMesh.triangles = srcMesh.triangles;
            dstMesh.subMeshCount = srcMesh.subMeshCount;

            for (int s = 0; s < srcMesh.subMeshCount; s++)
            {
                SubMeshDescriptor submesh = srcMesh.GetSubMesh(s);
                dstMesh.SetSubMesh(s, submesh);
            }

            // copy any blendshapes across
            if (srcMesh.blendShapeCount > 0)
            {
                Vector3[] deltaVertices = new Vector3[srcMesh.vertexCount];
                Vector3[] deltaNormals = new Vector3[srcMesh.vertexCount];
                Vector3[] deltaTangents = new Vector3[srcMesh.vertexCount];

                for (int i = 0; i < srcMesh.blendShapeCount; i++)
                {
                    string name = srcMesh.GetBlendShapeName(i);

                    int frameCount = srcMesh.GetBlendShapeFrameCount(i);
                    for (int f = 0; f < frameCount; f++)
                    {
                        float frameWeight = srcMesh.GetBlendShapeFrameWeight(i, f);
                        srcMesh.GetBlendShapeFrameVertices(i, f, deltaVertices, deltaNormals, deltaTangents);

                        Vector3 deltaSum = Vector3.zero;
                        for (int d = 0; d < srcMesh.vertexCount; d++) deltaSum += deltaVertices[d];
                        Debug.Log(name + ": deltaSum = " + deltaSum.ToString());
                        
                        if (deltaSum.magnitude > 0.01f)
                            dstMesh.AddBlendShapeFrame(name, frameWeight, deltaVertices, deltaNormals, deltaTangents);
                    }
                }
            }

            // Save the mesh asset.
            if (!AssetDatabase.IsValidFolder(meshFolder))
                AssetDatabase.CreateFolder(folder, PRUNED_FOLDER_NAME);
            string meshPath = Path.Combine(meshFolder, srcObj.name + ".mesh");
            AssetDatabase.CreateAsset(dstMesh, meshPath);

            if (obj.GetType() == typeof(GameObject))
            {
                GameObject go = (GameObject)obj;
                if (go)
                {
                    Mesh createdMesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);

                    if (!ReplaceMesh(obj, createdMesh))
                    {
                        Debug.LogError("Unable to set mesh in selected object!");
                    }
                }
            }
        }

        // Copies the source mesh from the object and reverses the order of triangles.
        // (this is for hair meshes that look too 'inside out')
        public static void ReverseTriangleOrder(Object obj)
        {
            if (!obj) return;

            GameObject sceneRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
            GameObject asset = PrefabUtility.GetCorrespondingObjectFromSource(sceneRoot);
            Object srcObj = PrefabUtility.GetCorrespondingObjectFromSource(obj);
            Mesh srcMesh = GetMeshFromSelected(srcObj);
            string path = AssetDatabase.GetAssetPath(asset);

            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning("Object: " + obj.name + " has no source Prefab Asset.");
                path = Path.Combine("Assets", "dummy.prefab");
            }

            if (!srcMesh)
            {
                Debug.LogError("No mesh found in selected object.");
                return;
            }

            string folder = Path.GetDirectoryName(path);
            string meshFolder = Path.Combine(folder, INVERTED_FOLDER_NAME);

            Mesh dstMesh = new Mesh();
            dstMesh.vertices = srcMesh.vertices;
            dstMesh.uv = srcMesh.uv;
            dstMesh.uv2 = srcMesh.uv2;
            dstMesh.normals = srcMesh.normals;
            dstMesh.colors = srcMesh.colors;
            dstMesh.boneWeights = srcMesh.boneWeights;
            dstMesh.bindposes = srcMesh.bindposes;
            dstMesh.bounds = srcMesh.bounds;
            dstMesh.tangents = srcMesh.tangents;            

            int[] reversed = new int[srcMesh.triangles.Length];
            int[] forward = srcMesh.triangles;

            // first pass: reverse the triangle order for each submesh
            for (int s = 0; s < srcMesh.subMeshCount; s++)
            {
                SubMeshDescriptor submesh = srcMesh.GetSubMesh(s);
                int start = submesh.indexStart;
                int end = start + submesh.indexCount;
                int j = end - 3;                
                for (int i = start; i < end; i += 3)
                {
                    reversed[j] = forward[i];
                    reversed[j + 1] = forward[i + 1];
                    reversed[j + 2] = forward[i + 2];
                    j -= 3;
                }
            }

            dstMesh.triangles = reversed;
            dstMesh.subMeshCount = srcMesh.subMeshCount;

            // second pass: copy sub-mesh data (vertex and triangle data must be present for this)
            for (int s = 0; s < srcMesh.subMeshCount; s++)
            {
                SubMeshDescriptor submesh = srcMesh.GetSubMesh(s);
                dstMesh.SetSubMesh(s, submesh);
            }

            // copy any blendshapes across
            if (srcMesh.blendShapeCount > 0)
            {
                Vector3[] deltaVertices = new Vector3[srcMesh.vertexCount];
                Vector3[] deltaNormals = new Vector3[srcMesh.vertexCount];
                Vector3[] deltaTangents = new Vector3[srcMesh.vertexCount];

                for (int i = 0; i < srcMesh.blendShapeCount; i++)
                {
                    string name = srcMesh.GetBlendShapeName(i);

                    int frameCount = srcMesh.GetBlendShapeFrameCount(i);
                    for (int f = 0; f < frameCount; f++)
                    {
                        float frameWeight = srcMesh.GetBlendShapeFrameWeight(i, f);
                        srcMesh.GetBlendShapeFrameVertices(i, f, deltaVertices, deltaNormals, deltaTangents);
                        dstMesh.AddBlendShapeFrame(name, frameWeight, deltaVertices, deltaNormals, deltaTangents);                        
                    }
                }
            }

            // Save the mesh asset.
            if (!AssetDatabase.IsValidFolder(meshFolder))
                AssetDatabase.CreateFolder(folder, INVERTED_FOLDER_NAME);
            string meshPath = Path.Combine(meshFolder, srcObj.name + ".mesh");
            AssetDatabase.CreateAsset(dstMesh, meshPath);

            if (obj.GetType() == typeof(GameObject))
            {
                GameObject go = (GameObject)obj;
                if (go)
                {
                    Mesh createdMesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);

                    if (!ReplaceMesh(obj, createdMesh))
                    {
                        Debug.LogError("Unable to set mesh in selected object!");
                    }
                }
            }
        }

        public static GameObject FindCharacterBone(GameObject gameObject, string name)
        {
            if (gameObject)
            {
                if (gameObject.name.EndsWith(name, System.StringComparison.InvariantCultureIgnoreCase))
                    return gameObject;

                int children = gameObject.transform.childCount;
                for (int i = 0; i < children; i++)
                {
                    GameObject found = FindCharacterBone(gameObject.transform.GetChild(i).gameObject, name);
                    if (found) return found;
                }
            }

            return null;
        }

        public static void CharacterOpenCloseMouth(Object obj)
        {
            GameObject root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);

            if (root)
            {
                bool isOpen;

                // find the jaw bone and change it's rotation
                GameObject jawBone = FindCharacterBone(root, "CC_Base_JawRoot");
                if (!jawBone) jawBone = FindCharacterBone(root, "JawRoot");
                if (jawBone)
                {
                    Transform jaw = jawBone.transform;
                    Quaternion rotation = jaw.localRotation;
                    Vector3 euler = rotation.eulerAngles;
                    if (euler.z < 91f || euler.z > 269f)
                    {
                        euler.z = -115f;
                        isOpen = true;
                    }
                    else
                    {
                        euler.z = -90f;
                        isOpen = false;
                    }
                    rotation.eulerAngles = euler;
                    jaw.localRotation = rotation;

                    const string shapeName = "Mouth_Open";

                    // go through all the mesh object with blendshapes and set the "Mouth_Open" blend shape
                    for (int i = 0; i < root.transform.childCount; i++)
                    {
                        GameObject child = root.transform.GetChild(i).gameObject;
                        SkinnedMeshRenderer renderer = child.GetComponent<SkinnedMeshRenderer>();
                        if (renderer)
                        {
                            Mesh mesh = renderer.sharedMesh;
                            if (mesh.blendShapeCount > 0)
                            {
                                int shapeIndex = mesh.GetBlendShapeIndex(shapeName);
                                if (shapeIndex >= 0)
                                {
                                    renderer.SetBlendShapeWeight(shapeIndex, isOpen ? 60f : 0f);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void CharacterOpenCloseEyes(Object obj)
        {
            GameObject root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);

            if (root)
            {
                bool isOpen;

                const string shapeNameL = "Eye_Blink_L";
                const string shapeNameR = "Eye_Blink_R";

                // go through all the mesh object with blendshapes and set the "Mouth_Open" blend shape
                for (int i = 0; i < root.transform.childCount; i++)
                {
                    GameObject child = root.transform.GetChild(i).gameObject;
                    SkinnedMeshRenderer renderer = child.GetComponent<SkinnedMeshRenderer>();
                    if (renderer)
                    {
                        Mesh mesh = renderer.sharedMesh;
                        if (mesh.blendShapeCount > 0)
                        {
                            int shapeIndexL = mesh.GetBlendShapeIndex(shapeNameL);
                            int shapeIndexR = mesh.GetBlendShapeIndex(shapeNameR);
                            if (shapeIndexL >= 0 && shapeIndexR >= 0)
                            {
                                if (renderer.GetBlendShapeWeight(shapeIndexL) > 0f) isOpen = false;
                                else isOpen = true;

                                renderer.SetBlendShapeWeight(shapeIndexL, isOpen ? 100f : 0f);
                                renderer.SetBlendShapeWeight(shapeIndexR, isOpen ? 100f : 0f);
                            }
                        }
                    }
                }
            }
        }
    }
}
