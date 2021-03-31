/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.tbp.repository;

import org.springframework.data.repository.CrudRepository;
import com.tbp.model.Produto;
import java.util.List;
import org.springframework.stereotype.Repository;
/**
 *
 * @author hugot
 */
@Repository
public interface ProdutoRepository extends CrudRepository<Produto, Long>{
    
    List<Produto> findById(int id);    
    List<Produto> findByDescricaoIgnoreCaseContaining(String nome);
    List<Produto> findBySituacaoIgnoreCaseContaining(String situacao);
}
