using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{

    public partial class Cars
    {
        public string ImageCarPath
        {
            get
            {
                string AutomobileImage;
                if (Image != null)
                {
                    AutomobileImage = "..\\Assets\\Images\\" + Image.Trim();
                }
                else
                {
                    AutomobileImage = "";
                }
                return AutomobileImage;
            }
        }

        public string ImageCarAbovePath
        {
            get
            {
                string AutomobileAboveImage;
                if (Image != null)
                {
                    AutomobileAboveImage = "..\\Assets\\Images\\" + ImageAbove.Trim();
                }
                else
                {
                    AutomobileAboveImage = "";
                }
                return AutomobileAboveImage;
            }
        }

        //public string BackColor
        //{
        //    get
        //    {
        //        if (Availability == 2)
        //        {
        //            return "#fffead";
        //        }
        //        else 
        //        {
        //            if (Availability == 1)
        //                return "#ffadad";
        //            else
        //                return "#aeffad";
        //        }

        //    }
        //}

        //public string TextColor
        //{
        //    get
        //    {
        //        if (Availability == 2)
        //        {
        //            return "#ffd600";
        //        }
        //        else 
        //        {
        //            if (Availability == 1)
        //                return "#e25353";
        //            else
        //                return "#0fff00";
        //        }

        //    }
        //}

        //public string TextAvailability
        //{
        //    get
        //    {
        //        if (Availability == 2)
        //        {
        //            return "На ремонте";
        //        }
        //        else
        //        {
        //            if (Availability == 1)
        //                return "Занят";
        //            else
        //                return "Свободен";
        //        }

        //    }
        //}
    }
}
