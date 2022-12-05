namespace GeraScriptAgillis.ViewModel
{
    public class LisRota
    {
        public string? AnoMes { get; set; }

        public string? Ciclo { get; set; }

        public string? IdRota { get; set; }

        public string? Setor { get; set; }

        public string? Pagina { get; set; }

        public string SetorRota { get { return Setor.ToString() + IdRota.ToString(); } set { } }

        public int QtdClientes { get; set; }

        public DateTime DtInicioLeit { get; set; }

        public DateTime DtFimLeit { get; set; }

        public DateTime DtGeracao { get; set; }

        public DateTime DtEmissao { get; set; }

        public int QtdExec { get; set; }

        public int VolMinRes { get; set; }

        public int VolMinCom { get; set; }

        public int VolMinInd { get; set; }

        public int VolMinPub { get; set; }

        public string? CotaBasRes { get; set; }

        public string? CotaBasCom { get; set; }

        public string? CotaBasInd { get; set; }

        public string? CotaBasPub { get; set; }

        public string? Arrasto { get; set; }

        public string? NomeLocal { get; set; }

        public string? Leiturista { get; set; }

        public string? NomeLeiturista { get; set; }

        public string CicloRota { get { return string.Format("{0}{1}{2}", Ciclo.ToString(), SetorRota.ToString(), Pagina.ToString().PadLeft(2, '0')); } set { } }

        public string? IndiceSort { get { return string.Format("{0}{1}{2}{3}", AnoMes, Ciclo.ToString().PadLeft(3, '0'), SetorRota, Pagina.ToString().PadLeft(3, '0')); } set { } }

        public int Versao { get; set; }

        public Decimal Variacao_Sup { get; set; }

        public Decimal Variacao_Inf { get; set; }

        public Decimal Valor_Res { get; set; }

        public Decimal Valor_Com { get; set; }

        public Decimal Valor_Ind { get; set; }

        public Decimal Valor_Pub { get; set; }

        public int Tipo_Impressao { get; set; }

        public int Is_Simulacao { get; set; }

        public string? InstanceName { get; set; }

        public int SituacaoRota { get; set; }

        public Decimal Vol_Inferior_Res { get; set; }

        public Decimal Vol_Inferior_Com { get; set; }

        public Decimal Vol_Inferior_Ind { get; set; }

        public Decimal Vol_Inferior_Pub { get; set; }

        public Decimal Vol_Superior_Res { get; set; }

        public Decimal Vol_Superior_Com { get; set; }

        public Decimal Vol_Superior_Ind { get; set; }

        public Decimal Vol_Superior_Pub { get; set; }

        public Decimal Variacao_Inf_Media_3_M { get; set; }

        public Decimal Variacao_Sup_Media_3_M { get; set; }

        public Decimal Variacao_Inf_12_Meses { get; set; }

        public Decimal Variacao_Sup_12_Meses { get; set; }

        public string? Indice_A { get; set; }
        public int Id_Palm { get; set; }
        public string? IndiceZGeral { get; set; }

    }

}
