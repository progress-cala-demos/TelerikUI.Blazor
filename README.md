
# DEMO BLAZOR � TELERIK-UI � ver1.0
Esta Aplicaci�n Web contiene ejemplos pr�cticos en el uso de algunos de los componentes de Telerik-UI.

# ASPECTOS TECNOLOGICOS
+ **IMPLEMENTACION**:
	+ BackEnd: Demo1WebAPI � WebAPI � EF � .Net 7
	+ FrontEnd: Demo1 � Blazor WASM � .Net 7
	+ DataBase: Northwind � SqlServer 2017+
	+ IDE: Visual Studio 2022
	
+ **COMPENENTES USADOS**:
	+ BlazorUI 4.0.1 � 2023.R1
		+ AutoComplete
		+ TextBox
		+ MaskedTextBox
		+ DatePicker
		+ Validation
		+ DropDownList
		+ Dialog
		+ LineChart
	+ BlazorUI 4.0.1 � 2023.R1
		+ ReportViewer - NativeBlazor
		+ Report Designer
	+ Report Server 9.0.23 � 2023.R1
	
+ **HTML TEMPLATE**:
	+ Copyright � [Creative-Tim](https://www.creative-tim.com/product/material-dashboard-pro)

# ARCHIVOS EXTERNOS
+ **ReporteFactura1.trdx**: Archivo XML fuente del reporte creado con el Reporting Designer.
+ **dbdemo01_27feb2023_1.bak**: Backup de la DB, esta basada en la DB Northwind, pero esta versi�n se ha sometido a cambios..

# ACERCA DEL AUTOR
_Oscar Nivia_, Ingeniero de Preventa Progress Software para CALA
> oscar.nivia@progress.com <br>onivia@hotmail.com <br>https://www.linkedin.com/in/oscar-nivia-36b591150/

# LINKS DE INTERES
+ https://www.telerik.com/
+ https://www.telerik.com/blazor-ui
+ https://demos.telerik.com/blazor-ui/
+ https://docs.telerik.com/blazor-ui/introduction
+ https://www.telerik.com/purchase.aspx?filter=web

# C�MO PONERLA EN MARCHA (RUNNING)
1. Restaure la DB en SQLSERVER, el archivo .bak se puede restaurar en un SqlServer 2017 o superior.
2. Registre en el "appsettings.json" del proyecto Demo1WebAPI el string de conexion de la DB dbdemo01.
3. Abra la soluci�n (_son 3 proyectos_) desde VisualStudio2022.
4. Agregue el repositorio nuget telerik.com (trial o licenciado), ver: https://docs.telerik.com/blazor-ui/installation/nuget#visual-studio-gui
5. Haga "Clean" y "Rebuild" de cada proyecto, aseg�rese de la correcta compilaci�n.
6. Ejecute la soluci�n, aseg�rese que el orden ejecuci�n sea "Demo1WebAPI" y luego "Demo1".
7. Para que la funcionalidad de la "Pagina6.razor" trabaje correctamente, debe instalar: Reporting (_opcional_) y ReportServer (_requerido_).
8. Edite el archivo del reporte "ReporteFactura1.trdx�, y edite los 3 strings de conexi�n, ap�ntelos hacia la DB dbdemo01.
9. Publique el reporte "ReporteFactura1" bajo la categor�a "Demo1" dentro del ReportServer, prueba su correcta visualizaci�n.
10. Listo, pruebe la funcionalidad de la "Pagina6.razor", opci�n "O     Orders-R-Report".

# DESCARGO DE RESPONSABILIDAD
Esta Aplicaci�n es de libre descarga y uso, la cual se ofrece p�blicamente para <ins>__orientar ilustrativamente__</ins> la inclusi�n y uso de los componentes Telerik-UI en los ciclos de desarrollo, verifique cuidadosamente su c�digo, versiones, estabilidad, contexto, comportamiento y alcance antes de considerar usar directamente o retransmitir copias, partes o totalidades de su contenido en entornos de desarrollo, pruebas o productivos propios, tenga en cuenta que su Autor se libera de cualquier responsabilidad de esta versi�n y cambios los cuales har�n sin previo anuncio.
Progress Software, Telerik, .Net, nuget packages incluidos, Creative-Tim y otras, son marcas registradas, por favor verifique los acuerdos y t�rminos de licenciamiento para su uso.
###### Copyright � 2023 Progress Software Corporation y/o sus subsidiarias o afiliadas. Todos los derechos reservados.