using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Server.Control;
using Console_Server.Database;
using Console_User.Control;


namespace Console_User.Test
{
    public class Test_Parking
    {
        private CTR_User user;

        public Test_Parking(string name, string email, string mobile, string plate_number)
        {
            this.user = CTR_User.GetInstance(name, email, mobile, plate_number);
        }

        public string TestNearestParking()
        {
            int index = 0;
            int times = 500;
            CTR_Parking parking = new CTR_Parking();

            while (index < times)
            {
                TableParkingPlace nearest = parking.FindNearest(user.GetUser().GetLocation().GetLongtitude(), user.GetUser().GetLocation().GetLatitude(), user.GetUser().GetLocation().GetAltitude());
                index++;
            }

            return "Done Testing Nearest Parking";
        }
    }
}
