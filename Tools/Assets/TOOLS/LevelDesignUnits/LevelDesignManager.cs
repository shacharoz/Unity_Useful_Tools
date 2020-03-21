using System.Collections.Generic;
using UnityEngine;

namespace WizardOzTools
{
    public class LevelDesignManager : MonoBehaviour
    {   
        [System.Serializable]
        public class LevelSpawnProperties
        {
            public string description;
            public GameObject levelPrefab;
            public float Length;
        }

        public List<LevelSpawnProperties> LevelDesignProperties;

        private int index;
        private float lastPlacedPosition;

        private void Start()
        {
            index = -1;
            lastPlacedPosition = 0;
            LoadNextSection();
        }

        public void LoadNextSection()
        {
            index++;
            if (index > LevelDesignProperties.Count)
            {
                Debug.Log("Game over");
                return;
            }

            Instantiate(LevelDesignProperties[index].levelPrefab,
                        new Vector3(0, 0, lastPlacedPosition),
                        Quaternion.identity);

            lastPlacedPosition += LevelDesignProperties[index].Length;
        }
    }
}