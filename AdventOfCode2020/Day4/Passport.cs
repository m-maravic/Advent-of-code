using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Passport
    {
        public int byr { get; set; }
        public int iyr { get; set; }
        public int eyr { get; set; }
        public int hgtcm { get; set; }
        public int hgtin { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public int cid { get; set; }

        public bool IsValid()
        {
            if (byr >= 1920 && byr <= 2002 &&
                iyr >= 2010 && iyr <= 2020 &&
                eyr >= 2020 && eyr <= 2030)
            {
                if ((hgtcm >= 150 && hgtcm <= 193) || (hgtin >= 59 && hgtin <= 76))
                {
                    if (!string.IsNullOrEmpty(hcl))
                    {
                        if (!string.IsNullOrEmpty(ecl))
                        {
                            if (ecl.Equals("amb") || ecl.Equals("blu") || ecl.Equals("brn") || ecl.Equals("gry")
                                || ecl.Equals("grn") || ecl.Equals("hzl") || ecl.Equals("oth"))
                            {
                                if (!String.IsNullOrEmpty(pid))
                                {
                                    if (pid.Length == 9 && Int32.TryParse(pid, out int result))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

}
