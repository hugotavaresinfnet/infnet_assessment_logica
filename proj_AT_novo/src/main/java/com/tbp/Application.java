package com.tbp;


import com.formdev.flatlaf.FlatDarkLaf;
import com.tbp.visao.Janela;
import java.awt.Dimension;
import javax.swing.JFrame;
import javax.swing.SwingUtilities;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.ConfigurableApplicationContext;

@SpringBootApplication
public class Application  {
   

    public static void main(String[] args) throws ClassNotFoundException {
        ConfigurableApplicationContext context = new SpringApplicationBuilder(
				Application.class).headless(false).run(args);
        
        Janela appFrame = context.getBean(Janela.class);
        
        appFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        appFrame.setPreferredSize(new Dimension(850, 620));
        appFrame.pack();
        appFrame.setLocationRelativeTo(null);

        try {
            UIManager.setLookAndFeel(new FlatDarkLaf());
        } catch (UnsupportedLookAndFeelException e) {
            e.printStackTrace();
        }
                      
        
        SwingUtilities.updateComponentTreeUI(appFrame);
        
	appFrame.setVisible(true);
    }

   
}
