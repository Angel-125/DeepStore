using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using KSP.Localization;
using KSP.UI.Screens;
using WildBlueCore;

/*
Source code copyright 2021, by Michael Billard (Angel-125)
License: GPLV3

Wild Blue Industries is trademarked by Michael Billard and may be used for non-commercial purposes. All other rights reserved.
Note that Wild Blue Industries is a ficticious entity 
created for entertainment purposes. It is in no way meant to represent a real entity.
Any similarity to a real entity is purely coincidental.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DeepStore.PartModules.Resources
{
    public class ModuleDeepStore: BasePartModule
    {
        #region Lifecycle overrides
        public override void OnStart(StartState state)
        {
            base.OnStart(state);

            GameEvents.onVesselPartCountChanged.Add(onVesselPartCountChanged);
            GameEvents.onPartResourceFullNonempty.Add(onPartResourceFullNonempty);
            GameEvents.onPartResourceEmptyNonempty.Add(onPartResourceEmptyNonempty);
            GameEvents.onPartResourceNonemptyEmpty.Add(onPartResourceNonemptyEmpty);
            GameEvents.onPartResourceEmptyFull.Add(onPartResourceEmptyFull);
            GameEvents.onPartResourceFullEmpty.Add(onPartResourceFullEmpty);
            GameEvents.onPartPriorityChanged.Add(onPartPriorityChanged);
        }

        public override string GetInfo()
        {
            return Localizer.Format("#LOC_WILDBLUECORE_fuelPumpModuleInfo");
        }
        #endregion

        #region GameEvents
        private void onVesselPartCountChanged(Vessel changedVessel)
        {
            if (changedVessel != part.vessel)
                return;
        }

        private void onPartPriorityChanged(Part changedPart)
        {
        }

        #region Events that wait for host part to no longer be empty
        private void onPartResourceEmptyNonempty(PartResource resource)
        {
        }

        private void onPartResourceEmptyFull(PartResource resource)
        {
            onPartResourceEmptyNonempty(resource);
        }
        #endregion

        #region Events that wait for destination parts to have room
        private void onPartResourceFullNonempty(PartResource resource)
        {
        }

        private void onPartResourceNonemptyEmpty(PartResource resource)
        {
            onPartResourceFullNonempty(resource);
        }

        private void onPartResourceFullEmpty(PartResource resource)
        {
            onPartResourceFullNonempty(resource);
        }
        #endregion
        #endregion
    }
}
