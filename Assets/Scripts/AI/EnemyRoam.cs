using UnityEngine;

namespace AI
{
    public class EnemyRoam : MonoBehaviour
    {
        public float speed = 10f;
        private float _waitTime;
        public float startWaitTime = 3f;

        public Vector3 minValues;
        public Vector3 maxValues;
        private Vector3 _newPos;

        public bool isRoaming;

        private void Start()
        {
            _waitTime = startWaitTime;

            Vector3 localPosition = transform.position;
            minValues += localPosition;
            maxValues += localPosition;

            //Sets a random new position.
            _newPos = new Vector3(Random.Range(minValues.x, maxValues.x), transform.position.y, Random.Range(minValues.z, maxValues.z));
            transform.LookAt(_newPos);
        }

        private void FixedUpdate()
        {
            if (!isRoaming) return;
            //Moves enemy towards the new position.
            transform.position = Vector3.MoveTowards(transform.position, _newPos, speed * Time.deltaTime);
            
            //Checks for distance before executing new position. 
            if (!(Vector3.Distance(transform.position, _newPos) < 0.2f)) return;
            if (_waitTime <= 0)
            {
                _newPos = new Vector3(Random.Range(minValues.x, maxValues.x), transform.position.y,
                    Random.Range(minValues.z, maxValues.z));
                transform.LookAt(_newPos);

                //Resets time.
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
