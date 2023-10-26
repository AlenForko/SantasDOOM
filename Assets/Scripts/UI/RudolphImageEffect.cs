using UnityEngine;

namespace UI
{
    public class RudolphImageEffect : MonoBehaviour
    {
        public float amp;
        public float freq;
    
        private Vector3 _initPos;
        private void Start()
        {
            _initPos = transform.position;
        }

        void Update()
        {
            transform.position = new Vector3(_initPos.x, Mathf.Sin(Time.time * freq) * amp, 0);
        }
    }
}
