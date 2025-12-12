using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi2
{
    public class Dev
    {
        internal string _id_dev;
        internal string _nama_dev;
        internal string _status_kontrak;
        internal string _fitur_selesai;
        internal string _jumlah_bug;

        public string Nama
        {
            get { return _nama_dev; } set { _nama_dev = value; }
        }
        public string Proyek
        {
            get { return _status_kontrak; } set { _status_kontrak = value; }
        }
    }
}
