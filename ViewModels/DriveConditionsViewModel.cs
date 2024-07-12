using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;
using Green_Light.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Green_Light.ViewModels
{
    class DriveConditionsViewModel
    {
        readonly IList<DriveCondition> lstSource;
        
        public DriveConditionsViewModel


        void CreateDriveConditionCollection()
        {
            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png"
            });
        }

        void DriveConditionSelectionChanged()
        {

        }

    }
}
