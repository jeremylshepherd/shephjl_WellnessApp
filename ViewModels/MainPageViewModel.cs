using System.ComponentModel;
using System.Runtime.CompilerServices;
using shephjl_WellnessApp.Models;

namespace shephjl_WellnessApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Gender _selectedGender = Gender.Male;
        private double _sleepHours = 7.0;
        private double _stressLevel = 4.0;
        private double _activityMinutes = 30.0;
        private int _wellnessScore;
        private WellnessStatus _status;
        private string _recommendation = string.Empty;

        public Gender SelectedGender
        {
            get => _selectedGender;
            set
            {
                if (SetProperty(ref _selectedGender, value))
                {
                    OnPropertyChanged(nameof(IsMaleSelected));
                    OnPropertyChanged(nameof(IsFemaleSelected));
                    CalculateWellnessScore();
                }
            }
        }

        public bool IsMaleSelected => SelectedGender == Gender.Male;
        public bool IsFemaleSelected => SelectedGender == Gender.Female;

        public double SleepHours
        {
            get => _sleepHours;
            set
            {
                if (SetProperty(ref _sleepHours, value))
                {
                    OnPropertyChanged(nameof(SleepHoursDisplay));
                    CalculateWellnessScore();
                }
            }
        }

        public string SleepHoursDisplay => $"{SleepHours:F1} h";

        public double StressLevel
        {
            get => _stressLevel;
            set
            {
                if (SetProperty(ref _stressLevel, value))
                {
                    OnPropertyChanged(nameof(StressLevelDisplay));
                    CalculateWellnessScore();
                }
            }
        }

        public string StressLevelDisplay => $"{StressLevel:F1}";

        public double ActivityMinutes
        {
            get => _activityMinutes;
            set
            {
                if (SetProperty(ref _activityMinutes, value))
                {
                    OnPropertyChanged(nameof(ActivityMinutesDisplay));
                    CalculateWellnessScore();
                }
            }
        }

        public string ActivityMinutesDisplay => $"{ActivityMinutes:F0} min";

        public int WellnessScore
        {
            get => _wellnessScore;
            private set => SetProperty(ref _wellnessScore, value);
        }

        public WellnessStatus Status
        {
            get => _status;
            private set
            {
                if (SetProperty(ref _status, value))
                {
                    OnPropertyChanged(nameof(StatusDisplay));
                    OnPropertyChanged(nameof(StatusColor));
                }
            }
        }

        public string StatusDisplay => Status.ToString();

        public Color StatusColor => Status switch
        {
            WellnessStatus.Excellent => Colors.Green,
            WellnessStatus.Good => Colors.LightGreen,
            WellnessStatus.Fair => Colors.Orange,
            WellnessStatus.Poor => Colors.Red,
            _ => Colors.Gray
        };

        public string Recommendation
        {
            get => _recommendation;
            private set => SetProperty(ref _recommendation, value);
        }

        public MainPageViewModel()
        {
            CalculateWellnessScore();
        }

        private void CalculateWellnessScore()
        {
            double rawScore =
              (SleepHours * 8) - (StressLevel * 5) + (ActivityMinutes * 0.5);

            rawScore = Math.Max(0, Math.Min(100, rawScore));

            WellnessScore = (int)Math.Round(rawScore);

            Status = WellnessScore switch
            {
                >= 80 => WellnessStatus.Excellent,
                >= 60 => WellnessStatus.Good,
                >= 40 => WellnessStatus.Fair,
                _ => WellnessStatus.Poor
            };

            Recommendation = GetRecommendation(Status, SelectedGender);
        }

        private string GetRecommendation(
          WellnessStatus status,
          Gender gender
        )
        {
            return (status, gender) switch
            {
                (WellnessStatus.Excellent, Gender.Male) =>
                    "• Maintain routine\n"
                    + "• Include resistance training 2–3× per week\n"
                    + "• Ensure protein intake across meals",
                (WellnessStatus.Excellent, Gender.Female) =>
                    "• Keep strong habits\n"
                    + "• Add yoga/pilates for recovery\n"
                    + "• Prioritize calcium + vitamin D intake",
                (WellnessStatus.Good, Gender.Male) =>
                    "• Improve recovery with an earlier bedtime\n"
                    + "• Add 15 min of light cardio or stretching\n"
                    + "• Keep hydration steady",
                (WellnessStatus.Good, Gender.Female) =>
                    "• Boost energy with a balanced breakfast\n"
                    + "• Add 15 min of walking\n"
                    + "• Focus on iron-rich foods if feeling low",
                (WellnessStatus.Fair, Gender.Male) =>
                    "• Aim for +1 hour of sleep\n"
                    + "• Reduce caffeine after noon\n"
                    + "• Schedule light mobility or an easy walk",
                (WellnessStatus.Fair, Gender.Female) =>
                    "• Increase sleep consistency\n"
                    + "• Reduce evening screen time\n"
                    + "• Include calming routines like meditation or journaling",
                (WellnessStatus.Poor, Gender.Male) =>
                    "• Rest today\n"
                    + "• Avoid strenuous workouts\n"
                    + "• Focus on hydration and 20–30 min of gentle walking",
                (WellnessStatus.Poor, Gender.Female) =>
                    "• Prioritize rest and self-care\n"
                    + "• Consider a short nap if possible\n"
                    + "• Gentle yoga/stretching only",
                _ => string.Empty
            };
        }
    }
}