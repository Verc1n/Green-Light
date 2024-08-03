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

//This viewmodel class is an old, unused viewmodel for Drive Conditions
//This was in use before the database was implemented
//Contains the initialisation of the drive conditions
//As well as methods and events for controlling the collection of conditions
//for example selecting, filtering.

//I just left it in here for reference

namespace Green_Light.ViewModels
{
    internal class OLDDriveConditionVM : INotifyPropertyChanged
    {
        //Setting up variables and commands for accessibility by other pages/viewmodels
        //--------------------------------------------------------
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
                if (cdnSelectedDriveConditionA != value)
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
                if (clnSelectedDriveConditionsA != value)
                {
                    clnSelectedDriveConditionsA = value;
                }
            }
        }

        public string strSelectedDriveConditionMessage { get; private set; }

        public ICommand DriveConditionSelectionChangedCommand => new Command(DriveConditionSelectionChanged);


        public OLDDriveConditionVM()
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

        //---------------------------------------------------------------------------

        //Function to set up the default values for the drive conditions
        //As this viewmodel is not set up with database connection, the initialisation process
        //will simply run every time the app is opened.
        void CreateDriveConditionCollection()
        {
            lstSource.Add(new DriveCondition
            {
                strName = "Parallel Parking",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Vertical Parking",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Diagonal Parking",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Parking"
            });

            lstSource.Add(new DriveCondition
            {
                strName = "No Rain",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Weather",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Light Rain",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Weather",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Moderate Rain",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Weather",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Heavy Rain",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Weather",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Local Roads",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Roads",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Rural Roads",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Roads",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "City Roads",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Roads",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Highways",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Roads",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "No Traffic",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Traffic",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Light Traffic",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Traffic",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Moderate Traffic",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Traffic",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            lstSource.Add(new DriveCondition
            {
                strName = "Heavy Traffic",
                strImageURL = "placeholder_graphic.png",
                strCategory = "Traffic",
                dtmDateLastSelected = DateTime.Now,
                intTimesSelected = 0
            });

            clnDriveConditions = new ObservableCollection<DriveCondition>(lstSource);
        }

        //Function to update the selected drive condiitons and report how large the collection is
        //called as an event by the selection changed property of a collection view
        void DriveConditionSelectionChanged()
        {
            strSelectedDriveConditionMessage = $"Selection {intSelectionCount} : {cdnSelectedDriveConditionB.strName}";
            OnPropertyChanged("SelectedConditionMessage");
            intSelectionCount++;
        }

        //Unused function to filter the collection of conditions
        //takes a string filter indicating the category of a condition to filter
        //returns all conditions included in this category.
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

        //Just some background technical code to handle the property changed event
        //Pretty much unused, just needed to avoid throwing an error
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string strPropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
        #endregion
    }
}
