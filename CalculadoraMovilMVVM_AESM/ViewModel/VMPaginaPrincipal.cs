using CalculadoraMovilMVVM_AESM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculadoraMovilMVVM_AESM.ViewModel
{
    public class VMPaginaPrincipal : BaseViewModel
    {
        #region VARIABLES
        private CalculadoraModel _calculadoraModel = new CalculadoraModel();
        private string _entradaActual = "";
        private bool _desactivarTrigger;
        private string _triggerOperacion;
        string _Texto;
        #endregion
        #region CONTRUCTOR
        public VMPaginaPrincipal(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string EntradaActual
        {
            get { return _entradaActual; }
            set { SetValue(ref _entradaActual, value); }
        }
        public bool DesactivarTrigger
        {
            get { return _desactivarTrigger; }
            set { SetValue(ref _desactivarTrigger, value); }
        }
        public string TriggerOperacion
        {
            get { return _triggerOperacion; }
            set { SetValue(ref _triggerOperacion, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        private void NumeroPresionado(string numero)
        {
            EntradaActual += numero;
        }

        private void OperacionPresionada(string operador)
        {
            if (!string.IsNullOrEmpty(EntradaActual))
            {
                if (!string.IsNullOrEmpty(_calculadoraModel.Operacion))
                    IgualPresionado();

                _calculadoraModel.PrimerNumero = double.Parse(EntradaActual);
                _calculadoraModel.Operacion = operador;

                EntradaActual = "";
                DesactivarTrigger = true;
                TriggerOperacion = operador;
                
            }
        }

        private void IgualPresionado()
        {
            if (!string.IsNullOrEmpty(EntradaActual))
            {
                _calculadoraModel.SegundoNumero = double.Parse(EntradaActual);
                double resultado = _calculadoraModel.RealizarCalculo();

                EntradaActual = resultado.ToString();

                _calculadoraModel.Operacion = "";
                DesactivarTrigger = false;
                TriggerOperacion = null;
                
            }
        }

        private void DecimalPresionado()
        {
            if (!EntradaActual.Contains("."))
                EntradaActual += ".";
        }

        private void BorrarPresionado()
        {
            if (!string.IsNullOrEmpty(EntradaActual))
            {
                EntradaActual = EntradaActual.Substring(0, EntradaActual.Length - 1);
            }
        }

        private void LimpiarPresionado()
        {
            EntradaActual = "";
            _calculadoraModel.PrimerNumero = 0.0;
            _calculadoraModel.SegundoNumero = 0.0;
            _calculadoraModel.Operacion = "";
            DesactivarTrigger = false;
            TriggerOperacion = null;

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand NumeroCommand => new Command<string>(NumeroPresionado);
        public ICommand OperacionCommand => new Command<string>(OperacionPresionada);
        public ICommand IgualCommand => new Command(IgualPresionado);
        public ICommand DecimalCommand => new Command(DecimalPresionado);
        public ICommand BorrarCommand => new Command(BorrarPresionado);
        public ICommand LimpiarCommand => new Command(LimpiarPresionado);
        #endregion
    }
}
