using GoodianoBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.HomePage.HomePageImages
{
    public class HomePageImage : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public DateTime Time { get; set; }
        public LocationImages LocationImages { get; set; }

    }


    public enum LocationImages
    {
        tr1 = 1,  //تاپ راست 
        tr2 = 2,  //
        tr3= 3,   //
        tr4 = 4,  //
        tlt = 5,  //تاپ چپ بالا
        tlb = 6,  //تاپ چپ پایین
        np = 7,   //جدیدترین
        pr= 8,    //پیشنهاد روزانه
        cs = 9,   //سی شارپ و پست هاش
        tt = 10,  //تبلیغات 
        mt = 11,  //محبوب ترین ها       
    }
}

