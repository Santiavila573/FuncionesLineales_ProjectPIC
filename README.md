<h1>TECNOLÓGICO INTERNACIONAL UNIVERSITARIO</h1>
<h2>PROYECTO PIC - GRUPO II</h2>
<h2>DESARROLLO DE SOFTWARE - SEGUNDO NIVEL</h2>
<h2>Integrantes del Equipo: </h2>
<p>Santiago Ávila.</p>
<p>Christian Méndez.</p>
<p>Elihu Quistial.</p>
<br>
<h2>Descripción de la Aplicación: </h2>
<p>El proyecto "Programa de funciones lineales por Windows Forms" tiene como objetivo principal desarrollar un aplicativo el mismo que pueda resolver sistemas de funciones lineales abordando una carencia identificada en el ámbito educativo y profesional como la falta de aplicaciones y/o tecnología amigable para estudiantes.</p>

<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/bff10895-9c97-4773-a450-02778c9b6161/">
<p> - Logueo con usuario y contraseña.</p>
<h2>Interfaz Gráfica con Windows Forms</h2>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/d53caa65-64bb-4f0c-b510-bdda71eec48e"/>
<h2>Proyecto por Capas</h2>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/07ee7144-086d-4246-ae8d-bcf13299ccb9"/> 
<h3>Capa de Acceso</h3>
- La capa de acceso tiene una clase que se llama DataAccess, indicando que es el acceso a la base de datos de Access. La cuál integra una serie de métodos que manipulan la base de datos como: guardar, obtener, validar, eliminar, a lo que hace referencia un CRUD.
<h3>Capa Lógica</h3>
- En la capa lógica se encuentra la resolución de la función, solamente tiene un método que es calcular Y.
<h3>Capa Presentación</h3>
- La capa presentación tiene el formulario back y tiene el formulario front, que es la parte que ve el cliente.

<h3>Base de Datos</h3>
- En la base de datos se tienen: 2 tablas, una de usuarios y la otra de funciones que ejecuta de uno a muchos que sería prácticamente el modelo relacional. 
<br>
<br>
<img src = "https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/52afeb6c-9515-4174-a286-311af4edf665"/>
  <br>
- Aquí va la información de las funciones que se fueron generando en cada ejecución y también los punto que generó.
  <br>
  <br>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/5a7879ff-cd26-4866-b1b3-6a82bc872393"/>
<br>
<h3>Funcionamiento</h3>
<p> - Al momento de abrir se visualiza el login, comprueba que se introduzcan las credenciales correctas de no ser así aparecera un mensaje informando que son datos erroneos por el motivo de que se válida la información en la base de datos.</p>
<img src=https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/224b028c-a5e7-4d56-b04d-cf9db5958ff9/>
<br>
<br>
<p> - Si los datos fueron los correctos, se visualizará un mensaje de bienvenido. Y posteriormente se abre la ventana del formulario...</p>
<img src=https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/f40cc325-c3e6-4c39-b4a6-863ec40c6f4c"/>
<br>
<p> - El formulario carga los registros que se tienen en la base de datos, si nos situamos en un registro el programa lo va graficando</p>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/36078af1-7d99-4cb3-aca2-3f499d7f7228"/>
<br>
<br>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/777c7f37-8cb8-4267-a4d2-1fc9d972d500"/>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/f784392a-b46d-41ae-8750-380b5047b04a"/>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/044a706e-f091-4814-8cf8-5b3557719fff"/>
<br>
<br>
<p>De la misma manera si se quiere añadir un nuevo ejemplo se llenan los campos, la gráfica y la almacena para revisarla luego.</p>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/117c557c-15fd-437f-922e-6d50f87d0d74"/>

<p>DATO ADICIONAL: Tomar en cuenta que el programa se guía de la fórmula estándar de funciones lineales: Ax+By=C.</p>
<br>
<h3>Diagrama de Clases</h3>
<p>Según todo lo establecido se consiguió generar esté diagrama de clases para mejor comprensión del programa.</p>
<br>
<img src="https://github.com/Santiavila573/FuncionesLineales_ProjectPIC/assets/156937812/99aece7d-9ace-4a3a-87c0-13dc3d7508b9"/>
<p>Esto solamente es un breve resumen del funcionamiento del programa.</p>
<br>
<br>
<p>¡Gracias por su atención!</p>














