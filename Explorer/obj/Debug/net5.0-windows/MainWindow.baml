   M S B A M L   `   `   `  ????C  ?Explorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExplorerExplorer  5   	       Explorer.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Explorer     5   	   -   5          ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   ???	#FF2B8162.??5	      ? -   5         ?Name$ mainGrid??5	      .+?5
   
   ?? -   5         ??Name$ 	groupBox1??5
      .??5      ?  ? RowDefinitions 5      ?? 5      -   5         ??Name$ search??5   $   $
??Auto ?64   ?? 5       ? ColumnDefinitions 5      ?? 5      .+?5      ?? $??0??6   $??0??6-    ?? Orientation$ 
Horizontal=?6:   .+?5      ?? -   5         ??Name$ searchField??5      $??16(?63   $	??700??6A   $??5q?6M   6Z   ?? 5      -   5        $??75??5      $??0,5,15,5q?6(   .??6O   
Найти6V   5      R? 5      -   5         R?Name$ mainTree??5      $??1??6-   ???	#FF4051F3$??5q?6Q   ??5      ?? 5      	 ?? ItemsSource	 63   ?? 
 ?? Path$
 Nodes?.R?5      ?? $??20,0,0,0q?6)    ? ContextMenu 5   "   ?? 5   &   .@?5   *   m? -   5        $??Delete??5   3   6C   m? 5   *   -	   5        $
??Info??5   3   6A   m? 5   *   -
   5        $??Create??5   3   6C   5    '   .+?5"   "   ?? $
??30px??6(   $
??Left=?6Y   $??5q?6t   ??65   ?? $
 ImageSource?6t   ?? 5#   "   
?????????6,   ?? $
 Header?6I   5$      5%      5'      5(      5)      ?? 5*   
   -   5        $ 	groupBox2??5*      $y?Hidden=?6&   .??5+      ?  5,      ?? 5-      $	??10* ?6$   ?? 5.      .+?50      ?? -   5         ??Name$ csText??50      ???	#FF4051F3$??5,10,5,5q?6C   ???#FFFFFF6U   ?? 51      -   5        $??1??51      $??5q?6&   $	??100??61   $
??Back??6=   6L   52      53      54      55      