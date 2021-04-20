using UnityEngine;

namespace Parent
{
    public interface IMoveable
    {

        public void Move(float x);
        public void Move(Vector3 vector3);
    }
}