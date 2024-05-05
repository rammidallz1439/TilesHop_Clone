using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Tile : MonoBehaviour
    {
        private void Update()
        {
            transform.position -= Vector3.back;
        }
    }
}

