using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Player
{
    [RequireComponent(typeof(MeshFilter))]
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField] private LayerMask wallLayerMask;
        [SerializeField] private LayerMask objectsLayerMask;
        [SerializeField] private float fov = 90f;
        [SerializeField] float viewDistance = 5f;

        private Mesh mesh;

        private Vector3 origin;
        private float startingAngle;

        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            origin = Vector3.zero;
        }

        void LateUpdate()
        {
            int rayCount = 90;
            float angle = startingAngle;
            float angleIncrease = fov / rayCount;

            Vector3[] vertices = new Vector3[rayCount + 1 + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount * 3];

            vertices[0] = origin;

            int vertexIndex = 1;
            int triangleIndex = 0;

            for (int i = 0; i <= rayCount; i++)
            {
                Vector3 vertex;
                RaycastHit2D raycastHitWall =
                    Physics2D.Raycast(origin, MathUtils.GetVectorFromAngle(angle), viewDistance, wallLayerMask);
                if (raycastHitWall.collider == null)
                {
                    // not hit
                    vertex = origin + MathUtils.GetVectorFromAngle(angle) * viewDistance;
                }
                else
                {
                    // hit object
                    vertex = raycastHitWall.point;
                }
                /*RaycastHit2D raycastHitObject =
                    Physics2D.Raycast(origin, MathUtils.GetVectorFromAngle(angle), viewDistance - 0.5f, objectsLayerMask);
                if (raycastHitObject.collider != null)
                {

                    vertex = origin + MathUtils.GetVectorFromAngle(angle) * viewDistance;

                    raycastHitObject.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }*/

                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                vertexIndex++;
                angle -= angleIncrease;
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
        }

        public void SetOrigin(Vector3 origin)
        {
            this.origin = origin;
        }

        public void SetAimDirection(Vector3 direction)
        {
            startingAngle = MathUtils.GetAngleFromVectorFloat(direction) + fov / 2f;
        }
    }
}
