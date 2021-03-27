/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.validation;

import com.tbp.exception.CotacaoInvalidaException;
import com.tbp.model.Cotacao;
import java.text.NumberFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.Locale;
import org.springframework.stereotype.Controller;

/**
 *
 * @author hugot
 */
@Controller
public class CotacaoValidacao {
    
    
    public void validar(Cotacao cotacao) throws CotacaoInvalidaException, Exception{
        
        if(cotacao.getValidade() == null)
            throw new CotacaoInvalidaException("Validade da contação não informada.");
        
        if(isData(cotacao.getValidade().toString()))
            throw new CotacaoInvalidaException("Validade da contação inválida.");
        
        if(cotacao.getProduto() == null)
            throw new CotacaoInvalidaException("Produto da contação não informada.");
        
        if(cotacao.getValorProduto() == 0.0)
            throw new CotacaoInvalidaException("Valor produto da contação não informada.");
        
        if(("").equals(cotacao.getFornecedor()))
            throw new CotacaoInvalidaException("Fornecedor da contação não informada.");
    }
    
    
    public boolean isData(String data) {
        try {
            SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
            sdf.setLenient(false);
            sdf.parse(data);
            
            DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd/MM/yyyy");
            LocalDate dataVerificada = LocalDate.parse(data, dtf);
            LocalDate hoje = LocalDate.now();

            return dataVerificada.compareTo(hoje) <= 0;
            
        } catch (ParseException ex) {
            return false;
        }
    }
    
    
    public String formatarData(Date data)
    {
        SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");         
        return formato.format(data);
    }
    
    public String formatarMoeda(Double valor)
    {
        Locale localeBR = new Locale( "pt", "BR" );  
        NumberFormat dinheiroBR = NumberFormat.getCurrencyInstance(localeBR);  
        String retorno = dinheiroBR.format(valor).replace("R$", "");
        return retorno.trim();
    }
}
