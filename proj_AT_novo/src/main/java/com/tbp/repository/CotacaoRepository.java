/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.repository;
import com.tbp.model.Cotacao;
import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author hugot
 */
@Repository
public interface CotacaoRepository extends CrudRepository<Cotacao, Integer>{
    Cotacao findById(int id);
    List<Cotacao> findByFornecedorIgnoreCaseContaining(String fornecedor);
    //List<Cotacao> findByProdutoDescricaoIgnoreCaseContaining(String descricao);
}
