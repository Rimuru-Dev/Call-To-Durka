using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace RimuruDev.Intenal.Codebase.Runtime.EntryPoint
{
    [SelectionBase]
    [DisallowMultipleComponent]
    [SuppressMessage("ReSharper", "ParameterHidesMember")]
    public sealed class CallViewController : MonoBehaviour
    {
        private CallController callController;

        public void Initialize(CallController callController) =>
            this.callController = callController;

        public void StartCall(int callID) =>
            callController.StartCall(callID);

        public void PickUpPhone(int callID) =>
            callController.PickUpPhone(callID);

        public void HangUpPhone(int callID) =>
            callController.HangUpPhone(callID);
    }
}