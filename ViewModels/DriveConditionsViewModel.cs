using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Green_Light.ViewModels
{
    public class DriveConditionsViewModel : INotifyPropertyChanged
    {
        readonly IList<DriveCondition> lstSource;
        DriveCondition cdnSelectedDriveConditionA;
        int intSelectionCount = 1;

        public ObservableCollection<DriveCondition> clnDriveConditions { get; private set; }

        public IList<DriveCondition> lstEmptyDriveConditions { get; private set; }

        public DriveCondition cdnSelectedDriveConditionB
        {
            get
            {
                return cdnSelectedDriveConditionA;
            }
            set
            {
                if(cdnSelectedDriveConditionA != value)
                {
                    cdnSelectedDriveConditionA = value;
                }
            }
        }

        ObservableCollection<object> clnSelectedDriveConditionsA;

        public ObservableCollection<object> clnSelectedDriveConditionsB
        {
            get
            {
                return clnSelectedDriveConditionsA;
            }
            set
            {
                if(clnSelectedDriveConditionsA != value)
                {
                    clnSelectedDriveConditionsA = value;
                }
            }
        }

        public string strSelectedDriveConditionMessage { get; private set; }

        public ICommand DriveConditionSelectionChangedCommand => new Command(DriveConditionSelectionChanged);

        public DriveConditionsViewModel()
        {
            lstSource = new List<DriveCondition>();
            CreateDriveConditionCollection();

            cdnSelectedDriveConditionA = clnDriveConditions.Skip(3).FirstOrDefault();
            DriveConditionSelectionChanged();

            clnSelectedDriveConditionsB = new ObservableCollection<object>()
            {
                clnDriveConditions[1],clnDriveConditions[2],clnDriveConditions[4]
            };
        }

        void CreateDriveConditionCollection()
        {
            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Test",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            clnDriveConditions = new ObservableCollection<DriveCondition>(lstSource);
        }

        void DriveConditionSelectionChanged()
        {
            strSelectedDriveConditionMessage = $"Selection {intSelectionCount} : {cdnSelectedDriveConditionB.strName}";
            OnPropertyChanged("SelectedConditionMessage");
            intSelectionCount++;
        }

        void FilterItems(string filter)
        {
            var filteredItems = lstSource.Where(condition => condition.strCategory.ToLower().Contains(filter.ToLower()));
            foreach (var condition in lstSource)
            {
                if (!filteredItems.Contains(condition))
                {
                    clnDriveConditions.Remove(condition);
                }
                else
                {
                    if (!clnDriveConditions.Contains(condition))
                    {
                        clnDriveConditions.Add(condition);
                    }
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string strPropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
        #endregion


    }
}
