/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.validation;

import com.tbp.exception.ProdutoInvalidoException;
import com.tbp.model.Cotacao;
import com.tbp.repository.ProdutoRepository;
import com.tbp.model.Produto;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;
import javax.swing.JFileChooser;
import org.springframework.stereotype.Component;

/**
 *
 * @author hugot
 */
@Component
public class ProdutoValidation {
        
        
    public void validar(Produto produto) throws ProdutoInvalidoException, Exception
    {
        if(("").equals(produto.getDescricao()))
            throw new ProdutoInvalidoException("Descrição do produto não informada.");
        
        if(("").equals(produto.getSituacao()))
            throw new ProdutoInvalidoException("Situação do produto não informada.");
    }
    
    public void exportarProduto(List<Produto> produtos) throws IOException{
        try {
            JFileChooser fileChooser = new JFileChooser();
            fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
            fileChooser.showSaveDialog(null);
            
            File file = new File(fileChooser.getSelectedFile(),"produtos.csv");
            FileWriter fileWrite = new FileWriter(file, false);
            StringBuilder builder = new StringBuilder();
            
            for (Produto produto : produtos) {
                builder.append(produto.getId().toString());
                builder.append(";");
                builder.append(produto.getDescricao());
                builder.append(";");
                builder.append(produto.getSituacao());
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
