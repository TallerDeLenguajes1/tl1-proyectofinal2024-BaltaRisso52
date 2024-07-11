using System.Security.Cryptography.X509Certificates;
using Monstruos;
using Protagonista;

namespace Funciones
{
  class FuncionesVarias
  {
    public static void MostrarIntro()
    {


      Console.WriteLine(@"

              .+++*****%-                                                                           
              #:.:::--#@@=                                                                          
             %*        .=%#:                                                                        
            @@*           .-=:                                                                      
           :@@#                                  :-:.                                               
           :@@@%=                             =#@#.                                                 
           :=*@@@@%+:                         -@@.                                                  
               -*%@@@@%+-                     :@@                                                   
                  .=*%@@@@%**-                :@%         .                                         
   :                  .=#@@@@.     -:..--     :@%      ----=*-                                      
    :                    :@@@    +#.    -@*.  :@%    +%:    -@%:                                    
     -.                   @@@   %@:      =@%  :@%   #@=      -@@.                                   
      :-.:-               @@@  .@@.      :@@: :@%  .@@-       @@=                                   
         :*@@@*.          @@@   @@=      -@#  :@%   %@##:    :@@.                                   
:-=-:       =%@@*-   ..:-*@@@:  .#@-    .#*   :@@.  .*@@.    ##.                                    
  .*@@%+.    +%@@@%%##+=::----:.  .==----.   .+*#+.   .=+=--=. ..                                   
    +@@@%-                                                 .+#@=                                    
    .@@@:                          .                       -@@+    ::-.                            
     @@@:                         *                         @@=     +=                               
     @@@.                .--=-.  -%        :-=:  .:-==:     @@-            .:=  .-=-.     . ---. .   
     @@@.              -*:    @#.=@:       .%.  +=    #@+   @@-    *@@  :-#@%.---=@@:   +@:   .%@#-.
     @@@.             -@  ....@@@.@@:      +:  %*.....-@@=  @@-    =@@    :@@     +@*  +@%     %@+  
     @@@:             #@  ....... :*@=    -=  :@+.......    @@-    -@@    :@%     =@#  =@@     %@=  
     @@@:           : %@:            +%. :+   :@#           @@-    -@@    :@%     =@%   =%#: .=%-   
     @@@:          -+ +@@-     -    .#@@+*     #@*.    :.   @@:    -@@    :@%     =@%   -+....      
    :@@@*-::::---+%%   .:==+++#@%=    -*@%.     :*%#+++@@#:.@@=    =@@.   -@@     +@@  :@%*++++==-  
  .:---------------.      .....          +%.        ....   :---    ---:   ---:    ---:  +===++++*#%.
                                          -:                                          -@-         +.
                                                                                      =@*-:::::-+=.  ");
      Thread.Sleep(1300);

      string texto = @"            
            ╔════════════════════════════════════════════════════════════════╗
            ║                                                                ║
            ║     ¡Bienvenido a Solo Leveling: La Ascencion del Cazador!     ║
            ║                                                                ║
            ╠════════════════════════════════════════════════════════════════╣
            ║ En un mundo de fantasia, aventura y mazmorras,                 ║
            ║ solo los cazadores más valientes se atreven a enfrentarlas.    ║
            ║ Eres un cazador novato, pero con un potencial increíble.       ║
            ║                                                                ║
            ║ Tu objetivo es adentrarte en las mazmorras, derrotar           ║
            ║ a los monstruos que las habitan y enfrentarte al jefe final    ║
            ║ para cerrar cada mazmorra. Con cada victoria, ganarás          ║
            ║ experiencia y podrás mejorar tus estadísticas.                 ║
            ║                                                                ║
            ║ Prepara tus armas, afina tus sentidos y lánzate a la aventura. ║
            ║ El destino de la humanidad está en tus manos.                  ║
            ║                                                                ║
            ╠════════════════════════════════════════════════════════════════╣
            ║            Presiona cualquier tecla para continuar...          ║
            ╚════════════════════════════════════════════════════════════════╝ ";
      foreach (var item in texto)
      {
        Console.Write(item);
        Thread.Sleep(1);
      }
      Console.ReadKey();
      Console.Clear();

    }

    public static void EfectoCombatePersonaje(Personaje jugador, Monstruo monstruo, int danioJugador)
    {
      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                        
                          :+##+          ::-:                                                    
                         -@@@@@*            :=                                                   
                         @@@@%*=             =                               .=:.                   
                    :---*@@@@%*+=-::::======:-%=>                           :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:         _                   +:::-+                                         
                        %@@@@@@%@+           +         |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+             -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                 .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                        .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                            +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                     ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                     :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                     -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                      +. +        *: -: 
        *@-  @%.         #@:   :-.                                         +.-:        =: +
        #@+  +@#:        #%*                                              +=:::-         =-.:=                     
        .@@+  =++         #@%:                                           +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                       SALUD = {jugador.Salud}");
      Thread.Sleep(300);
      Console.Clear();



      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>                                      _         
                                                                                          -*#=|          
                                                                                       -*%+.               
                                                                                    :*%+:            
                                                                                 :+@#-             
                                      .=.                                     #++%%=.                         
                          :+##+          ::-:                              --#.-@:                      
                         -@@@@@*            :=                            #: #=*::                       
                         @@@@%*=             =                            .*-++=---                   
                    :---*@@@@%*+=-::::======:-%=>                          -- +-::#               
                    =**#@@@@@%%%%#++==++++==+@:                             +:==-+#=.                   
                        %@@@@@@%@+           +                              *+. :* :=                   
                   ..   %@@@@@@%@#          .+                               + :-=*-**                    
           :-:..  +#+   -@@@@@@@%%        :--                                =+::::. +                    
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                    =:     +                  
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                       *  .:-+                  
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                           -#.:.=-+:                     
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          := .+ +   --                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          +:   .**.   +                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       +   .=-  +.  .=                       
      .@@@@@+=@@@*       #@%-=+**#@-                                     ==-:=:     =-  *                        
      .@@@%@%@%-.        %%#     .@*                                     +--==       :*:#=                                                                    
       +@@#=+@+          *@-   +@%*=                                      +  +        -*. + 
        *@-  @%.         #@:   :-.                                        .+ -:        := .+
        #@+  +@#:        #%*                                               .#-#          +:--                     
        .@@+  =++         #@%:                                           +++--=.         -+:--  
        
        SALUD = {monstruo.Salud}                                                       SALUD = {jugador.Salud}");
      Thread.Sleep(300);
      Console.Clear();



      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                        
                          :+##+          ::-:                                                    
                         -@@@@@*            :=                                                   
                         @@@@%*=             =                               .=:.                   
                    :---*@@@@%*+=-::::======:-%=>                           :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:         _                   +:::-+                                         
                        %@@@@@@%@+           +         |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+             -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                 .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                        .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                            +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                     ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                          .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                          --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                       -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                     :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                     -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                      +. +        *: -: 
        *@-  @%.         #@:   :-.                                         +.-:        =: +
        #@+  +@#:        #%*                                              +=:::-         =-.:=                     
        .@@+  =++         #@%:                                           +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud - danioJugador}                                                       SALUD = {jugador.Salud}
                                                                         DANIO CAUSADO = {danioJugador}");



    }

    public static void EfectoCombateMonstruo(Personaje jugador, Monstruo monstruo, int danioMonstruo)
    {
      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                                           
                          :+##+          ::-:                                                                       
                         -@@@@@*            :=                                                                      
                         @@@@%*=             =                                                  .=:.                   
                    :---*@@@@%*+=-::::======:-%=>                                              :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -: 
        *@-  @%.         #@:   :-.                                                            +.-:        =: +
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                               SALUD = {jugador.Salud}");
      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                                           
                          :+##+          ::-:                                                                       
                         -@@@@@*            :=                                                                      
                         @@@@%*=             =                                                  .=:.                   
                    :---*@@@@%*+=-::::     >=:-%======>                                        :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -: 
        *@-  @%.         #@:   :-.                                                            +.-:        =: +
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                               SALUD = {jugador.Salud}");

      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                                           
                          :+##+          ::-:                                                                       
                         -@@@@@*            :=                                                                      
                         @@@@%*=             =                                                  .=:.                   
                    :---*@@@@%*+=-::::       :-%         >========>                            :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -: 
        *@-  @%.         #@:   :-.                                                            +.-:        =: +
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                               SALUD = {jugador.Salud}");

      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                                           
                          :+##+          ::-:                                                                       
                         -@@@@@*            :=                                                                      
                         @@@@%*=             =                                                  .=:.                   
                    :---*@@@@%*+=-::::       :-%                       >========>              :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -: 
        *@-  @%.         #@:   :-.                                                            +.-:        =: +
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                               SALUD = {jugador.Salud}");

      Thread.Sleep(300);
      Console.Clear();
      Console.WriteLine(@$"
      <<<---APARECE UN {monstruo.Tipo}, CUIDADO!!--->>>




                                      .=.                                                                           
                          :+##+          ::-:                                                                       
                         -@@@@@*            :=                                                                      
                         @@@@%*=             =                                                  .=:.                   
                    :---*@@@@%*+=-::::       :-%                                    >========> :=:.=-                  
                    =**#@@@@@%%%%#++==++++==+@:                            _                   +:::-+                                         
                        %@@@@@@%@+           +                            |:+**=.              +.--+*-:                                          
                   ..   %@@@@@@%@#          .+                                -+#*-.           +:  +:.--                                      
           :-:..  +#+   -@@@@@@@%%        :--                                    .-*#*-..+  .:-*. -= =++                                   
         *@@@@%%%%#*---=**@@@@@@%%=   .-:.                                           .=%%:++:*-+#++.-= +                               
       .%@@@@@@@@@%%%%%%@@@@@%@%%@+    .                                               +--*::%-:::==   +                             
       %@@@@@@@@%@%%%%%@@@@@@@%%@@.                                                        ::-   :*:::=*=                         
       @@@@@@@@%@@@%%%%%@@@@@@@@@-                                                             .=.-: =. :=                     
      .@@@@@@%%%@@@@@@@@@@@@@@@@=                                                             --   =++   -:                      
      .@@@@@@%@@@@*+#%@@@@%%@@@@#-:                                                          -:  .-- :=   +                       
      .@@@@@+=@@@*       #@%-=+**#@-                                                        :+:--:    .=  -.                        
      .@@@%@%@%-.        %%#     .@*                                                        -=:-=       +-=+:                                                                    
       +@@#=+@+          *@-   +@%*=                                                         +. +        *: -: 
        *@-  @%.         #@:   :-.                                                            +.-:        =: +
        #@+  +@#:        #%*                                                                 +=:::-         =-.:=                     
        .@@+  =++         #@%:                                                              +=:::-         =-.:=  
        
        SALUD = {monstruo.Salud}                                                               SALUD = {jugador.Salud - danioMonstruo}
        DANIO CAUSADO = {danioMonstruo}");
        

    }


  }
}