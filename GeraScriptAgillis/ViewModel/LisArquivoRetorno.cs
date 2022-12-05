namespace GeraScriptAgillis.ViewModel
{
    public class LisArquivoRetorno
    {
        public LisRota? Rota { get; set; }
        public List<TempVoltaImpB>? Cliente { get; set; }
        public List<TempVoltaImpF>? Fatura { get; set; }
        public List<TempVoltaImpR>? Retencao { get; set; }
        public List<TempVoltaImpJ>? Conta { get; set; }
        public List<TempVoltaImpRh>? RecursoHidrico { get; set; }
    }

}
