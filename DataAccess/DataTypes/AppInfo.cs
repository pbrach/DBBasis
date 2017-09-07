using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataTypes
{
    public class AppInfo
    {
        public AppInfo()
        {

        }

        [Key]
        public string AppVersion { get; set; }

        public string AppInfoText { get; set; }
    }
}
