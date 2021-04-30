namespace OverloadingAndInterfaces.Angle
{
    public class Angle
    {
        private int degrees;
        private int minutes;
        private int seconds;

        public override string ToString()
        {
            string output = degrees + " degrees " + minutes + "' " + seconds + "\"";
            return output;
        }

        public Angle()
        {
        }

        public Angle(int degrees, int minutes, int seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public static Angle operator +(Angle one, Angle two)
        {
            Angle sumAngle = new Angle();
            int sumSeconds = one.seconds + two.seconds;
            sumAngle.seconds = (sumSeconds) < 60 ? sumSeconds : sumSeconds - 60;
            
            int sumMinutes = one.minutes + two.minutes;
            int differenceSeconds = (sumSeconds) < 60 ? 0 : 1;
            sumAngle.minutes = (sumMinutes +  differenceSeconds) < 60 ? sumMinutes +  differenceSeconds: sumMinutes - 60 + differenceSeconds;
            
            int sumDegrees = one.degrees + two.degrees;
            int differenceMinutes = (sumMinutes +  differenceSeconds) < 60 ? 0 : 1;
            sumAngle.degrees = sumDegrees + differenceMinutes;
            return sumAngle;
        }

        public static Angle operator -(Angle one, Angle two)
        {
            Angle minusAngle = new Angle();
            int minusSeconds = one.seconds - two.seconds;
            minusAngle.seconds = (minusSeconds) > 0 ? minusSeconds : minusSeconds + 60;
            
            int minusMinutes = one.minutes - two.minutes;
            int differenceSeconds = (minusSeconds) > 0 ? 0 : -1;
            minusAngle.minutes = (minusMinutes + differenceSeconds) > 0 ? minusMinutes +  differenceSeconds: minusMinutes + 60 + differenceSeconds;
            
            int minusDegrees = one.degrees - two.degrees;
            int differenceMinutes = (minusMinutes + differenceSeconds) > 0 ? 0 : -1;
            minusAngle.degrees = minusDegrees + differenceMinutes;
            return minusAngle;
        }
        
        public static Angle operator *(Angle one, Angle two)
        {
            Angle multiplyAngle = new Angle();
            int multiplySeconds = one.seconds * two.seconds;
            multiplyAngle.seconds = (multiplySeconds) < 60 ? multiplySeconds : multiplySeconds % 60;

            int multiplyMinutes = one.minutes * two.minutes;
            int differenceSeconds = (multiplySeconds) < 60 ? 0 : multiplySeconds / 60;
            multiplyAngle.minutes = (multiplyMinutes +  differenceSeconds) < 60 ? multiplyMinutes +  differenceSeconds: (multiplyMinutes + differenceSeconds) % 60;
            
            int multiplyDegrees = one.degrees * two.degrees;
            int differenceMinutes = (multiplyMinutes +  differenceSeconds) < 60 ? 0 : (multiplyMinutes + differenceSeconds) / 60;
            multiplyAngle.degrees = multiplyDegrees + differenceMinutes;
            return multiplyAngle;
        }
        
        public static bool operator ==(Angle one, Angle two)
        {
            if (one.seconds == two.seconds && one.minutes == two.minutes && one.degrees == two.degrees)
                return true;
            return false;
        }
        
        public static bool operator !=(Angle one, Angle two)
        {
            if (one.seconds != two.seconds || one.minutes != two.minutes || one.degrees != two.degrees)
                return true;
            return false;
        }
        
        public static bool operator <(Angle one, Angle two)
        {
            if ((one.seconds < two.seconds && one.minutes < two.minutes && one.degrees < two.degrees) 
                || (one.seconds < two.seconds && one.minutes < two.minutes) 
                || (one.degrees < two.degrees))
                return true;
            return false;
        }
        
        public static bool operator >(Angle one, Angle two)
        {
            if (one < two)
                return false;
            return true;
        }
    }
}