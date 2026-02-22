🌍  Análisis de Riesgo País

El Dashboard de Análisis de Riesgo País es una aplicación web full-stack desarrollada con el objetivo de analizar y visualizar el nivel de riesgo económico de distintos países mediante el consumo de APIs externas y la representación gráfica de datos en tiempo real. El sistema permite al usuario ingresar el nombre de un país y obtener información relevante como región, población, puntaje económico (Economic Score), nivel de riesgo y una recomendación generada automáticamente.

Este proyecto fue desarrollado utilizando una arquitectura basada en ASP.NET Core Web API para el backend y HTML, CSS y JavaScript para el frontend, integrando la librería Chart.js para la visualización dinámica de datos.

🏗 Arquitectura del Sistema

El proyecto está estructurado bajo una separación clara de responsabilidades:

🔹 Backend (ASP.NET Core)

El backend fue desarrollado en C# utilizando ASP.NET Core 8, aplicando buenas prácticas de organización por capas:

Controllers → Gestionan las solicitudes HTTP.

Services → Contienen la lógica de negocio (cálculo del Economic Score y clasificación del riesgo).

Clients → Encargados de consumir APIs externas mediante HttpClient.

Program.cs → Configuración de servicios, middlewares, Swagger y archivos estáticos.

El endpoint principal del sistema es:

GET /api/Risk/{country}

Este endpoint recibe el nombre del país como parámetro y retorna un objeto JSON con la información procesada.

🔌 Funcionamiento General

El flujo del sistema es el siguiente:

El usuario ingresa el nombre de un país en el frontend.

Se ejecuta una petición fetch() hacia el endpoint /api/Risk/{country}.

El backend consulta APIs externas para obtener información del país.

Los datos se procesan en el RiskAnalysisService.

Se calcula el Economic Score.

Se determina el nivel de riesgo (Alto, Medio o Bajo).

Se genera una recomendación.

El backend retorna un JSON estructurado.

El frontend actualiza automáticamente la tabla y las gráficas.

📊 Lógica del Economic Score

El Economic Score representa una métrica simplificada del nivel de estabilidad económica del país, calculado con base en:

Indicadores regionales

Información demográfica

Procesamiento interno del servicio

Clasificación del riesgo:

80 – 100 → Bajo riesgo

60 – 79 → Riesgo medio

0 – 59 → Alto riesgo

Según el rango obtenido, el sistema asigna automáticamente una recomendación de inversión o precaución.

🎨 Frontend

El frontend fue desarrollado utilizando:

HTML5 para la estructura

CSS3 para el diseño moderno tipo dashboard

JavaScript (ES6) para la lógica dinámica

Chart.js para la visualización gráfica

El diseño incluye:

Cuadro central con tabla de resultados

Gráfica circular (Doughnut) para el Economic Score

Gráfica lineal para la tendencia estimada

Manejo de errores visual

Diseño responsive básico

Separación de archivos (HTML, CSS y JS)

📈 Visualización de Datos

Se implementaron dos tipos de gráficas:

1️⃣ Gráfica Circular (Doughnut)

Representa el Economic Score en relación a 100 puntos.
Los colores cambian dinámicamente según el nivel de riesgo:

Verde → Bajo riesgo

Amarillo → Riesgo medio

Rojo → Alto riesgo

2️⃣ Gráfica de Tendencia

Simula una evolución estimada del puntaje en los últimos años, mostrando una progresión visual del indicador económico.

📂 Estructura del Proyecto

El proyecto se organiza de la siguiente manera:

Controllers → Controladores de la API

Services → Lógica de negocio

Clients → Consumo de APIs externas

DTOs  → objetos utilizados para transferir datos entre capas, especialmente entre el backend y el frontend

wwwroot → Archivos estáticos (HTML, CSS, JS)

Program.cs → Configuración general

Se aplicó separación de responsabilidades para mantener un código limpio y escalable.

🛠 Tecnologías Utilizadas

ASP.NET Core 8

C#

HTML5

CSS3

JavaScript ES6

Chart.js

HttpClient

Swagger (para documentación y pruebas)

📋 Gestión del Proyecto

El desarrollo fue organizado mediante Trello, utilizando las siguientes columnas:

Backlog → Ideas futuras

Pendiente → Próximas tareas

En desarrollo → Trabajo activo

Testing → Validaciones y pruebas

Producción → Listo para entrega

Completado → Tareas finalizadas

Esto permitió una planificación estructurada del proyecto y control del progreso.

🎯 Objetivos del Proyecto

Aplicar conocimientos de desarrollo web full-stack.

Implementar consumo de APIs externas.

Integrar visualización de datos interactiva.

Aplicar separación por capas en ASP.NET Core.

Desarrollar una interfaz moderna y funcional.

Practicar organización de proyecto con Trello.

🔮 Mejoras Futuras

Implementación de autenticación de usuarios.

Comparador de múltiples países.

Exportación de reportes en PDF.

Dashboard administrativo.

Historial de consultas.

👨‍💻 Autor

Desarrollado por Jhordan Galindo
Estudiante de Ingeniería

