using GeraScriptAgillis.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace GeraScriptAgillis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeraScriptController : ControllerBase
    {

        public GeraScriptController()
        {
        }

        [HttpPost(Name = "GeraScriptRetorno")]
        public async Task<string> GeraScriptRetorno(LisArquivoRetorno arquivoJson)
        {
            var rota = arquivoJson.Rota;
            rota.IndiceSort = string.IsNullOrEmpty(rota.IndiceSort) ? null : rota.IndiceSort.Substring(0, 17);
            var insertSQL = " ";

            if (arquivoJson.Conta != null && arquivoJson.Conta.Count() > 0)
            {
                insertSQL += "\n -------------TEMPVOLTAIMPJ------------- \n";
                foreach (var conta in arquivoJson.Conta)
                {
                    insertSQL += $@"INSERT INTO TEMPVOLTAIMPJ( INDICEJ, INDICEZ, PAGINA, MATRICULA, LEITURA, DATALEITURA, CONFIRMACAOLEIT, CONSUMOMEDIDO, IDFATURAMENTO, IDOCORR1, IDOCORR2, IDOCORR3, SEQORIGINALEMIT, VLAGUA, VLESGOTO, VLSERVICOS, QTDDEBITOS, VLDEBITO, VLMULTA, VLJUROS, VLICMS, VLTERCEIROS, VLDEVOLUCAO, DATAVENCIMENTO, IMPRESSAOCONTA, QTDIMPRESSAO, CONSUMOFATURADO, IDSETOR, ROTA, ID_CICLO, TIPO, VLCORRECAO, VLDESCONTO, IMPRESSAOCOBRANCA, QTDCOBRANCA, IMPRESSAOCTAPARC, QTDCTAPARC, VERSAO, CODBARRAS, ANOMES, CREDITO_UTILIZADO, VL_RECURSO_HIDRICO_AGUA, VL_RECURSO_HIDRICO_ESGOTO, VL_ESGOTO_ALTERNATIVO, VL_DESCONTO_RES_SOCIAL, VL_DESCONTO_PEQ_COMERCIO, VL_DESCONTO_LIG_ESTIMADA, VL_DEVOLUCAO_ICMS, VL_DESCONTO_AGUA, VL_DESCONTO_ESGOTO, PC_DESCONTO_AGUA_ESGOTO, VL_DESCONTO_PP_CONCEDENTE, VL_TAXA_REGULACAO, VL_DEVOLUCAO_REAJ_TARIFA, CD_MEMORIA_RETENCAO)
                                    VALUES (0, {rota.IndiceSort}, {rota.Pagina}, {conta.Matricula}, {conta.Leitura}, {conta.DtLeitura}, {conta.CfForaFaixa}, {conta.ConsumoMedido}, {conta.IdFaturamento}, {conta.Ocorr1}, {conta.Ocorr2}, {conta.Ocorr3}, {Convert.ToInt32(conta.IdDoc)}, {conta.VlAgua}, {conta.VlEsgoto}, {conta.VlServico}, {conta.QtdDebitos}; {conta.VlDebito * 100}, {conta.VlMulta * 100}, {conta.VlJuros * 100}, {conta.VlICMS}, {conta.VlTerceiro}, {conta.VlDevolucao}, {conta.DataVenc}, {conta.ImpressaoConta}, '{conta.QtdImpressao.ToString().PadLeft(2, '0')}', {Convert.ToInt32(conta.ConsumoFaturado)}, '{rota.Setor.Substring(0, 10)}', {rota.IdRota}, {Convert.ToInt32(rota.Ciclo)}, {conta.Tipo}, {conta.VlCorrecao}, {conta.VlDesconto}, {conta.ImpressaoCobranca.ToString()}, {conta.QtdCobranca.ToString().PadLeft(2, '0')}, {conta.ImpressaoCtaParc.ToString()}, {conta.QtdCtaParc.ToString().PadLeft(2, '0')}, {conta.Versao}, {conta.CodBarras}, {rota.AnoMes}, {conta.Credito_Utilizado}, {conta.vl_recurso_hidrico_agua}, {conta.vl_recurso_hidrico_esgoto}, {conta.vl_Esgoto_Alternativo}, {conta.vl_Desconto_Res_Social}, {conta.vl_Desconto_Peq_Comercio}, {conta.vl_Desconto_Lig_Estimada}, {conta.VlDevolucaoIcms}, {conta.vl_Desconto_Agua}, {conta.vl_Desconto_Esgoto}, {conta.pc_Desconto_Agua_Esgoto}, {conta.Vl_Desconto_PP_Concedente}, {conta.Vl_Taxa_Regulacao}, {conta.VlDevolucaoReajTarifa});";

                    insertSQL += "\n";
                }
            }
            

            if (arquivoJson.Cliente != null && arquivoJson.Cliente.Count() > 0)
            {
                insertSQL += "\n -------------TEMPVOLTAIMPB------------- \n";
                foreach (var cliente in arquivoJson.Cliente)
                {
                    insertSQL += $@"INSERT INTO TEMPVOLTAIMPB (MATRICULA, ID_LOCAL_ENTREGA, OBSERVACAO_LEITURA, ID_OBSERVACAO, LEITURA_ANTERIOR, TIPO_FATURAMENTO, ANO_MES, ID_CICLO, LEITURA, TX_QUESTIONARIO_LIS, FL_FONTE_ALTERNATIVA, CD_VARIACAO_CONSUMO, FL_FRAUDE, ID_LOCAL_HD, CPF_CNPJ, CELULAR, EMAIL, ID_MOTIVO, LATITUDE, LONGITUDE)
                                    VALUES ({cliente.Matricula}, {cliente.Id_Local_Entrega}, {cliente.OBSERVACAO_LEITURA}, {cliente.Id_Observacao}, {cliente.Leitura_Anterior}, {cliente.Tipo_Faturamento}, {cliente.Ano_Mes}, {cliente.Id_Ciclo}, {cliente.Leitura}, {cliente.Tx_Questionario_Lis}, {cliente.Fl_Fonte_Alternativa}, {cliente.Cd_Variacao_Consumo}, {cliente.Fl_Fraude}, {cliente.Id_Local_Hd}, {cliente.Cpf_Cnpj}, {cliente.Celular}, {cliente.Email}, {cliente.Id_Motivo}, {cliente.Latitude}, {cliente.Longitude});";
                    insertSQL += "\n";
                }
            }
            

            if (arquivoJson.Retencao != null && arquivoJson.Retencao.Count() > 0)
            {
                insertSQL += "\n -------------TEMPVOLTAIMPR------------- \n";
                foreach (var motivo in arquivoJson.Retencao)
                {
                    insertSQL += $@"INSERT INTO TEMPVOLTAIMPR (MATRICULA, ID_MOTIVO, TIPO, ANO_MES, ID_CICLO)
                                    VALUES ({motivo.Matricula}, {motivo.Id_Motivo}, {motivo.Tipo}, {rota.AnoMes}, {rota.Ciclo})";
                    insertSQL += "\n";
                }
            }
                

            if (arquivoJson.Fatura != null && arquivoJson.Fatura.Count() > 0)
            {
                insertSQL += "\n -------------TEMPVOLTAIMPI------------- \n";
                foreach (var fatura in arquivoJson.Fatura)
                {
                    insertSQL += $@"insert into TEMPVOLTAIMPI (INDICEI, IDREG, INDICEZ, PAGINA, MATRICULA, CATEGORIA, SERVICO, CONSUMOFATURADO, VLFATURAMENTO, IDFAIXA, VLICMS, IDSETOR, ROTA, ID_CICLO, FAIXAMAXIMA, ANOMES, ID_FATOR_REDUTOR, VL_DESCONTO_FATOR_REDUTOR, ID_TARIFA) 
                                            VALUES (0, I, {fatura.Indice.Substring(2, 18)}, {Convert.ToInt32(rota.Pagina)}, {fatura.Matricula}, {fatura.Categoria}, {fatura.Servico.ToString()}, {fatura.ConsumoFaturado}, {fatura.VlFaturamento}, {fatura.IdFaixa.ToString().PadLeft(2, '0')}, {fatura.VlIcms}, {rota.Setor.Substring(0, 10)}, {rota.IdRota}, {rota.Ciclo}, {fatura.FaixaMaxima}, {rota.AnoMes}, {fatura.id_Fator_Redutor}, {fatura.vl_Desconto_Fator_Redutor}, {fatura.IdTarifa});";
                    insertSQL += "\n";
                }
            }

            if(arquivoJson.RecursoHidrico != null && arquivoJson.RecursoHidrico.Count() > 0)
            {
                insertSQL += "\n -------------TEMPVOLTAIMPRECHIDR------------- \n";
                foreach (var contaRecursosHidricos in arquivoJson.RecursoHidrico)
                {
                    insertSQL += $@"insert into TEMPVOLTAIMPRECHIDR (SEQ_ORIGINAL, ID_RECURSOS_HIDRICOS, MATRICULA, ANO_MES, PERCENTUAL, DIAS_CONSUMO, ID_CICLO, ROTA, SEQCONTROLE) 
                                            VALUES ({contaRecursosHidricos.SeqOriginal}, {contaRecursosHidricos.IdRecursosHidricos}, {contaRecursosHidricos.Matricula}, {rota.AnoMes}, {contaRecursosHidricos.Percentual}, {contaRecursosHidricos.DiasConsumo}, {rota.Ciclo}, {rota.IdRota}, 0)";
                    insertSQL += "\n";
                }
            }
            
            return insertSQL;
        }

    }

}