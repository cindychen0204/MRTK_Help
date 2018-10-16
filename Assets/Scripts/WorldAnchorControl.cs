    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.WSA;
    using UnityEngine.XR.WSA.Persistence;

    // オブジェクトのWorldAnchorコントロール
    public class WorldAnchorControl : MonoBehaviour
    {
     public bool SetOnAwake = false;
     public bool DestroyAnchorClear = false;// 再起動時に位置を復帰させる場合false
     private WorldAnchorStore anchorstore = null;
    void Start()
        {
            WorldAnchorStore.GetAsync((store)=> {
                anchorstore = store;
                string[] ids = anchorstore.GetAllIds();
               for (int i = 0; i<ids.Length; i++)
                {
                   if (ids[i] == gameObject.name)
                   {
                       anchorstore.Load(gameObject.name, gameObject);
                       break;
                   }
               }
                if (SetOnAwake) SetWorldAnchor();
            });
        }

        void OnDestroy()
        {
            if (DestroyAnchorClear) DeleteWorldAnchor();
        }

       public void SetWorldAnchor()
        {
            DeleteWorldAnchor();
            if (anchorstore != null)
            {
                WorldAnchor worldanchor = gameObject.AddComponent<WorldAnchor>();
               worldanchor.name = gameObject.name;
                if (worldanchor.isLocated) anchorstore.Save(worldanchor.name, worldanchor);
                else worldanchor.OnTrackingChanged += OnTrackingChanged;
            }
        }

       private void OnTrackingChanged(WorldAnchor self, bool located)
       {
            if (located)
            {
                anchorstore.Save(self.name, self);
               self.OnTrackingChanged -= OnTrackingChanged;
           }
       }

        public void DeleteWorldAnchor()
       {
            if (anchorstore != null)
        {            WorldAnchor worldanchor = gameObject.GetComponent<WorldAnchor>();
               if (worldanchor != null)
                {
                  anchorstore.Delete(worldanchor.name);
                    DestroyImmediate(worldanchor);
                }
            }
       }

       // WorldAnchorの全体削除
        public void AllClearWorldAnchor()
        {
           if (anchorstore != null) anchorstore.Clear();
        }
    }