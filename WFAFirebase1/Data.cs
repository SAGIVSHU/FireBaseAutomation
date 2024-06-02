using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAFirebase1
{
    internal class Data
    {
        public string dogWalkerName { get; set; }
        public string dogWalkerPhoneNumber { get; set; }
        public string dogWalkerRating { get; set; }
        public string dogWalkerLocation { get; set; }
        public string walkerId { get; set; }
        public string walkerSumRatedTrips { get; set; }



        public override string ToString()
        {
            return $"ID: {walkerId}, Name: {dogWalkerName}, Location: {dogWalkerLocation}, Rating: {dogWalkerRating}, Phone: {dogWalkerPhoneNumber}, SumTrips: {walkerSumRatedTrips}";
        }
    }
}
