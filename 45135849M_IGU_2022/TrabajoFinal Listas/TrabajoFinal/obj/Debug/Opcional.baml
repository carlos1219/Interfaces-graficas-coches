   M S B A M L   `   `   `  ????G  CTrabajoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TrabajoFinalTrabajoFinal  5   	       TrabajoFinal.Opcional   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TrabajoFinal     5   	     ? Title$  Opcional??5   	   $	??500??6   $
??1000??6'   ???	#FFC3E2FF.??5	      ? $??Visible=?6    ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $
??2.5* ?6   ?? 5      $??2* ?6   ?? 5      $??4* ?6   ?? 5      $??4* ?6   ?? 5      $??3* ?6   ?? 5      $??3* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??* ?6   .+?5    
   ?? -   5         ??Name$ TituloBorder??5       ???	#FFF54F4F$??9??6>   ._?5!      ?? -   5        $??Titulo??5!      $??TIENDA??6&   $??Center=?65   $??Center=?6P   $??24(?6m   
???????6{   5"      ?? 5#   
   $??
Matricula:??6   $??1??6&   $??Bottom=?63   $??Center=?6N   $??Black"?6k   $??15(?6~   $??1??6?   ?? 5$   
   -   5         ??Name$ listamat??5$      $??2??6R   $??2??6`   $??1??6q   ??5%      ?? 5&      .R?5'      ?? .+?5(      ?? ??6$   ?? *	Matricula+5)      5*      5,      ?? 5-   
   $??Fecha Repostaje:??6   $??4??6,   $	??Top=?69   $??Center=?6Q   $??Black"?6n   $
??12.5(?6?   $??1??6?   $??0,13,0,0q?6?   ?? 5.   
   -   5        $ 
listarepos??5.      $??5??6W   $??2??6e   $??1??6v   ??5/      ?? 50      .R?51      ?? .+?52      ?? ??6$   ?? *Fecha+53      54      56      ?? 57   
   -   5        $ ListaTienda??57      $??2??6(   $??2??65   $??3??6I   $??5??6Y   ???	#FFEEFFB7??58      ?? 59      .R?5:      ??  ?? Orientation$ 
Horizontal=?6!   .+?5;      ?? $	??100??6;   $	??100??6G   $??30,0,0,0q?6T   ??6    ?? *	Archivo+6T   ?? 5<      $ Vertical=?6%   .+?5=      ?? $??30(?6@   $??90,10,10,10q?6N   ??6(   ?? *Precio+6N   5>      5?      5@      5B      ?? 5C   
   -   5        $??	Productos??5C      $??3??6%   $??1??65   $??Bottom=?6B   $
??Left=?6^   $??	Producto:??6y   $??22(?6?   $??Times New Roman)?6?   $??
ExtraBlack"?6?   ?? 5D   
   -   5        $??Precio??5D      $??4??6"   $??1??62   $??Bottom=?6?   $
??Left=?6[   $??Precio:??6v   $??22(?6?   $??Times New Roman)?6?   $??
ExtraBlack"?6?   ?? 5E   
   -   5        $??AñadirCarrito??5E      $??5??6&   $??3??66   $??	ExtraBold"?6D   $??1??6\   ??5F      ?? 5G      .R?5H      ??  ?? CornerRadius$ 50??6   $??3q?6/   
????? ????	#FFFFC7C7._?5I      ?? $??Añadir al carrito??6+   $??Center=?6G   $??Center=?6b   5J      5K      5M      ?? 5N   
   -	   5        $??BorrarCarrito??5N      $??5??6&   $??5??66   $??	ExtraBold"?6D   $??1??6\   ??5O      ?? 5P      .R?5Q      ?? $ 50??6   $??3q?6/   
????? ????	#FFFFE6B8._?5R      ?? $??Borrar del carrito??6+   $??Center=?6H   $??Center=?6c   5S      5T      5V      ?? 5W   
   -
   5        $ ListaComprar??5W      $??2??6)   $??2??66   $??6??6J   $??5??6Z   ???	#FFB7FFFD??5X      ?? 5Y      .R?5Z      ?  5[      ?? 5\      $	??150 ?6/   ?? 5]      $??50 ?6/   ?? 5^      $??50 ?6/   .+?5`      ?? $??15(?6<   $??0??6K   $
??Left=?6[   ??6$   ?? *Nombre+6[   ?? 5a      $??15(?6<   $??1??6K   $
??Left=?6[   ??6$   ?? *Precio+6[   ?? 5b      $??15(?6>   $??2??6M   $
??Left=?6]   ??6$   ?? *
Cantidad+6]   5d      5e      5g      ?? 5h   
   -   5        $??Carrito??5h      $??6??6#   $??1??63   $??Bottom=?6@   $??Center=?6\   $??2??6y   $??Carrito:??6?   $??27(?6?   $??Times New Roman)?6?   $??
ExtraBlack"?6?   ?? 5i   
   -   5        $??Comprar??5i      $??Comprar??6    $??6??62   $??7??6B   $??2??6O   $??
ExtraBlack"?6c   $??22(?6{   $??Times New Roman)?6?   ??5j   
   ?? 5k      .R?5l      ?? $ 50??6   $??3q?6+   
????? ????	#FFBCFBC3._?5m      ?? $??Comprar??6'   $??Center=?69   $??Center=?6T   5n      5o      5q      5r      5s      