namespace CompLogic.Car {

    public class Utils {
        public static long CreateGUID() {
            // 16 Byte Schlüssel
            System.Guid gUID = System.Guid.NewGuid();
            string strgUID = gUID.ToString();
            byte[] bUID = gUID.ToByteArray();

            // die ersten 8 Bytes werden verwendet
            long lUID = 0;
            lUID = lUID | (long)bUID[0];
            int shift = 8;
            for (int i = 1; i < 8; i++)
            {
                lUID = lUID | (long)bUID[i] << shift;
                shift = shift + 8;
            }
            //Console.WriteLine (string.Format("getGUID:{0:d}={1:s}",
            //    lUID,Utils.ToBinaryString (lUID)));

            // return lUID;
            // string strlUID = string.Format( "{0:d}", lUID );
            return lUID;


            /*
            // Byte-Feld in Char wandeln und anschließend in String
            string strbUID ="";
            char [] cUID = new char[16];
            for (int pIndex = 0; pIndex < 16; pIndex++) {
                cUID[pIndex] = (char) bUID[pIndex];
                strbUID += cUID[pIndex].ToString();
            }

            // Test Ausdruck
            for(int pIndex = 0; pIndex < 8; pIndex++) {
                string strFeld = string.Format("{0:s}{1:d2}{2:s}","bUID[",pIndex,"]");
                strFeld += string.Format(" {0:d4}",bUID[pIndex]);
                strFeld += string.Format("= {0:s}",Utils.ToBinaryString (bUID[pIndex])); 
                Console.WriteLine (strFeld);
            }
            */

        } // class CreateGUID

        public static double ParseDouble( string s, double defaultValue ) {
            double value;
            s = s.Replace(".","");
            if( ! double.TryParse( s, out value ) ) {
                value = defaultValue;
            }
            return value;
        }

        public static  int ParseInt( string s, int defaultValue ) {
            int value;
            s = s.Replace(".","");
            if( ! int.TryParse( s, out value ) ) {
                value = defaultValue;
            }
            return value;
        }
    }
}
