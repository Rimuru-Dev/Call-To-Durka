using UnityEngine;
using System.Diagnostics.CodeAnalysis;

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

        public void PickUpPhone() =>
            callController.PickUpPhone();

        public void HangUpPhone() =>
            callController.HangUpPhone();
    }
}