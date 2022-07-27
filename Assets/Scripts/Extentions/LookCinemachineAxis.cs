using Cinemachine;
using UnityEngine;

namespace Extentions
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("")]
    public class LookCinemachineAxis : CinemachineExtension
    {
        [Tooltip("Lock the camera's X position to this value")]
        public float m_xPosition = 0f;

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltatime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.x = m_xPosition;
                state.RawPosition = pos;
            }
        }
    }
}