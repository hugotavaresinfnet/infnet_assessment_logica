/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.validation;

import com.tbp.exception.CotacaoInvalidaException;
import com.tbp.model.Cotacao;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.NumberFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import javax.swing.JFileChooser;
import javax.swing.SwingConstants;
import javax.swing.table.DefaultTableCellRenderer;
import org.graalvm.compiler.phases.tiers.Suites;
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
        String retorno = dinheiroBR.format(valor).replace("R$", "").replaceAll(" ", "");
        return retorno.trim();
    }
    
    public Date formatarDate(String data) throws ParseException
    {
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");    
        Date date = sdf.parse(data);
        return date;
    }
    
    public DefaultTableCellRenderer alingTable(String aling){
        DefaultTableCellRenderer alingment = new DefaultTableCellRenderer();
        
        switch(aling.toUpperCase())
        {
            case "R": alingment.setHorizontalAlignment(SwingConstants.RIGHT);
                break;
            case "L": alingment.setHorizontalAlignment(SwingConstants.LEFT);
                break;
            case "C": alingment.setHorizontalAlignment(SwingConstants.CENTER);
                break;
            default: alingment.setHorizontalAlignment(SwingConstants.LEFT);
                break;            
        }  
        
        return alingment;        
    }
    
    public void exportarCotacoes(List<Cotacao> cotacoes) throws IOException{
        try {
            JFileChooser fileChooser = new JFileChooser();
            fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
            fileChooser.showSaveDialog(null);
            
            File file = new File(fileChooser.getSelectedFile(),"cotacoes.csv");
            FileWriter fileWrite = new FileWriter(file, false);
            StringBuilder builder = new StringBuilder();
            for (Cotacao cotacoe : cotacoes) {
                builder.append(cotacoe.getId().toString());
                builder.append(";");
                builder.append(cotacoe.getFornecedor());
                builder.append(";");
                builder.append(formatarData(cotacoe.getData()));
                builder.append(";");
                builder.append(formatarData(cotacoe.getValidade()));
                builder.append("\n");
            }
            
            fileWrite.append(builder.toString());
            fileWrite.flush();
            fileWrite.close();            
        } catch (IOException e) {
            throw new IOException(e.getMessage());
        }
    }
}
