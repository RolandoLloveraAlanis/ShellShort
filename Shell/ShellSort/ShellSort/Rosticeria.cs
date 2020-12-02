using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Rosticeria :  IComparable<Rosticeria>
    {
        string _strNombre, _strMoneda, _strFoto, _strRFC;
        double _dblIngresoAnual;
        int _intNumEmpleados;
        char _chrDistribuidor;
        DateTime _dtmInauguracion;
        bool _boolServicioDomicilio;
        DateTime _dtmHoraEntrada;

        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public string RFC
        {
            get { return _strRFC; }
            set { _strRFC = value; }
        }

        public string Moneda
        {
            get { return _strMoneda; }
            set { _strMoneda = value; }
        }
        public string Foto
        {
            get { return _strFoto; }
            set { _strFoto = value; }
        }
        public double IngresoAnual
        {
            get { return _dblIngresoAnual; }
            set { _dblIngresoAnual = value; }
        }
        public int NumEmpleados
        {
            get { return _intNumEmpleados; }
            set { _intNumEmpleados = value; }
        }
        public char Distribuidor
        {
            get { return _chrDistribuidor; }
            set { _chrDistribuidor = value; }
        }
        public DateTime Inauguracion
        {
            get { return _dtmInauguracion; }
            set { _dtmInauguracion = value; }
        }
        public DateTime HoraEntrada
        {
            get { return _dtmHoraEntrada; }
            set { _dtmHoraEntrada = value; }
        }
        public bool ServicioDomicilio
        {
            get { return _boolServicioDomicilio; }
            set { _boolServicioDomicilio = value; }
        }

        public int CompareTo(Rosticeria otraRosticeria)
        {
            {
                return (this.RFC.CompareTo(otraRosticeria.RFC));
            }
        }
        public string ConvertirDeboolaString()
        {
            if (ServicioDomicilio == true)
            {
                return "Si";
            }
            else
            {
                return "No";
            }
        }


    }
}
