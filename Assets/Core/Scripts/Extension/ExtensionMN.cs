using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Extension
{
    public static class ExtensionMN
    {
        public static void DestroyChilds(this Transform transform)
        {
            foreach (Transform trans in transform)
            {
                Object.Destroy(trans.gameObject);
            }
        }
    }
}